using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluglinien_AlterTest
{
    class UnwetterEventArgs : EventArgs
    {
        public Unwetterart Unwetterart { get; private set; }
        public double X_Koordinate { get; private set; }
        public double Y_Koordinate { get; private set; }

        public UnwetterEventArgs(double x_Koordinate, double y_Koordinate, Unwetterart unwetterart)
        {
            Unwetterart = unwetterart;
            X_Koordinate = x_Koordinate;
            Y_Koordinate = y_Koordinate;
        }
    }
}
