using Classes;
using System.Collections.Generic;
using Welcome;
Start_Window.Go();
//Создаем список всех абонентов
List<Person> listPerson = new List<Person>();
////////////////////////////////////////////////////////////////////////////////////
//Данные для примера будем считывать с файла
StreamReader sr = new StreamReader("../../../../Data7.txt");

for (int i = 0; i < 3 ; i++)
{
    string line = sr.ReadLine();
    listPerson.Add(new Person(line.Split()[0], Convert.ToSingle(line.Split()[1])));
}

for (int i = 0; i < 3; i++)
    for (int j = 0; j < 3; j++)
    {
        string line = sr.ReadLine();
        listPerson[i].Add_Period_From_File( Convert.ToInt32(line.Split()[2]), 
                                            Convert.ToInt32(line.Split()[0]), 
                                            Convert.ToInt32(line.Split()[1])
                                            );
    }

/////////////////////////////////////////////////////////////////////////////////////
int flag = 1;
while(flag == 1)
{
    Console.Clear();
    Console.WriteLine(" 1 - Вывести список Абонентов\n" +
                      " 2 - Добавить Абонента\n" +
                      " 3 - Выбрать Абонента\n" +
                      " 4 - Удалить Абонента\n" +
                      " 0 - Выход\n");

    switch(Console.ReadKey().KeyChar)
    {
        case '1':
            {
                Console.Clear();
                Person_Out();
                Console.ReadKey();
                break;
            }
        case '2':
            {
                string name;
                float tar;
                Console.Clear();
                Console.Write("Введите имя абонента...\n> ");
                name = Console.ReadLine();
                Console.Write("Введите тариф абонента...\n> ");

                if(Single.TryParse(Console.ReadLine(), out tar))
                {
                    listPerson.Add(new Person(name, tar));
                    Console.WriteLine("Пользователь успешно добавлен!");
                    
                }
                else Console.WriteLine("Ошибка ввода данных!");

                Console.ReadKey();
                break;
            }
        case '3':
            {
                Console.Clear();
                int cur_Person;

                Console.WriteLine("Выберите пользователя:");
                Person_Out();
                Console.Write("\nID: ");

                if (int.TryParse(Console.ReadLine(), out cur_Person) && cur_Person <= listPerson.Count && cur_Person > 0)
                {
                    while (flag == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(" 1 - Добавить показание\n" +
                                          " 2 - Удалить показание \n" +
                                          " 3 - Вывести список показаний\n" +
                                          " 0 - Назад");
                        switch(Console.ReadKey().KeyChar)
                        {
                            case '1': 
                                {
                                    listPerson[cur_Person - 1].Add_Period();
                                    break;
                                }
                            case '2':
                                {
                                    listPerson[cur_Person - 1].Remove_Period();
                                    break;
                                }
                            case '3':
                                {
                                    listPerson[cur_Person - 1].Get_ElectoList_Of_Person_Info();
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
                }
                else
                {
                    Console.WriteLine("Введенного Id не найдено!");
                    Console.ReadKey();
                }

                flag = 1;
                break;
            }
        case '4':
            {
                Console.Clear();
                Console.Write("Введите ID для удаления...\n> ");
                
                try 
                { 
                    listPerson.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                    Console.WriteLine("Абонент удален!");
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Указанного Id не найдено!");
                    Console.ReadKey();
                }
                break;
            }
        case '0':
            {
                flag = 0;
                break;
            }
    }
}

void Person_Out()
{
    int count = 1;
    foreach (Person p in listPerson)
    {
        Console.Write($"ID:{count} ");
        p.Get_Peson_Info();
        Console.WriteLine("--------------------------------");
        count++;
    }
}