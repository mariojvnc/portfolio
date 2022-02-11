using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdbeben_AlterTest
{
    class ErdbebenEventArgs : EventArgs
    {
        public Random rnd = new Random();
        public DateTime Time { get; private set; }
        public double X_Koordinate { get; set; }
        public double Y_Koordinate { get; set; }

        public ErdbebenEventArgs(DateTime time)
        {
            Time = time;
            X_Koordinate = rnd.Next(0, 11);
            Y_Koordinate = rnd.Next(0, 11);
        }
    }
}
