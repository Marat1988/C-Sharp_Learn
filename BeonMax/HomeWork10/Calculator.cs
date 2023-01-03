using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork10
{
    public class Calculator
    {
        public double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * b;
        }

        public double CalcTriangleSquare(double ab, double ac, int alpha)
        {
            double rads = alpha * Math.PI / 180;
            return 0.5 * ab * ac * Math.Sin(rads);
        }
    }
}
