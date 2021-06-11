using System;

namespace GP_Cavernas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console Variables
            int lin, cols, n;
            lin = Convert.ToInt32(args[0]);
            cols = Convert.ToInt32(args[1]);
            n = Convert.ToInt32(args[2]);

            // Initializes the map
            char[,] wolrd = WorldGeneration(cols, lin);

            MapPrinter(cols, lin, wolrd);
            //int[,] newWorld = new int[lin, cols];
            //int[,] auxWorld = new int[lin, cols];
        }
        private static char[,] WorldGeneration(int cols, int lin)
        {
            Random rnd = new Random();

            char[,] world = new char[lin, cols];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j <cols; j++)
                {
                    if (rnd.Next(1, 4) < 3)
                        world[i, j] = 'g';
                    else
                        world[i, j] = 'r';
                }
            }
            return world;
        }
        private static void MapPrinter(int cols, int lin, char[,] map)
        {
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i, j] == 'g')
                        Console.Write(".");
                    else
                        Console.Write("#");
                }
                Console.WriteLine("");
            }
        }
    }
}
