namespace KAM_Task_03
{
    internal class Program
    {
        private static void Main()
        {
            var password = "123";
            for (var i = 0; i < 3; i++)
            {
                Console.Write("Введите пароль: ");
                if (Console.ReadLine() == password)
                {
                    Console.Write("\nСекретное сообщение\n");
                    return;
                }
            }
        }
    }
}