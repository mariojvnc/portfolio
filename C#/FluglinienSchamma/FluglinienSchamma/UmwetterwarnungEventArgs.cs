using System;

namespace FluglinienSchamma
{
    class UmwetterwarnungEventArgs : EventArgs
    {
        public double X_Koordinate { get; private set; }
        public double Y_Koordinate { get; private set; }

        public UmwetterwarnungEventArgs(double x_Koordinate, double y_Koordinate)
        {
            X_Koordinate = x_Koordinate;
            Y_Koordinate = y_Koordinate;
        }
    }
}
