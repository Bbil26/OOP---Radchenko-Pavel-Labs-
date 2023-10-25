Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nЛабораторная работа №6\nВариант 6 – Задание 1\n");
Console.WriteLine("Реализовать класс с использованием обобщенного типа. Объекты недвижимости.");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

Console.ReadKey();

//////////////////////////////////////////////////////////////////////////////

BuyHouse<House<int>> houseInt = new BuyHouse<House<int>>();
BuyHouse<House<float>> houseFloat = new BuyHouse<House<float>>();
BuyHouse<TradeHouse<int>> tradeHouseInt = new BuyHouse<TradeHouse<int>>();
BuyHouse<TradeHouse<float>> tradeHouseFloat = new BuyHouse<TradeHouse<float>>();

string success = "Объект успешно добавлен!";

float totalSquare;
int totalShops;
string lineInfo1;
string lineInfo2;

//////////////////////////////////////////////////////////////////////////////
///

while (true)
{
    totalShops = 0;
    totalSquare = 0f;

    foreach (House<int> item in houseInt.getOb())
        totalSquare += item.square;


    foreach (House<float> item in houseFloat.getOb())
        totalSquare += item.square;

    foreach (TradeHouse<int> item in tradeHouseInt.getOb())
    {
        totalSquare += item.square;
        totalShops += item.countOfShops;
    }

    foreach (TradeHouse<float> item in tradeHouseFloat.getOb())
    {
        totalSquare += item.square;
        totalShops += item.countOfShops;
    }

    lineInfo1 = $"Общая Площадь: {Math.Round(totalSquare, 2)} кв.м";
    lineInfo2 = $"Всего Магазинов: {totalShops} шт.";

    Console.Clear();
    Console.WriteLine("\t\t     Калькулятор подсчета площади недвижимости.");
    Console.Write(" ");
    for (int i = 0; i < 79; i++) Console.Write("_");
    Console.Write(string.Format("\n|{0,80}", "|"));
    Console.Write(string.Format("{0,30}{1,63}", "\n| 1 - Добавить дом", "|"));
    Console.Write(string.Format("{0,30}{1,64}", "\n| 2 - Добавить ТЦ", "|"));
    Console.Write(string.Format("{0,30}{1,70}", "\n| 0 - Выход ", "|\n"));
    Console.Write("|");
    for (int i = 0; i < 79; i++) Console.Write("_");
    Console.Write("|\n");

    Console.WriteLine(string.Format("{2}{0,35}{2,5}{1,35}{2,5}", lineInfo1 , lineInfo2, "|"));
    char tet = Console.ReadKey().KeyChar;
    //////////////////////////////////////////////////////////////////////////////
    if (tet == '1')
    {
        int tempInt;
        float tempFloat;
        
        Console.Clear();
        Console.Write("Введите площадь дома > ");
        string tempLine = Console.ReadLine();

        if (float.TryParse(tempLine, out tempFloat))
        {
            houseFloat.AddOb(new House<float>(tempFloat));
            Console.WriteLine(success);
        }
        else if (int.TryParse(tempLine, out tempInt))
        {
            houseInt.AddOb(new House<int>(tempInt));
            Console.WriteLine(success);
        }
        else Console.WriteLine("Введена неверная величина для площади!");
        
        Console.ReadKey();
    }
    //////////////////////////////////////////////////////////////////////////////
    else if (tet == '2')
    {
        int tempCount;
        int tempInt;
        float tempFloat;

        Console.Clear();
        Console.Write("Введите площадь ТЦ > ");
        string tempLine1 = Console.ReadLine();

        Console.Write("Введите количество магазинов в ТЦ > ");
        string tempLine2 = Console.ReadLine();

        if (float.TryParse(tempLine1, out tempFloat) && int.TryParse(tempLine2, out tempCount))
        {
            tradeHouseFloat.AddOb(new TradeHouse<float>(tempFloat, tempCount));
            Console.WriteLine(success);
        }
        else if (int.TryParse(tempLine1, out tempInt) && int.TryParse(tempLine2, out tempCount))
        {
            tradeHouseInt.AddOb(new TradeHouse<int>(tempInt, tempCount));
            Console.WriteLine(success);
        }
        else Console.WriteLine("Введена неверная величина для площади или количества магазинов!");

        Console.ReadKey();
    }
    //////////////////////////////////////////////////////////////////////////////
    else if (tet == '0')
    {
        Console.Clear();
        break;
    }
}

/// ///////////////////////////////////////////////////////////////////
class House<T>
{
    public T square;

    public House(T sq)
    {
        square = sq;
    }
}
/// ///////////////////////////////////////////////////////////////////
class TradeHouse<T>
{
    public T square;
    public int countOfShops;

    public TradeHouse(T sq, int count)
    {
        square = sq;
        countOfShops = count;
    }
}
/// ///////////////////////////////////////////////////////////////////
class BuyHouse<T>
{
    List<T> list;

    public BuyHouse()
    {
        list = new();
    }

    public void AddOb(T obj)
    {
        list.Add( obj );
    }

    public List<T> getOb()
    {
        return list;
    }
}