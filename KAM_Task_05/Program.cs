namespace KAM_Task_05
{
    internal class Program
    {
        static string[] MapFile = File.ReadAllLines(@"..\..\..\Map.txt");
        static int playerX = 0;
        static int playerY = 0;
        static char[,] Map = new char[21, 21];
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            var y = Console.WindowHeight / 2 - 10;
            var x = Console.WindowWidth / 2 - 10;
            Console.SetCursorPosition(x - 4, 1);
            Console.Write("Добро пожаловать в лабиринт!");
            Console.SetCursorPosition(x + 2, 2);
            Console.Write("Двигаться на WASD.");
            Console.SetCursorPosition(x - 12, 3);
            Console.Write("Чтобы закончить игру нажмите два раза Enter.\n");
            var ex = 0;
            var ey = 0;

            Draw(x, y);
            Movement(x, y, ex, ey);
            Console.ReadKey();
        }

        static void Draw(int sx, int sy)
        {
            for (var i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(sx, sy++);
                string line = "";
                for (var j = 0; j < 21; j++)
                {
                    Map[i, j] = MapFile[i][j];
                    switch (Map[i, j])
                    {
                        case '0':
                            line += "█";
                            break;
                        case '1':
                            line += " ";
                            break;
                        case '3':
                            //sx = x + j;
                            //sy = y - 1;
                            playerX = j;
                            playerY = i;
                            line += "☻";
                            break;
                        case '4':
                            //ex = x + j;
                            //ey = y - 1;
                            line += "▒";
                            break;
                        case '5':
                            line += " ";
                            break;
                    }
                }
                Console.WriteLine(line);
            }
        }
        static void Movement(int x, int y, int ex, int ey)
        {
            var i = playerY;
            var j = playerX;
            Console.SetCursorPosition(x, y);
            ConsoleKey Move;
            Move = Console.ReadKey(true).Key;
            while ((Move = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                switch (Move)
                {
                    case ConsoleKey.W:
                        if (Map[i - 1, j] != '0')
                        {
                            Map[i, j] = Map[i - 1, j];
                            Map[i - 1, j] = '3';
                            i--;
                        }
                        break;
                    case ConsoleKey.A:
                        if (Map[i, j - 1] != '0')
                        {
                            Map[i, j] = Map[i, j - 1];
                            Map[i, j - 1] = '3';
                            j--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (Map[i + 1, j] != '0')
                        {
                            Map[i, j] = Map[i + 1, j];
                            Map[i + 1, j] = '3';
                            i++;
                        }
                        break;
                    case ConsoleKey.D:
                        if (Map[i, j + 1] != '0')
                        {
                            Map[i, j] = Map[i, j + 1];
                            Map[i, j + 1] = '3';
                            j++;
                        }
                        break;
                }
                Draw(x, y);
                if (x == ex && y == ey)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
                    Console.Write("█Вы прошли лабиринт!");
                    break;
                }
            }
        }
    }
}