using System;

namespace FluglinienSchamma
{
    class NotlandungEventArgs : EventArgs
    {
        public double X_Kooridnate_Notlandung { get; private set; }
        public double Y_Kooridnate_Notlandung { get; private set; }

        public NotlandungEventArgs( double x_Kooridnate_Notlandung, double y_Kooridnate_Notlandung)
        {
            X_Kooridnate_Notlandung = x_Kooridnate_Notlandung;
            Y_Kooridnate_Notlandung = y_Kooridnate_Notlandung;
        }
    }
}
