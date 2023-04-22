namespace KAM_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] massiv = { 1, 2, 3, 4, 5 };
            Random random= new Random();
            Console.WriteLine("Исходный массив: " + string.Join(" ", massiv));
            for (var i = 0; i< massiv.Length; i++)
            {
                var index = random.Next(0, massiv.Length - 1);
                var buffer = massiv[i];
                massiv[i] = massiv[index];
                massiv[index] = buffer;
            }
            Console.WriteLine("Конечный массив: " + string.Join(" ", massiv));
        }
    }
}