namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Ask for the starting amount of money with validation
            int money = GetStartingMoney();

            while (money > 0)
            {
                Console.Clear();
                // Step 2: Deduct 1 euro for each spin
                money -= 1;
                Console.WriteLine($"You have {money} euros left. Spinning the slot machine...");

                // Generate and display the random grid
                string[,] grid = GenerateRandomGrid();
                DisplayGrid(grid);

                // Step 3: Check if the user wins
                if (CheckForWin(grid))
                {
                    Console.WriteLine("WIN!! :) You've earned 10 euros!");
                    money += 10;
                }
                else
                {
                    Console.WriteLine("TRY AGAIN!! :{");
                }

                // Step 4: Ask if they want to continue
                Console.WriteLine($"You now have {money} euros.");
                Console.WriteLine("Press 'y' or 'Y' to play again, or any other key to quit...");
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Y && key.KeyChar != 'y')
                {
                    break;
                }
            }

            // If they run out of money or quit
            Console.WriteLine("\nGame Over. Thanks for playing!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static int GetStartingMoney()
        {
            int money = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter the amount of money you want to start with (1 to 100 euros): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out money))
                {
                    if (money >= 1 && money <= 100)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter an amount between 1 and 100 euros.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number (no cents).");
                }
            }

            return money;
        }

        static string[,] GenerateRandomGrid()
        {
            string[,] grid = new string[3, 3];
            Random random = new Random();
            string[] symbols = { "0", "1", "2", "3", "4", "5" };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = symbols[random.Next(symbols.Length)];
                }
            }

            return grid;
        }

        static void DisplayGrid(string[,] grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckForWin(string[,] grid)
        {
            // Simple win condition: all symbols in the first row match
            return grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2];
        }
    }
}