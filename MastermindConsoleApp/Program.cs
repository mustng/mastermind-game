using System;

namespace MastermindGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game variables
            var random = new Random();
            var answer = GenerateAnswer(random);

            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Guess the 4-digit number (each digit is between 1 and 6).");
            Console.WriteLine("A '+' means correct digit in the correct position.");
            Console.WriteLine("A '-' means correct digit but in the wrong position.");
            Console.WriteLine("You have 10 attempts. Good luck!\n");

            // Main game loop
            for (int attempt = 1; attempt <= 10; attempt++)
            {
                Console.Write($"Attempt {attempt}/10: ");
                var guess = Console.ReadLine();

                // Validate guess length
                if (string.IsNullOrWhiteSpace(guess) || !IsDigitsInRange(guess))
                {
                    Console.WriteLine("Invalid input. Please enter a 4-digit number with each digit between 1 and 6.");
                    attempt--; // retry the same attempt if input is invalid
                    continue;
                }

                // Check the guess and generate hint
                var hint = GetHint(answer, guess);
                Console.WriteLine("Hint: " + hint);

                // Check for win condition
                if (hint == "++++")
                {
                    Console.WriteLine("Congratulations! You've guessed the number correctly!");
                    return;
                }
            }

            // If the loop ends without a win
            Console.WriteLine($"Sorry, you've run out of attempts. The correct answer was: {answer}");
        }

        // Generates a random 4-digit answer with each digit between 1 and 6
        static string GenerateAnswer(Random random) =>
            new string(Enumerable.Range(0, 4)
                .Select(_ => (char)('1' + random.Next(6))) // Generate a digit between '1' and '6'
                .ToArray());

        // Validates that all digits in the guess are between 1 and 6
        static bool IsDigitsInRange(string guess) =>
            System.Text.RegularExpressions.Regex.IsMatch(guess, "^[1-6]{4}$");

        // Generates a hint based on the answer and the guess
        static string GetHint(string answer, string guess)
        {
            int[] answerDigitCount = new int[6];
            int[] guessDigitCount = new int[6];
            int plusCount = 0, minusCount = 0;

            // First pass: Count the '+' (correct digit in correct position)
            plusCount = Enumerable.Range(0, 4)
                .Count(i => answer[i] == guess[i]);

            // Count unmatched digits and calculate '-'
            var unmatchedCounts = Enumerable.Range(0, 4)
                .Where(i => answer[i] != guess[i])
                .Aggregate((answerDigitCount: new int[6], guessDigitCount: new int[6]), (counts, i) =>
                {
                    counts.answerDigitCount[answer[i] - '1']++;
                    counts.guessDigitCount[guess[i] - '1']++;
                    return counts;
                });

            minusCount = unmatchedCounts.answerDigitCount
                .Zip(unmatchedCounts.guessDigitCount, Math.Min)
                .Sum();

            // Construct the hint string with all '+' first, followed by all '-'
            return new string('+', plusCount) + new string('-', minusCount);
        }
    }
}
