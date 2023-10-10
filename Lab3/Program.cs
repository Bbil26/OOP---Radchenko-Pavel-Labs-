using Logic;
using Приветствие;

LogicArray logicArray = new LogicArray();
new Welcome().Go();

int M = 0, N = 0;

// Ввод размерности массива
Console.Write("Введите размерность матрицы (1..10)...\nM > ");

// Тело цикла выполняется в том случае, если ввели {не число} либо {число x при x < 0 или x > 10}
while (!(int.TryParse(Console.ReadLine().Trim(), out M) && (M > 0 && M < 10))) 
{
    Console.Write("Введенное значение неверного формата! \nM > ");
}

Console.Write("Введите размерность матрицы (1..10)...\nN > ");

while (!(int.TryParse(Console.ReadLine().Trim(), out N) && (N > 0 && N < 10)))
{
    Console.Write("Введенное значение неверного формата! \nN > ");
}

//Объявление массива
int[,] array = new int[M,N];

//Заполнение массива
while(true)
{
    Console.Clear();
    array = logicArray.Create(array, M, N);

    Console.Write("Создаем заполнение матрицы");
    for(int i = 0; i < 3; i++)
    {
        Thread.Sleep(300);
        Console.Write('.');
    }
    Console.WriteLine();
    
    //Вывод массива
    logicArray.ArrayOut(array, M, N);

    Console.WriteLine("\nНажмите '1' для продолжения\nЛибо любую другую клавишу для пересоздания массива");

    if (Console.ReadKey().KeyChar == '1') break;
}

Console.Clear();

logicArray.ArrayOut(array, M, N);
Console.WriteLine($"\nМаксимальный элемент: {array.Cast<int>().Max()}" +
                  $"\nСреднее арифметическое: {Math.Round(array.Cast<int>().Average(), 1)}");

Console.WriteLine("Результирующая матрица: ");
logicArray.ArrayResultOut(array, M, N);
Console.ReadKey();