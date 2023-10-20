Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nЛабораторная работа №5\nВариант 6 – Задание 1\n");
Console.WriteLine("Реализовать Интерфейсы");

for (int i = 0; i < 20; i++)
    Console.Write("__");

Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

Console.ReadKey();
/// ///////////////////////////////////////////////////////////////////////////

Weapons w = new Weapons();
Firearms f = new Firearms();
Airplane a = new Airplane();
Tank t = new Tank();

Tank player1;
Tank player2;

/// ///////////////////////////////////////////////////////////////////////////


int flag = 1;
while (flag == 1)
{
    Console.Clear();
    Console.WriteLine("Меню: \n" +
                  "1 - Вооружение\n" +
                  "2 - Стрелковое оружее\n" +
                  "3 - Танк\n" +
                  "4 - Самолет\n" +
                  "5 - Мини-игра\n" +
                  "0 - Выход");

    switch (Console.ReadKey().KeyChar)
    {
        case '1':
            {
                Console.Clear();
                w.Information();
                Console.ReadKey();
                break;
            }
        case '2':
            {
                Console.Clear();
                f.Information();
                Console.ReadKey();
                break;
            }
        case '3':
            {
                Console.Clear();
                t.Information();
                Console.ReadKey();
                break;
            }
        case '4':
            {
                Console.Clear();
                a.Information();
                Console.ReadKey();
                break;
            }
        case '5':
            {
                //Обнуляем для возможности повторного запуска игры
                player1 = null;
                player2 = null;


                while (flag == 1)
                {
                    Console.Clear();
                    Console.Write("Выберите такнк для ");

                    if (player1 == null)
                        Console.Write("первого ");
                    else Console.Write("второго ");

                    Console.WriteLine("игрока: \n" +
                                      "1 - Танк Т-72\n" +
                                      "2 - Танк Т-80\n" +
                                      "3 - Танк Т-90\n");

                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            {
                                //Добавляем по очереди в переменные созданные классы
                                if (player1 == null) player1 = new T_72();
                                else player2 = new T_72();

                                if (player1 != null && player2 != null) flag = 0;
                                break;
                            }
                        case '2':
                            {
                                if (player1 == null) player1 = new T_80();
                                else player2 = new T_80();

                                if (player1 != null && player2 != null) flag = 0;
                                break;
                            }
                        case '3':
                            {
                                if (player1 == null) player1 = new T_90();
                                else player2 = new T_90();

                                if (player1 != null && player2 != null) flag = 0;
                                break;
                            }
                    }
                }
                flag = 1;

                Console.Clear();

                Console.WriteLine($"Игрок 1 - {player1.name} - {player1.hp} ХП\t\t" +
                                  $"Игрок 2 - {player2.name} - {player2.hp} ХП\n");

                while (player1.hp > 0 && player2.hp > 0)
                {
                    // \b - нужен для удаления из консоли лишнего символа от ReadKey() 

                    player1.GetDmg(player2.dmg);
                    player2.GetDmg(player1.dmg);

                    for (int i = 0; i < 10; i++) Console.Write("______");
                    Console.WriteLine();
                    Console.WriteLine($"\bИгрок 1 - {player1.name} - {player1.hp} ХП\t\t" +
                                      $"Игрок 2 - {player2.name} - {player2.hp} ХП\n");

                    Console.ReadKey();

                }

                if (player1.hp <= 0 && player2.hp <= 0) Console.WriteLine("\bНичья");
                else if (player1.hp > 0) Console.WriteLine("\bПобедил Первый игрок!");
                else if (player2.hp > 0) Console.WriteLine("\bПобедил Второй игрок!");

                Console.ReadKey();
                break;
            }
        case '0':
            {
                Console.Clear();
                flag = 0;
                break;
            }
    }
}

class Weapons
{
    public void Information()
    {
        Console.WriteLine("Вещи, делающие \"Пиу-пиу\", \"Бах-бах\" и \"ву-у-у-у-у\"");
    }
}

class Firearms : Weapons
{
    public void Information()
    {
        Console.WriteLine("Железяка");
    }
}

class Tank : Weapons, IGame
{
    public string name { get; set; }
    public int armor { get; set; }
    public int dmg { get; set; }
    public int hp { get; set; }
    public void Information()
    {
        Console.WriteLine("Консервная банка на порохе");
    }

    public void GetDmg(int dmg)
    {
        int tempDmg;
        Random randomDmg = new Random();

        if ((tempDmg = randomDmg.Next(dmg)) <= armor)
        {
            Console.WriteLine($"Танк {name} - не пробит");
        }
        else
        {
            Console.WriteLine($"Танк {name} получил {tempDmg - armor} урона");
            hp -= tempDmg - armor;
        }
    }
}

class Airplane : Weapons
{
    public void Information()
    {
        Console.WriteLine("Такая же консервная банка, только по-тоньше");
    }
}

class T_72 : Tank
{
    public string nameTank = "Т-72";
    const int armor = 5;
    const int dmg = 16;
    int hp = 30;
    public T_72()
    {
        base.name = nameTank;
        base.hp = hp;
        base.armor = armor;
        base.dmg = dmg;
    }
}

class T_80 : Tank
{
    string nameTank = "Т-80";
    int armor = 5;
    int dmg = 18;
    int hp = 30;
    public T_80()
    {
        base.name = nameTank;
        base.hp = hp;
        base.armor = armor;
        base.dmg = dmg;
    }
}

class T_90 : Tank
{
    string nameTank = "Т-90";
    int armor = 6;
    int dmg = 20;
    int hp = 30;

    public T_90()
    {
        base.name = nameTank;
        base.hp = hp;
        base.armor = armor;
        base.dmg = dmg;
    }
}

interface IGame
{
    string name { get; set; }
    int armor { get; set; }
    int dmg { get; set; }
    int hp { get; set; }

    void GetDmg(int dmg);
}