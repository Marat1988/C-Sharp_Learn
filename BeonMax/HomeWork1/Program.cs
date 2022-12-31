using System;

namespace HomeWork1
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
        }

        static void Task2()
        {
            Console.WriteLine("Enter an integer");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter an integer");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"a={a}, b={b}");
            int c = a;
            a = b;
            b = c;
            Console.WriteLine($"a={a}, b={b}");
        }

        static void Task3()
        {
            Console.WriteLine("Enter an integer");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"The number of digits: { number.ToString().Length}");
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
    }
}
