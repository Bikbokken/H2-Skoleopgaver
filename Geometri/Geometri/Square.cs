using Geometri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geometri
{
    public abstract class Figure
    {
        protected double _a = 0;

        public abstract double Areal();
        public abstract double Perimeter();

        public Figure(double a) {
            _a = a;
        }

        public override string ToString()
        {
            return $"Areal: {Areal()} - Omkreds: {Perimeter()}";
        }
    }

    public class Triangle : Figure
    {

        protected double _b;
        protected double _c;
        public Triangle(double a, double b, double c) : base(a)
        {
            _b = b;
            _c = c;
        }

        public override double Perimeter()
        {
            return _a + _b + _c;
        }

        public override double Areal()
        {
            return 0.5 * _a * _b;
        }
    }

    public class Trapetz : Figure
    {
        protected double _b;
        protected double _c;
        protected double _d;
        protected double _s;

        protected double _h;


        public Trapetz(double a, double b, double c, double d) : base(a)
        {
            _b = b;
            _c = c;
            _d = d;
            FindSide();
            FindHeight();
        }

        public override double Perimeter()
        {
            return _a + _b + _c + _d;
        }

        private void FindSide()
        {
            _s = (_a + _b - _c + _d) / 2;
        }

        private void FindHeight()
        {
            _h = (2/(_a-_c))*Math.Sqrt(_s *(_s-_a+_c)*(_s-_b)*(_s-_d));
        }

        public override double Areal()
        {
            return 0.5 *(_a+_c)*_h;
        }
    }

    public class Paralellogram : Figure
    {
        protected double _b;
        protected double _v;

        public Paralellogram(double a, double b, double v) : base(a)
        {
            _b = b;
            _v = v;
        }

        public override double Perimeter()
        {
            return 2 * _a + 2 * _b;
        }

        public override double Areal()
        {
            return _a * _b * Math.Sin(_v*(Math.PI)/180);
        }
    }



    public class Rectangle : Paralellogram
    {
        private static double angle = 90;
        public Rectangle(double a, double b) : base(a, b, angle)
        {
        }

        public override double Areal()
        {
            return base.Areal();
        }


    }

    public class Square : Rectangle
    {
        public Square(double a) : base(a, a)
        {
        }

        public override double Areal()
        {
            return _a * _a;
        }

        public override double Perimeter()
        {
            return _a * 2 + _b * 2;
        }


    }




}
