using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdbeben_AlterTest
{
    class NotrufEventArgs : EventArgs
    {
        public string Name { get; private set; }
        public double X_Koordinate_Gebäude { get; private set; }
        public double Y_Koordinate_Gebäude { get; private set; }
        public DateTime Zeit { get; private set; }
        public double Entfernung { get; private set; }

        public NotrufEventArgs(string name, double x_Koordinate_Gebäude, double y_Koordinate_Gebäude, DateTime zeit, double entfernung)
        {
            Name = name;
            X_Koordinate_Gebäude = x_Koordinate_Gebäude;
            Y_Koordinate_Gebäude = y_Koordinate_Gebäude;
            Zeit = zeit;
            Entfernung = entfernung;
        }
    }
}
