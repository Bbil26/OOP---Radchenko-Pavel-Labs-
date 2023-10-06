using System.Reflection;

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
                tempLine = Console.ReadLine();
                if (tempLine != "")
                    markMath = tempLine.Split(' ').Select(int.Parse).ToArray();

                Console.Write("Введите оценки через пробел (без запятых) " +
                    "\nпо Физике (можно оставить пустым)...\n> ");
                tempLine = Console.ReadLine();
                if (tempLine != "")
                    markPhys = tempLine.Split(' ').Select(int.Parse).ToArray();

                Console.Write("Введите оценки через пробел (без запятых) " +
                    "\nпо Русскому языку (можно оставить пустым)...\n> ");
                tempLine = Console.ReadLine();
                if (tempLine != "")
                    markRus = tempLine.Split(' ').Select(int.Parse).ToArray();

                Console.WriteLine("Введенные данные верны? 1/0");

                if (Console.ReadKey().KeyChar == '1')
                {
                    listTask.Add(new Student(id, name, className, markMath, markRus, markPhys));
                    id++;
                    Console.WriteLine(listTask[0].getStudentInfo());
                    Console.ReadKey();
                }
                break;
            }
        case '2':
            {
                int currentID;
                int currnetOperation;

                Console.Clear();
                Console.WriteLine("Введите ID ученика\n>");
                

                if (int.TryParse(Console.ReadLine(), out currentID) && listTask.Exists(x => x.ID == currentID))
                {
                    Console.WriteLine(lineSubjects);
                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1': 
                            {
                                var l = listTask.Where(x => x.ID == currentID);
                                break; 
                            }
                        case '2':
                            {

                                break;
                            }
                        case '3':
                            {

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
                break;
            }
        case '4':
            {
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
            $"Средний Балл по Математике: {avgMath}\n" +
             $"Средний Балл по Русскому языку: {avgRus}\n" +
              $"Средний Балл по Физике: {avgPhys}";
    }
}