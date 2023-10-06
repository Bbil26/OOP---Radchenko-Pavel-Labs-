using System;
using System.Threading.Tasks;

Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

for (int i = 0; i < 20; i++) 
    Console.Write("__");

Console.WriteLine("\nЛабораторная работа №1\nВариант 6 – Задание 1\n");
Console.WriteLine("Пользователь вводит случайные числа,\nзатем программа выводит список чисел, в котором:\n" +
    " 0 - больше Сред.Ариф.\n 1 - меньше Сред.Ариф.\n-1 - в отсальных случаях");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

Console.ReadKey();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

while (true)
{
    Console.Clear();
    Console.WriteLine("1 - Статический метод\n2 - Экземплярный метод");

    char userKey = Console.ReadKey().KeyChar;
    Console.Clear();

    if (userKey == '2')
    {
        Console.WriteLine("Введите числа через пробел...");

        Obj task = new();

        Console.WriteLine();
        foreach (int item in task.arrNum)
        {
            if (item > task.medNum)
                Console.Write(0 + " ");
            else if (item < task.medNum)
                Console.Write(1 + " ");
            else
                Console.Write(-1 + " ");
        }
        
        Console.ReadKey();
        
        Console.Clear();
        Console.WriteLine("Повторить? 1/0");
        if (Console.ReadKey().KeyChar == '1')
            continue;
        else
            break;
    }

    if (userKey == '1')
    {
        List<int> listNumsStatic = ObjStat.inputNum();

        Console.WriteLine("Изначальный массив: \n");
        foreach(int item in listNumsStatic)
        {
            Console.Write($"{item, -3} ");
        }

        Console.WriteLine("\n\nИзмененный массив: \n");
        foreach (int item in ObjStat.outputNum(listNumsStatic))
        {
            Console.Write($"{item, -3} ");
        }
        
        Console.ReadKey();
        
        Console.Clear();
        Console.WriteLine("Повторить? 1/0");
        if (Console.ReadKey().KeyChar == '1')
            continue;
        else
            break;
    }
    else
    {
        continue;
    }
}

/// /////////////////////////////////////////////////////////////////////////////////////

class Obj
{
    public float medNum;
    public int countNum;
    public List<int> arrNum;

    public Obj()
    {
        arrNum = new();
        string[] tempLine = Console.ReadLine().Split(' ');

        for (int i = 0; i < tempLine.Length; i++)
        {
            if (tempLine[i] == "") continue;

            int tempNum;
            if (int.TryParse(tempLine[i], out tempNum))
                arrNum.Add(tempNum);
            else
            {
                Console.WriteLine("Введенные данные не являются натуральными числами!");
                arrNum.Clear();
                break;
            }
        }

        medNum = arrNum.Sum() / arrNum.Count;
    }
}

public static class ObjStat
{
    public static List<int> inputNum()
    {
        Random s = new Random();
        List<int> arrStat = new List<int>();

        for (int i = 0; i < 10; i++)
            arrStat.Add(s.Next() % 31);

        return arrStat;
    }

    public static List<int> outputNum(List<int> arrNum)
    {
        string str = string.Empty;
        for(int i = 0; i < arrNum.Count; i++)
        {
            if (arrNum[i] > arrNum.Average())
                arrNum[i] = 0;
            else if (arrNum[i] < arrNum.Average())
                arrNum[i] = 1;
            else
                arrNum[i] = -1;
        }
        return arrNum;
    }
}


