namespace SlotMachine
{
    internal class Program
    {
        // Constants
        const int GRID_SIZE = 3;
        const int MIN_BET_AMOUNT = 1;
        const int MAX_BET_AMOUNT = 100;
        const int COST_PER_SPIN = 1;
        const int WIN_AMOUNT = 10;
        const string CONTINUE_PLAYING_YES_1 = "y";
        const string CONTINUE_PLAYING_YES_2 = "Y";
        const int RANDOM_MIN_VALUE = 0;
        const int RANDOM_MAX_VALUE = 6;
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
                int[,] grid = GenerateRandomGrid();
                DisplayGrid(grid);

                // Step 4: Check if the user wins
                if (CheckForWin(grid, playOption))
                {
                    Console.WriteLine($"WIN!! :) You've earned {WIN_AMOUNT} euros!");
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
                Console.Write($"Enter the amount of money you want to start with ({MIN_BET_AMOUNT} to {MAX_BET_AMOUNT} euros): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out money))
                {
                    if (money >= MIN_BET_AMOUNT && money <= MAX_BET_AMOUNT)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter an amount between {MIN_BET_AMOUNT} and {MAX_BET_AMOUNT} euros.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number (no cents).");
                }
            }

            return money;
        }

        static int[,] GenerateRandomGrid()
        {
            int[,] grid = new int[GRID_SIZE, GRID_SIZE];
            Random random = new Random();

            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    grid[i, j] = random.Next(RANDOM_MIN_VALUE, RANDOM_MAX_VALUE);
                }
            }

            return grid;
        }

        static void DisplayGrid(int[,] grid)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
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
                        Console.WriteLine($"Please select a valid option ({PLAY_OPTION_CENTER_LINE}-{PLAY_OPTION_DIAGONALS}).");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number between {PLAY_OPTION_CENTER_LINE} and {PLAY_OPTION_DIAGONALS}.");
                }
            }

            return option;
        }

        static bool CheckForWin(int[,] grid, int option)
        {
            switch (option)
            {
                case PLAY_OPTION_CENTER_LINE:
                    return CheckHorizontalLine(grid, GRID_SIZE / 2);

                case PLAY_OPTION_HORIZONTAL_LINES:
                    for (int i = 0; i < GRID_SIZE; i++)
                    {
                        if (CheckHorizontalLine(grid, i))
                            return true;
                    }
                    return false;

                case PLAY_OPTION_VERTICAL_LINES:
                    for (int i = 0; i < GRID_SIZE; i++)
                    {
                        if (CheckVerticalLine(grid, i))
                            return true;
                    }
                    return false;

                case PLAY_OPTION_DIAGONALS:
                    return CheckMainDiagonal(grid) || CheckAntiDiagonal(grid);

                default:
                    return false;
            }
        }

        static bool CheckHorizontalLine(int[,] grid, int row)
        {
            for (int col = 1; col < GRID_SIZE; col++)
            {
                if (grid[row, col] != grid[row, col - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckVerticalLine(int[,] grid, int col)
        {
            for (int row = 1; row < GRID_SIZE; row++)
            {
                if (grid[row, col] != grid[row - 1, col])
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckMainDiagonal(int[,] grid)
        {
            for (int i = 1; i < GRID_SIZE; i++)
            {
                if (grid[i, i] != grid[i - 1, i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckAntiDiagonal(int[,] grid)
        {
            for (int i = 1; i < GRID_SIZE; i++)
            {
                if (grid[i, GRID_SIZE - i - 1] != grid[i - 1, GRID_SIZE - i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}