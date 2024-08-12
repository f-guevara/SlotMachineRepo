# Slot Machine Game

Welcome to the Slot Machine Game! This console-based game allows users to simulate a slot machine experience, betting money and choosing different play options to win rewards.

## Table of Contents

- [Game Overview](#game-overview)
- [Features](#features)
- [How to Play](#how-to-play)
- [Function Breakdown](#function-breakdown)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

---

## Game Overview

In this game, players start by entering an amount they'd like to gamble (between €1 and €100). They then choose a play option and begin spinning the slot machine. Each spin costs €1, and winning yields a reward of €10. The game continues until the player decides to quit or runs out of money.

## Features

- **Multiple Play Options:** Players can choose from various play styles, including center line, all horizontal lines, vertical lines, or diagonals.
- **Input Validation:** Robust validation ensures players enter valid amounts and choices.
- **Randomized Gameplay:** Each spin generates a new, random grid, ensuring unpredictability.
- **User-Friendly Interface:** Clear prompts and messages guide players throughout the game.

## How to Play

1. **Starting the Game:**
   - Run the program.
   - Enter the amount you'd like to start with (between €1 and €100).

2. **Choosing Play Option:**
   - Select your preferred game mode from the following:
     - **1:** Center Line
     - **2:** All Three Horizontal Lines
     - **3:** All Vertical Lines
     - **4:** Diagonals

3. **Playing the Game:**
   - Each spin costs €1.
   - After each spin, the grid is displayed.
   - If you win based on your chosen play option, you earn €10.

4. **Continuing or Quitting:**
   - After each round, decide whether to continue playing or quit.
   - The game ends if you run out of money or choose to quit.

5. **Ending the Game:**
   - Upon exiting, a thank-you message is displayed.

## Function Breakdown

### Main Flow:

1. **`GetStartingMoney()`:**
   - Prompts the user to enter the amount they'd like to gamble.
   - Ensures the input is a valid integer between €1 and €100.

2. **`GetPlayOption()`:**
   - Allows the user to select their preferred game mode.
   - Validates the choice to ensure it's between 1 and 4.

3. **Game Loop (`while` loop):**
   - Continues as long as the player has money.
   - Deducts €1 for each spin.
   - Generates and displays a new random grid.
   - Checks for a win based on the selected play option.
   - Rewards €10 for each win.
   - Prompts the player to continue or quit.

4. **Exit Message:**
   - Displays a thank-you message upon exiting the game.

### Supporting Functions:

1. **`GenerateRandomGrid()`:**
   - Generates a 3x3 grid filled with random symbols ranging from "0" to "5".

2. **`DisplayGrid(string[,] grid)`:**
   - Displays the current grid on the console.

3. **`CheckForWin(string[,] grid, int option)`:**
   - Determines if the player has won based on the current grid and selected play option.

## Getting Started

1. **Prerequisites:**
   - Ensure you have a C# compiler or an environment like Visual Studio.

2. **Running the Game:**
   - Clone the repository.
   - Open the project in your preferred C# environment.
   - Build and run the project.

## Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository.
2. Create your feature branch: `git checkout -b feature/YourFeature`
3. Commit your changes: `git commit -m 'Add YourFeature'`
4. Push to the branch: `git push origin feature/YourFeature`
5. Open a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
