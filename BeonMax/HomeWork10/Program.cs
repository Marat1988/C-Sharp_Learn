using System;


/*Добавить перегрузку, которая принимает длины двух смежных сторон (double) и величину угла между ними. Величину угла принимать как int.
 * Метод должен рассчитывать площадь по формуле: 0.5 * ab * ac * sin(alpha)*/
namespace HomeWork10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character c = new Character();
            //c.Hit(120);

            //Console.WriteLine(c.Health);

            Calculator calc = new Calculator();
            double square1 = calc.CalcTriangleSquare(10, 20);
            double square2 = calc.CalcTriangleSquare(40, 20, 30);

            double square3 = calc.CalcTriangleSquare(10, 20, 50);

            Console.WriteLine($"Square3={square3}");
        }
    }
}
