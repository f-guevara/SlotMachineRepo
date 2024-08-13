namespace SlotMachine
{
    internal class Program
    {
        // Constants
        const int MIN_BET_AMOUNT = 1;
        const int MAX_BET_AMOUNT = 100;
        const int COST_PER_SPIN = 1;
        const int WIN_AMOUNT = 10;
        const string CONTINUE_PLAYING_YES_1 = "y";
        const string CONTINUE_PLAYING_YES_2 = "Y";
        const int PLAY_OPTION_CENTER_LINE = 1;
        const int PLAY_OPTION_HORIZONTAL_LINES = 2;
        const int PLAY_OPTION_VERTICAL_LINES = 3;
        const int PLAY_OPTION_DIAGONALS = 4;


        static void Main(string[] args)
        {
            // Step 1: Ask for the starting amount of money with validation
            int money = GetStartingMoney();

            // Step 2: Ask the player for the type of play (this will be kept through the entire game)
            int playOption = GetPlayOption();

            while (money >= COST_PER_SPIN)
            {
                Console.Clear();
                // Step 3: Deduct 1 euro for each spin
                money -= COST_PER_SPIN;
                Console.WriteLine($"You have {money} euros left. Spinning the slot machine...");

                // Generate and display the random grid
                string[,] grid = GenerateRandomGrid();
                DisplayGrid(grid);

                // Step 4: Check if the user wins
                if (CheckForWin(grid, playOption))
                {
                    Console.WriteLine("WIN!! :) You've earned 10 euros!");
                    money += WIN_AMOUNT;
                }
                else
                {
                    Console.WriteLine("TRY AGAIN!! :{");
                }

                // Step 5: Ask if they want to continue
                Console.WriteLine($"You now have {money} euros.");
                Console.WriteLine("Do you want to continue playing? (y/n)");
                string response = Console.ReadLine();
                if (response != CONTINUE_PLAYING_YES_1 && response != CONTINUE_PLAYING_YES_2)
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
                    if (money >= MIN_BET_AMOUNT && money <= MAX_BET_AMOUNT)
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

        static int GetPlayOption()
        {
            int option = 0;
            bool validOption = false;

            while (!validOption)
            {
                Console.WriteLine("\nChoose your play option:");
                Console.WriteLine($"{PLAY_OPTION_CENTER_LINE}: Center Line");
                Console.WriteLine($"{PLAY_OPTION_HORIZONTAL_LINES}: All Three Horizontal Lines");
                Console.WriteLine($"{PLAY_OPTION_VERTICAL_LINES}: All Vertical Lines");
                Console.WriteLine($"{PLAY_OPTION_DIAGONALS}: Diagonals");
                Console.Write($"Enter your choice ({PLAY_OPTION_CENTER_LINE}-{PLAY_OPTION_DIAGONALS}): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out option))
                {
                    if (option >= PLAY_OPTION_CENTER_LINE && option <= PLAY_OPTION_DIAGONALS)
                    {
                        validOption = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option (1-4).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }

            return option;
        }

        static bool CheckForWin(string[,] grid, int option)
        {
            switch (option)
            {
                case PLAY_OPTION_CENTER_LINE:
                    return grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2];

                case PLAY_OPTION_HORIZONTAL_LINES:
                    return (grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2]) ||
                           (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2]) ||
                           (grid[2, 0] == grid[2, 1] && grid[2, 1] == grid[2, 2]);

                case PLAY_OPTION_VERTICAL_LINES: 
                    return (grid[0, 0] == grid[1, 0] && grid[1, 0] == grid[2, 0]) ||
                           (grid[0, 1] == grid[1, 1] && grid[1, 1] == grid[2, 1]) ||
                           (grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2]);

                case PLAY_OPTION_DIAGONALS:
                    return (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) ||
                           (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]);

                default:
                    return false;
            }
        }
    }
}