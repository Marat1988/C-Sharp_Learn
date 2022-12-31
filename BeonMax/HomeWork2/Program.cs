using System;

namespace HomeWork2
{
    /*Запросить у пользователя длины трёх сторон треугольника.
     * Длины могут быть представлены дробными значениями.
     * После получения длин сторон - использовать формулу Герона для
     * вычисления площади треугольника.
     * Чтобы жизнь не казалась мёдом, найдите формулу самостоятельно.
     * После вычисления площади - вывести результат на консоль.*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's calculate the square of a triangle");
            Console.WriteLine("Enter the length of side AB:");
            double ab = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of side BC:");
            double bc = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of side AC:");
            double ac = double.Parse(Console.ReadLine());

            double p = (ab + bc + ac) / 2;

            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine($"Square of the triangle equals {square}");

        }
    }
}
