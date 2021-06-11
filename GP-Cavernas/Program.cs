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
            char[,] world = WorldGeneration(cols, lin);
            MapPrinter(cols, lin, world);
            Console.WriteLine("");
            for (int i = 0; i < n; i++)
            {
                char[,] newWorld = MooreRockMaker(world, lin, cols);
                MapPrinter(cols, lin, newWorld);
                Console.WriteLine("");
            }

            //int[,] newWorld = new int[lin, cols];
            //int[,] auxWorld = new int[lin, cols];
        }
        private static char[,] MooreRockMaker(char[,]world, int lin, int cols)
        {
            int neig;
            char[,] newWorld = new char[lin, cols];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    neig = 0;
                    // Upper Line
                    if (world[Wrap(i - 1, world.GetLength(0)),
                        Wrap(j - 1, world.GetLength(1))] == 'r')
                    { neig += 1; }
                    if (world[Wrap(i - 1, world.GetLength(0)), j] == 'r')
                    { neig += 1; }
                    if (world[Wrap(i - 1, world.GetLength(0)),
                        Wrap(j + 1, world.GetLength(1))] == 'r')
                    { neig += 1; }

                    // Mid Line
                    if (world[i, Wrap(j + 1, world.GetLength(1))] == 'r')
                    {
                        neig += 1;
                    }
                    if (world[i, Wrap(j - 1, world.GetLength(1))] == 'r')
                    {
                        neig += 1;
                    }

                    //Lower Line
                    if (world[Wrap(i + 1, world.GetLength(0)),
                        Wrap(j - 1, world.GetLength(1))] == 'r')
                    { neig += 1; }
                    if (world[Wrap(i + 1, world.GetLength(0)),
                        j] == 'r')
                    { neig += 1; }
                    if (world[Wrap(i + 1, world.GetLength(0)),
                        Wrap(j + 1, world.GetLength(1))] == 'r')
                    { neig += 1; }

                    // Verifie if all neighbours are rocks
                    if (neig >= 5)
                    {
                        Console.WriteLine("NEWROCK");
                        newWorld[i, j] = 'r';
                    }
                    else
                        newWorld[i, j] = 'g';

                }
            }
            return newWorld;
        }
        // Verifies the boundaries
        private static int Wrap(int pos, int max)
        {
            if (pos < 0)
            {
                return max - 1;
            }
            else if (pos >= max)
            {
                return 0;
            }
            return pos;
        }
        // Generates the first wolrd randomly
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
        // Prints whatever map it is given
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
