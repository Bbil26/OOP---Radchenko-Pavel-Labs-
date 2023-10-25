namespace Welcome
{
    public class Start_Window
    {
        public static void Go()
        {
            Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

            for (int i = 0; i < 20; i++)
                Console.Write("__");

            Console.WriteLine("\nЛабораторная работа №7\nВариант 6 – Задание 1\n");
            Console.WriteLine("Реализовать поиск, добавление и удаление информации о расчетах за электроэнергию.");

            for (int i = 0; i < 20; i++)
                Console.Write("__");

            Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

            Console.ReadKey();
        }
    }
}