using System.Reflection;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nЛабораторная работа №2\nВариант 6 – Задание 1\n");
Console.WriteLine("Электронный журнал учебного заведения");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

Console.ReadKey();
Console.Clear();
///////////////////////////////////////////////////////////////////
///

string lineMainWindow = "1 - Добавить нового ученика\n" +
                        "2 - Изменить оценки по предмету\n" +
                        "3 - Удалить ученика\n" + 
                        "4 - Вывести список класса\n" +
                        "0 - Выход из программы";

string lineSubjects = "1 - Физика\n" +
                      "2 - Русский язык\n" +
                      "3 - Математика";

string lineMarks = "1 - Добавить оценки\n" +
                   "2 - Изменить оценки";

//////////////////////////////////////////////////////////////////
///
List<Student> listTask = new List<Student>();

int flagFinalProgram = 0;
int id = 0;

while (flagFinalProgram == 0)
{
    Console.Clear();

    Console.WriteLine(lineMainWindow);
    char userKey = Console.ReadKey().KeyChar;
    switch (userKey)
    {
        case '1' :
            {
                Console.Clear();

                string tempLine = "";
                string name = string.Empty;
                string className = string.Empty;
                IEnumerable<int> markMath= new List<int>();
                IEnumerable<int> markPhys = new List<int>();
                IEnumerable<int> markRus = new List<int>();
                
                Console.Write("Введите имя ученика...\n> "); 
                name = Console.ReadLine();

                Console.Write("Введите класс...\n> ");
                className = Console.ReadLine();

                Console.Write("Введите оценки через пробел (без запятых) " +
                    "\nпо Математике (можно оставить пустым)...\n> ");
                //Считываем строку
                tempLine = Console.ReadLine();

                //удаляем двоичные пробелы
                while (tempLine.Contains("  "))
                    tempLine = tempLine.Replace("  ", " ");
                //потом через Trim() убираем пробелы на концах строки

                if (tempLine != "")
                    markMath = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();

                Console.Write("Введите оценки через пробел (без запятых) " +
                    "\nпо Физике (можно оставить пустым)...\n> ");
                tempLine = Console.ReadLine();

                while (tempLine.Contains("  "))
                    tempLine = tempLine.Replace("  ", " ");

                if (tempLine != "")
                    markPhys = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();

                Console.Write("Введите оценки через пробел (без запятых) " +
                    "\nпо Русскому языку (можно оставить пустым)...\n> ");
                tempLine = Console.ReadLine();

                while (tempLine.Contains("  "))
                    tempLine = tempLine.Replace("  ", " ");

                if (tempLine != "")
                    markRus = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();

                Console.WriteLine("Введенные данные верны? 1/0");

                if (Console.ReadKey().KeyChar == '1')
                {
                    listTask.Add(new Student(id, name, className, markMath, markRus, markPhys));
                    id++;
                }
                break;
            }
        case '2':
            {
                int currentID;

                Console.Clear();
                Console.Write("Введите ID ученика\n> ");
                

                if (int.TryParse(Console.ReadLine(), out currentID) && listTask.Exists(x => x.ID == currentID))
                {
                    Console.WriteLine(lineSubjects);
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1': 
                            {
                                string tempLine;

                                Console.Clear();
                                Console.WriteLine("Введите измененный список оценок через пробел");
                                tempLine = Console.ReadLine();

                                while (tempLine.Contains("  "))
                                    tempLine = tempLine.Replace("  ", " ");

                                if (tempLine != "")
                                    listTask.Find(x => x.ID == currentID).markPhys = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();
                                break; 
                            }
                        case '2':
                            {
                                string tempLine;

                                Console.Clear();
                                Console.WriteLine("Введите измененный список оценок через пробел");
                                tempLine = Console.ReadLine();

                                while (tempLine.Contains("  "))
                                    tempLine = tempLine.Replace("  ", " ");

                                if (tempLine != "")
                                    listTask.Find(x => x.ID == currentID).markRusLang = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();
                                break;
                            }
                        case '3':
                            {
                                string tempLine;

                                Console.Clear();
                                Console.WriteLine("Введите измененный список оценок через пробел");
                                tempLine = Console.ReadLine();

                                while (tempLine.Contains("  "))
                                    tempLine = tempLine.Replace("  ", " ");

                                if (tempLine != "")
                                    listTask.Find(x => x.ID == currentID).markMath = tempLine.Trim().Split(' ').Select(int.Parse).ToArray();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Введен неверный номер предметва!");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Введено не число!");
                    Console.ReadKey();
                }
                
                break;
            }
        case '3':
            {
                int currentID;

                Console.Clear();
                Console.Write("Введите ID ученика\n> ");


                if (int.TryParse(Console.ReadLine(), out currentID) && listTask.Exists(x => x.ID == currentID))
                {
                    listTask.Remove(listTask.Find(x => x.ID == currentID));
                    Console.WriteLine("Запись удалена!");
                    Console.ReadKey();
                }
                    break;
            }
        case '4':
            {
                Console.Clear();

                foreach (var item in listTask)
                {
                    Console.WriteLine($"{item.getStudentInfo()} \n ___________________________________________\n");
                }

                Console.ReadKey();
                break;
            }
        case '0' : 
            flagFinalProgram = 1; break;
    }
}


class Student
{
    public int ID { get; }
    string Name;
    string ClassName;
    public IEnumerable<int> markMath { get; set; }
    public IEnumerable<int> markRusLang { get; set; }
    public IEnumerable<int> markPhys { get; set; }

    public Student(int id, string name, string classname, IEnumerable<int> markmath, IEnumerable<int> markrus, IEnumerable<int> markphys )
    {
        ID = id;
        Name = name;
        ClassName = classname;
        markMath = markmath;
        markRusLang = markrus;
        markPhys = markphys;
    }

    public string getStudentInfo()
    {
        double avgRus;
        double avgPhys;
        double avgMath;

        if (markRusLang.Count() != 0)
            avgRus = markRusLang.Average();
        else 
            avgRus = 0;

        if (markPhys.Count() != 0)
            avgPhys = markPhys.Average();
        else
            avgPhys = 0;

        if (markMath.Count() != 0)
            avgMath = markMath.Average();
        else
            avgMath = 0;

        return $"ID: {ID}\n" + $"Имя: {Name}\t" + $"Класс: {ClassName}\n" +
            $"Средний Балл по Математике: {Math.Round(avgMath, 2)}\n" +
             $"Средний Балл по Русскому языку: {Math.Round(avgRus, 2)}\n" +
              $"Средний Балл по Физике: {Math.Round(avgPhys, 2)}";
    }
}