# Mastermind Console Application 🎮

A simple C# console application that implements a basic version of the classic Mastermind game. Test your logic and deduction skills!

## 📝 Exercise Description

**Objective**: Create a C# console application for the Mastermind game.

### Game Rules:
1. A random **4-digit code** is generated, with each digit between **1** and **6**.
2. The player has **10 attempts** to guess the code.
3. After each guess, feedback is provided:
   - **`+`**: A correct digit in the correct position.
   - **`-`**: A correct digit in the wrong position.
   - No symbol means the digit is incorrect.
4. Feedback shows all `+` signs first, followed by all `-` signs, with nothing for incorrect digits.

### Example:
If the secret code is `1234` and the player guesses `4233`, the feedback will be:
```
++-
```

### Win/Loss Conditions:
- **Win**: Guess the correct code within 10 attempts.
- **Loss**: Fail to guess the code after 10 attempts.

---

## 🚀 Features
- Generates a random 4-digit secret code.
- Input validation ensures guesses are exactly 4 digits (1-6).
- Clear feedback after each guess.
- Tracks attempts and ends with a win or loss message.

## 💻 How to Run the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/mustng/mastermind-game.git
   cd mastermind-console-app
   ```
2. Open the project in Visual Studio or any C# IDE.
3. Build and run the application.

---

## 📂 Project Structure
- **`Program.cs`**: Contains the complete game logic.
  - Randomly generates the secret code.
  - Validates input for length and range.
  - Provides feedback (`+`, `-`) based on the player's guess.
  - Tracks attempts and determines win/loss outcomes.

---

## 🧠 Skills Demonstrated
- C# console application development
- Random number generation
- Input validation and error handling
- Logic-based problem-solving
- Clean and modular code organization

---

## 🎯 Example Game Flow
1. **Game Start**:
   ```
   Welcome to Mastermind!
   Guess the 4-digit number (each digit is between 1 and 6).
   A '+' means correct digit in the correct position.
   A '-' means correct digit in the wrong position.
   You have 10 attempts. Good luck!
   ```

2. **Player Input and Feedback**:
   ```
   Attempt 1/10: 4233
   Hint: ++-
   ```

3. **Win Condition**:
   ```
   Attempt 4/10: 1234
   Hint: ++++
   Congratulations! You've guessed the number correctly!
   ```

4. **Loss Condition**:
   ```
   Attempt 10/10: 6543
   Hint: -
   Sorry, you've run out of attempts. The correct answer was: 1234
   ```

---

## 🔗 License
This project is open-source and available under the [MIT License](LICENSE).
