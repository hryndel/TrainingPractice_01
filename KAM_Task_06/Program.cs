using System.Runtime.CompilerServices;

namespace KAM_Task_06
{
    internal class Program
    {
        static void Main()
        {
            string[] masWorkers = { };
            string[] masPosts = { };
            do
            {
                displayInterface();
                Console.Write("Напишите номер пункта: ");
                var userInput = int.TryParse(Console.ReadLine(), out var result);
                if (userInput) selectAction(result, ref masWorkers, ref masPosts);
                Console.Write("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            } while (true);

        }
        private static void displayInterface()
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт: ");
            Console.WriteLine("1) добавить досье. \n" +
                "2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале) \n" +
                "3) удалить досье \n" +
                "4) поиск по фамилии \n" +
                "5) выход\n");
        }
        private static void addDossierAndPost(ref string[] masWorkers, ref string[] masPosts)
        {
            string f_string = "Null";
            string i_string = "Null";
            string o_string = "Null";
            string post = "Null";
            Console.Write("Введите Имя: ");
            f_string = Console.ReadLine().Replace(" ", "");
            if (f_string == "") f_string = "Null";
            Console.Write("Введите Фамилию: ");
            i_string = Console.ReadLine().Replace(" ", "");
            if (i_string == "") i_string = "Null";
            Console.Write("Введите Отчество: ");
            o_string = Console.ReadLine().Replace(" ", "");
            if (o_string == "") o_string = "Null";
            Console.Write("Введите должность: ");
            post = Console.ReadLine().Replace(" ", "");
            if (post == "") post = "Null";
            Array.Resize(ref masWorkers, masWorkers.Length + 1);
            Array.Resize(ref masPosts, masPosts.Length + 1);
            masWorkers[masWorkers.Length - 1] = f_string + " " + i_string + " " + o_string;
            masPosts[masPosts.Length - 1] = post;
        }
        private static void deleteDossierAndPost(ref string[] masWorkers, ref string[] masPosts)
        {
            Console.Write("Введите id сотрудника, для удаления: ");
            try
            {
                int.TryParse(Console.ReadLine(), out var id);
                var list = new List<String>(masWorkers);
                list.RemoveAt(id - 1);
                masWorkers = list.ToArray();
                list = new List<string>(masPosts);
                list.RemoveAt(id - 1);
                masPosts = list.ToArray();
                Console.WriteLine($"Сотрудник с id {id} удален.");
            } catch { Console.WriteLine("Сотрудник не найден."); }
        }
        private static void findBySurname(string[] masWorkers, string[] masPosts)
        {
            Console.Write("Введите фамилию сотрудника, для поиска: ");
            var userInput = Console.ReadLine().Replace(" ", "");
            Console.WriteLine("Результат поиска: ");
            for (var i = 0; i < masWorkers.Length; i++)
            {
                if (masWorkers[i].Contains(userInput)) Console.WriteLine($"{i + 1} - {masWorkers[i]} - {masPosts[i]}");
            }
        }
        private static void showDossiers(string[] masWorkers, string[] masPosts)
        {
           for (var i = 0; i < masWorkers.Length; i++)
            {
                Console.WriteLine($"{i+1} - {masWorkers[i]} - {masPosts[i]}");
            }
        }
        private static void selectAction(int input, ref string[] masWorkers, ref string[] masPosts)
        {
            switch (input)
            {
                case 1: addDossierAndPost(ref masWorkers, ref masPosts);
                    break;
                case 2: showDossiers(masWorkers, masPosts);
                    break;
                case 3: deleteDossierAndPost(ref masWorkers, ref masPosts);
                    break;
                case 4: findBySurname(masWorkers, masPosts);
                    break;
                case 5: Environment.Exit(1);
                    break;
                default: Console.WriteLine("Неизвестная команда."); 
                    break;
            }
        }
    }
}