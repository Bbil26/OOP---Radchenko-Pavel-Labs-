using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicArray
    {
        public int[,] Create(int[,]array, int M, int N)
        {
            Random randomNum = new Random();

            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    array[i, j] = randomNum.Next() % 200 - 100;
                }
            return array;
        }

        public void ArrayOut(int[,] array, int M, int N)
        {
            LineOut(N);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(string.Format($"{array[i, j],4} "));
                }
                Console.WriteLine();
            }
            LineOut(N); 
        }

        public void ArrayResultOut(int[,] array, int M, int N)
        {
            LineOut(N);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // Cast<>() нужен для представления массива в IEnumerable для использования вложенных методов, в данном случае Avg()
                    if (array[i, j] < array.Cast<int>().Average())         // Если больше среднего арифметического - выводим элемент
                        Console.Write(string.Format($"{array[i, j],4} ")); 
                    else 
                        Console.Write(string.Format($"{0,4} "));           // Иначе выводиим 0
                }
                Console.WriteLine();
            }
            LineOut(N);
        }

        private void LineOut(int N)
        {
            for (int i = 0; i < N; i++)
                Console.Write("-----");
            Console.WriteLine();
        }

        
    }
}
