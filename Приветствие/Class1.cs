using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приветствие
{
    public class Welcome
    {
        public void Go()
        {
            Console.WriteLine("Работу Выполнил\nСтудент группы ИНС-21-1\nРадченко П.П.");

            for (int i = 0; i < 20; i++)
                Console.Write("__");

            Console.WriteLine("\nЛабораторная работа №3\nВариант 6 – Задание 1\n");
            Console.WriteLine("Дана исходная матрица размером M x N. " +
                "\nВывести исходную матрицу. Вывести максимальный элемент " +
                "\nматрицы и результирующую матрицу, в которой все элементы, " +
                "\nбольшие среднего арифметического, заменены на 0.");

            for (int i = 0; i < 20; i++)
                Console.Write("__");

            Console.WriteLine("\nДля продолжения нажмите на любую кнопку...");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
