namespace KAM_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = 2;
            var userGold = 0;
            var userBuy = 0;
            try
            {
                Console.Write("Введите ваше количество золота: ");
                userGold = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Введите количество кристаллов к покупке по {price} золота: ");
                userBuy = Convert.ToInt32(Console.ReadLine());
                var result = userGold >= userBuy * price;
                Console.WriteLine($"Осталось золота: {userGold - (userBuy * price) * Convert.ToInt32(result)}");
                Console.WriteLine($"Количество кристаллов: {userBuy * Convert.ToInt32(result)}");
            } catch
            {
                Console.WriteLine("\nВведены некорректные данные! ");
                Console.WriteLine($"Осталось золота: {userGold}");
                Console.WriteLine($"Количество кристаллов: {userBuy}");
            }
        }
    }
}