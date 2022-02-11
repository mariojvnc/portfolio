using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{

    class Triangle : ICircumference, IArea
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        #region Methods
        public double CalculateCircumference() => A + B + C;

        public double GetArea()
        {
            double s = CalculateCircumference() / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"<({A} {B} {C})";
        }
        #endregion
    }
}
