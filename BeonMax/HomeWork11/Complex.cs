using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork11
{
    public class Complex
    {
        public double Imaginagy { get; private set; }
        public double Real { get; private set; }

        public Complex(double imagingy, double real)
        {
            this.Imaginagy = imagingy;
            this.Real = real;
        }

        private Complex() { }

        public Complex Plus(Complex other)
        {
            var complex = new Complex();
            complex.Imaginagy = other.Imaginagy + Imaginagy;
            complex.Real = other.Real + Real;
            return complex;
        }

        public Complex Minus(Complex other)
        {
            var complex = new Complex();
            complex.Imaginagy = other.Imaginagy - Imaginagy;
            other.Real = other.Real - Real;
            return complex;
        }

    }
}
