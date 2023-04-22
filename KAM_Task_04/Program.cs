namespace KAM_Task_04
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();
            string[] UserSkills = { "Рашамон (Отнимает 10 хп игроку)", "Хуганзакура (Наносит 10 ед. урона) - После Рашамон",
                "Межпространственный разлом (Восстанавливает 25 хп. + урон босса по вам не проходит)",
                "Кефтен (Наносит 5 урона боссу)", "Мерба (Наносит 10 урона боссу, но наносит вам 5 урона) - После Кефтен" };
            int[] History = { -1 };

            int UserHP = random.Next(50, 150);
            int MaxUserHP = UserHP;
            int BossHP = random.Next(50, 150);
            int BossDamage = random.Next(5, 20);
            int i;

            Console.Write("Вы – теневой маг и у вас в арсенале есть несколько заклинаний," +
                " которые вы можете использовать против Босса. Вы должны уничтожить босса и только после этого будет вам покой.\n" +
                "\nУ вас есть 5 заклинаний:\n" +
                "* Рашамон – призывает теневого духа для нанесения атаки (Отнимает 10 хп игроку).\n" +
                "* Хуганзакура - может быть выполнен только после призыва теневого духа (Наносит 10 ед. урона).\n" +
                "* Межпространственный разлом – позволяет скрыться в разломе (Восстанавливает 25 хп. + урон босса по вам не проходит).\n" +
                "* Кефтен – наносит физический урон (Наносит 5 урона боссу).\n" +
                "* Мерба – позволяет произвести комбо удар после Кефтен'а (Наносит 10 урона боссу, но наносит вам 5 урона).\n" +
                $"\nКаждый ход босс наносит урон в размере {BossDamage} HP.\n");

            FistMotion(random, ref UserHP, BossDamage);
            do
            {
                DisplaySkills(UserSkills);
                DisplayHealth(UserHP, BossHP);
                do
                {
                    Console.Write("Введите номер навыка: ");
                } while (!int.TryParse(Console.ReadLine(), out i));
                CalculateHealth(i, ref UserHP, ref BossHP, BossDamage, MaxUserHP, ref History);
            } while (Winner(UserHP, BossHP));
        }
        private static void FistMotion(Random random, ref int UserHP, int BossDamage)
        {
            if (random.Next(2) == 1)
            {
                UserHP -= BossDamage;
                Console.WriteLine($"\nПервый ход достался Боссу! Он уже снял вам {BossDamage} HP.");
            }
        }

        private static void DisplaySkills(string[] UserSkills)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("\nВыберите действие: ");
            for (int i = 0; i < UserSkills.Length; i++)
            {
                Console.WriteLine(" " + i + " " + UserSkills[i]);
            }
        }

        private static void DisplayHealth(int UserHP, int BossHP)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($" Ваше HP\t|\tБосса HP");
            Console.WriteLine($" {UserHP} HP\t\t|\t{BossHP} HP");
            Console.WriteLine(new string('-', 40));
        }

        private static void CalculateHealth(int i, ref int UserHP, ref int BossHP, int BossDamage, int MaxUserHP, ref int[] History)
        {
            switch (i)
            {
                case 0:
                    UserHP -= 10;
                    break;
                case 1:
                    if (History.Last() == 0) BossHP -= 10;
                    else Console.WriteLine("Навык не удалось использовать, вы пропустили ход.");
                    break;
                case 2:
                    UserHP += 25;
                    if (UserHP > MaxUserHP) UserHP = MaxUserHP;
                    else Console.WriteLine("Навык не удалось использовать, вы пропустили ход.");
                    History[History.Length - 1] = i;
                    return;
                case 3:
                    BossHP -= 5;
                    break;
                case 4:
                    if (History.Last() == 3) BossHP -= 10;
                    else Console.WriteLine("Навык не удалось использовать, вы пропустили ход.");
                    UserHP -= 5;
                    break;
                default: return;
            }
            UserHP -= BossDamage;
            History[History.Length - 1] = i;
        }

        private static bool Winner(int UserHP, int BossHP)
        {
            if (UserHP <= 0 || BossHP <= 0)
            {
                if (UserHP <= 0) Console.WriteLine("\nИгра окончена, вы проиграли!");
                else Console.WriteLine("\nИгра окончена, вы выиграли!");
                return false;
            }
            else return true;
        }
    }
}