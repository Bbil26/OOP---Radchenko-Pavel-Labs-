using System;

Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

for (int i = 0; i < 20; i++) 
    Console.Write("__");

Console.WriteLine("\nВариант 6 – Задание 1\n");
Console.WriteLine("Пользователь вводит случайные числа,\nзатем программа выводит список чисел, в котором:\n" +
    " 0 - больше Сред.Ариф.\n 1 - меньше Сред.Ариф.\n-1 - в отсальных случаях");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

Console.ReadKey();
Console.Clear();


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