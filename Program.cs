namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Generate a random 3x3 grid
            string[,] grid = GenerateRandomGrid();

            // Display the grid
            DisplayGrid(grid);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static string[,] GenerateRandomGrid()
        {
            string[,] grid = new string[3, 3];
            Random random = new Random();

            // Define possible symbols for the slot machine
            string[] symbols = { "0", "1", "2", "3", "4", "5" };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Assign a random symbol to each position in the grid
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

    }
}
