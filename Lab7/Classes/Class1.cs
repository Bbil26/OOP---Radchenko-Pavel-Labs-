namespace Classes
{
    enum Month
    {
        Январь,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }

    public class Person
    {
        string name;
        public float tarif;
        List<Electro> list_chek;

        //////////////////////////////////////////////////////////////////////////////
        //Словарь для более удобного обращения к enumn Month
        Dictionary<int, Month> dic_months = new Dictionary<int, Month>()
{
    {1, Month.Январь},
    {2, Month.Февраль},
    {3, Month.Март},
    {4, Month.Апрель},
    {5, Month.Май},
    {6, Month.Июнь},
    {7, Month.Июль},
    {8, Month.Август},
    {9, Month.Сентябрь},
    {10, Month.Октябрь},
    {11, Month.Ноябрь},
    {12, Month.Декабрь}
};
        //////////////////////////////////////////////////////////////////////////////
        public Person(string n, float t)
        {
            list_chek = new List<Electro>();
            name = n;
            tarif = t;
        }

        public void Get_Peson_Info() //Выводит всех Абонентов
        {
            Console.WriteLine("\b{0,10} - [Тариф: {1,4}]", name, tarif);
        }

        public void Get_ElectoList_Of_Person_Info() //Выводит список всех рачетных периодов выбранного абонента
        {
            Console.Clear();

            Console.WriteLine("{0,10} {1,8} {2,12} {3, 8}", "[Месяц]", "[Год]", "[Показания]", "[Оплата]");
            foreach (Electro p in list_chek)
            {
                for (int i = 0; i < 2; i++) Console.Write("---------------------");
                Console.Write("-");
                Console.WriteLine();
                Console.WriteLine(" {0, 9} |{1, 6}г. |{2, 8} | {3, 5} {4, 4}", p.Get_Month(), p.Get_Year(), p.Get_Reading(), Math.Round(p.Get_Cost(), 2), "|");
            }
        }

        public void Add_Period_From_File(int temp_reading, int temp_year, int temp_month)
        {
                list_chek.Add(new Electro(
                    temp_reading,
                    temp_year,
                    dic_months[temp_month],
                    CalculateCost(temp_reading, temp_month, temp_year)
                    ));
        }

        public void Add_Period()
        {
            int temp_month;
            int temp_reading;
            int temp_year;
            Console.Clear();

            //Ввод данных
            while (true)
            {
                Console.Write("Введите год расчетного периода...\n" +
                              "Или '0' для выхода...\n> ");

                if (int.TryParse(Console.ReadLine(), out temp_year))
                {
                    break;
                }
                else { Console.WriteLine("Введенное значение неверного формата!\n"); }
            }
            if (temp_year == 0) return;

            while (true)
            {
                Console.Write("Введите месяц расчетного периода...\n" +
                    "Или '0' для выхода...\n> ");

                if (int.TryParse(Console.ReadLine(), out temp_month) && temp_month >= 0 && temp_month < 13)
                {
                    break;
                }
                else { Console.WriteLine("Введенное значение неверного формата!\n"); }
            }

            if (temp_month == 0) return;
            while (true)
            {
                Console.Write("Введите текущие показания...\n> ");

                if (int.TryParse(Console.ReadLine(), out temp_reading))
                {
                    break;
                }
                else { Console.WriteLine("Введенное значение неверного формата!\n"); }
            }

            //Внесение данных
            Console.WriteLine("_________________________________\nВведенные данные верны? - [1/0]");

            if (Console.ReadKey().KeyChar == '1')
            {
                if (!list_chek.Exists(s => s.Get_Year() == temp_year && s.Get_Month() == dic_months[temp_month]))
                {
                    list_chek.Add(new Electro(
                        temp_reading,
                        temp_year,
                        dic_months[temp_month],
                        CalculateCost(temp_reading, temp_month, temp_year)
                        ));
                    Console.WriteLine("\bУспешное добавление расчетного периода!");
                }
                else
                {
                    Console.WriteLine("\bВыбранный расчетный период уже существует в списке!");
                }

            }
            else Console.WriteLine("\bВведенные данные не были сохранены!");

            Console.ReadKey();
        }

        public void Remove_Period()
        {
            int temp_year = -1;
            int temp_month = -1;
            int flag = 1; //Флаг для возможности выхода из операции
            Console.Clear();

            //Ввод данных
            while (flag == 1)
            {
                Console.Write("Введите год расчетного периода для удаления... \nЛибо '0' для выхода из теущей операции\n> ");

                if (int.TryParse(Console.ReadLine(), out temp_year))
                {
                    if (temp_year == 0) flag = 0;
                    break;
                }
                else { Console.WriteLine("Введенное значение неверного формата!\n"); }
            }
            
            while (flag == 1)
            {
                Console.Write("Введите месяц расчетного периода  для удаления...\nЛибо '0' для выхода из теущей операции\n> ");

                if (int.TryParse(Console.ReadLine(), out temp_month) && temp_month >= 0 && temp_month < 13)
                {
                    if (temp_month == 0) flag = 0;
                    break;
                }
                else { Console.WriteLine("Введенное значение неверного формата!\n"); }
            }

            if (flag != 0) //Проверка на желание досрочного выхода из операции
            {              //Если запись существует - удаляем
                if (list_chek.Exists(p => p.Get_Month() == dic_months[temp_month] && p.Get_Year() == temp_year))
                {
                    Console.WriteLine($"Вы действительно хотите удалить запись <{dic_months[temp_month]} - {temp_year} г.>? [1/0]");

                    if (Console.ReadKey().KeyChar == '1')
                    {
                        list_chek.Remove(list_chek.Find(p => p.Get_Month() == dic_months[temp_month] && p.Get_Year() == temp_year));
                    }
                }
                else
                {
                    Console.WriteLine("Не существует данного расчетного периода!");
                }
            }

        }

        float CalculateCost(int cur_reading, int mon, int y)
        {
            int prew_reading = 0;

            if (mon == 1)
            {
                mon = 12;
                y--;
            }
            else
            {
                mon--;
            };

            if (list_chek.Exists(p => p.Get_Month() == dic_months[mon] && p.Get_Year() == y))
            {
                prew_reading = list_chek.Find(p => p.Get_Month() == dic_months[mon] && p.Get_Year() == y).Get_Reading();
            }
            return (cur_reading - prew_reading) * tarif;
        }
    }
    class Electro
    {
        Month month;
        int year;
        int cur_reading;
        float cost;

        public Electro(int r, int y, Month m, float c)
        {
            cur_reading = r;
            month = m;
            year = y;
            cost = c;
        }

        public int Get_Reading()
        { return cur_reading; }

        public int Get_Year()
        { return year; }

        public Month Get_Month()
        { return month; }

        public float Get_Cost()
        { return cost; }
    }
}