using System;

/*Запросить у пользователя два целочисленных значения и найти максимальное.*/

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            //1-st
            //int max = a;
            //if (b > a)
            //{
            //    max = b;
            //}
            //Console.WriteLine(max);

            //2nd
            //int max;
            //if (a > b)
            //{
            //    max = a;
            //}
            //else
            //{
            //    max = b;
            //}

            int max = a > b ? a : b;
            Console.WriteLine($"Max = {max}");
        }
    }
}
