using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Rectangle : ICircumference
    {
        // side lengths a and b
        public double A { get; private set; }
        public double B { get; private set; }

        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }

        #region Methods
        public double CalculateCircumference() => 2 * (A + B);
        public double GetArea() => A * B;
        #endregion

        #region ToString()
        public override string ToString()
        {
            return $"{A}x{B}";
        }
        #endregion
    }
}
