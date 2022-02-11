using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluglinien_AlterTest
{
    class NotlandungEventArgs
    {
        public string FlugzeugName { get; private set; }
        public double X_Kooridnate_Notlandung { get; private set; }
        public double Y_Kooridnate_Notlandung { get; private set; }

        public NotlandungEventArgs(string flugzeugName, double x_Kooridnate_Notlandung, double y_Kooridnate_Notlandung)
        {
            FlugzeugName = flugzeugName;
            X_Kooridnate_Notlandung = x_Kooridnate_Notlandung;
            Y_Kooridnate_Notlandung = y_Kooridnate_Notlandung;
        }
    }
}
