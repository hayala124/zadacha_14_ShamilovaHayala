namespace zadacha_14_ShamilovaHayala
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfSquare;
            do
            {
                Console.WriteLine("Введите НЕЧЁТНЫЙ размер квадрата: ");
                sizeOfSquare = int.Parse(Console.ReadLine());
            }
            while (sizeOfSquare % 2 == 0);

            Console.WriteLine("Введите интервал времени: ");
            int timeInterval = int.Parse(Console.ReadLine());

            int[,] grid = new int[sizeOfSquare, sizeOfSquare];
            grid[sizeOfSquare / 2, sizeOfSquare / 2] = 1;

            int infectionTime = 6;
            int immunityTime = 4;


            for (int t = 0; t < timeInterval; t++)
            {
                for (int i = 0; i < sizeOfSquare; i++)
                {
                    for (int j = 0; j < sizeOfSquare; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            if (t < infectionTime)
                            {
                                if (i > 0 && grid[i - 1, j] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i - 1, j] = 1;

                                if (i < sizeOfSquare - 1 && grid[i + 1, j] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i + 1, j] = 1;

                                if (j > 0 && grid[i, j - 1] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i, j - 1] = 1;

                                if (j < sizeOfSquare - 1 && grid[i, j + 1] == 0 && new Random().NextDouble() < 0.5)
                                    grid[i, j + 1] = 1;
                            }
                            else if (t >= infectionTime && t <= infectionTime + immunityTime)
                            {
                                grid[i, j] = 2;
                            }
                            else
                            {
                                grid[i, j] = 0;
                            }
                        }
                    }
                }

                Console.WriteLine($"Временной интервал {t}:");
                for (int i = 0; i < sizeOfSquare; i++)
                {
                    for (int j = 0; j < sizeOfSquare; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[X]");
                            Console.ResetColor(); 
                        }
                        else if (grid[i, j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[I]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[З]");
                            Console.ResetColor(); 
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}