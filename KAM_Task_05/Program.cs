namespace KAM_Task_05
{
    internal class Program
    {
        static string[] MapFile = File.ReadAllLines(@"..\..\..\Map.txt");
        static char[,] Map = new char[21, 21];
        static int playerX = 0;
        static int playerY = 0;
        static int endX = 0;
        static int endY = 0;
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
            Console.SetCursorPosition(x - 7, 4);
            Console.Write("Нажатие клавиши TAB отобразит путь.\n");
            ReadMap();
            Draw(x, y, false);
            Movement(x, y);
            Console.ReadKey();
        }
        private static void ReadMap()
        {
            for (var i = 0; i < 21; i++)
                for (var j = 0; j < 21; j++)
                {
                    Map[i, j] = MapFile[i][j];
                    if (Map[i, j] == '3')
                    {
                        playerX = j;
                        playerY = i;
                    }
                    if (Map[i, j] == '4')
                    {
                        endX = j;
                        endY = i;
                    }
                }
        }
        private static void Draw(int sx, int sy, bool check)
        {
            for (var i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(sx, sy++);
                string line = "";
                for (var j = 0; j < 21; j++)
                {
                    switch (Map[i, j])
                    {
                        case '0':
                            line += "█";
                            break;
                        case '1':
                            line += " ";
                            break;
                        case '3':
                            line += "☻";
                            break;
                        case '4':
                            line += "▒";
                            break;
                        case '5':
                            if (check) line += "▪";
                            else line += " ";
                            break;
                    }
                }
                Console.WriteLine(line);
            }
        }
        private static void Movement(int x, int y)
        {
            bool showWay = false;
            ConsoleKey Move;
            while ((Move = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
                switch (Move)
                {
                    case ConsoleKey.W:
                        if (Map[playerY - 1, playerX] != '0')
                        {
                            Map[playerY, playerX] = Map[playerY - 1, playerX];
                            Map[playerY - 1, playerX] = '3';
                            playerY--;
                        }
                        break;
                    case ConsoleKey.A:
                        if (Map[playerY, playerX - 1] != '0')
                        {
                            Map[playerY, playerX] = Map[playerY, playerX - 1];
                            Map[playerY, playerX - 1] = '3';
                            playerX--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (Map[playerY + 1, playerX] != '0')
                        {
                            Map[playerY, playerX] = Map[playerY + 1, playerX];
                            Map[playerY + 1, playerX] = '3';
                            playerY++;
                        }
                        break;
                    case ConsoleKey.D:
                        if (Map[playerY, playerX + 1] != '0')
                        {
                            Map[playerY, playerX] = Map[playerY, playerX + 1];
                            Map[playerY, playerX + 1] = '3';
                            playerX++;
                        }
                        break;
                    case ConsoleKey.Tab:
                        showWay = true;
                        break;
                }
                if (playerY == endY && playerX == endX)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
                    Console.Write("█Вы прошли лабиринт!");
                    break;
                }
                Draw(x, y, showWay);
            }
        }
    }
}