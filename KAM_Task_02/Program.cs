namespace KAM_Task_02
{
    internal class Program
    {
        private static void Main()
        {
            var userInput = "";
            do
            {
                Console.Write("Введите слово EXIT: ");
                userInput = Console.ReadLine();
            } while (!userInput.ToUpper().Equals("EXIT"));
        }
    }
}