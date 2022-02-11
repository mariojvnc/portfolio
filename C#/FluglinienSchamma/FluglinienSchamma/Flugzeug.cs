using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FluglinienSchamma
{
    class Flugzeug
    {
        #region Props and Constructor
        public double X_Position_Start { get; private set; }
        public double Y_Position_Start { get; private set; }
        public double X_Position_Aktuell { get; private set; }
        public double Y_Position_Aktuell { get; private set; }
        public double X_Position_Landung { get; private set; }
        public double Y_Position_Landung { get; private set; }
        public DateTime Startzeit { get; private set; }
        public DateTime Endzeit => Startzeit.AddMinutes(Flugdauer);
        public int Flugdauer { get; private set; }
        public string Name { get; private set; }

        public Flugzeug(DateTime startzeit, int flugdauer, string name, double x_Start, double y_Start, double x_Landung, double y_Landung)
        {
            Startzeit = startzeit;
            Flugdauer = flugdauer;
            Name = name;
            X_Position_Start = x_Start;
            Y_Position_Start = y_Start;
            X_Position_Landung = x_Landung;
            Y_Position_Landung = y_Landung;

            X_Position_Aktuell = x_Start;
            Y_Position_Aktuell = y_Start;
        }

        #endregion

        public event EventHandler<NotlandungEventArgs> Notlandung;

        public void Fly()
        {
            for (DateTime time = Startzeit; time <= Endzeit; time = time.AddMinutes(15))
            {
                Console.WriteLine($"    {Name} auf {X_Position_Aktuell}/{Y_Position_Aktuell}");
                Thread.Sleep(1000);

                // Flugzeug um xstep und ystep weiterbringen

                double x_step = Math.Round(15.0 / Flugdauer * (X_Position_Landung - X_Position_Start), 3);
                double y_step = Math.Round(15.0 / Flugdauer * (Y_Position_Landung - Y_Position_Start), 3);

                X_Position_Aktuell += x_step;
                Y_Position_Aktuell += y_step;
            }
        }

        public void UnwetterwarnungGetriggert(object sender, UnwetterwarnungEventArgs args)
        {
            // Hier wurde eine Unwetterwarnung getriggert
            // Wir möchten ausgeben wo (X/Y)

            if(!(sender is Flugsicherung))
            {
                throw new InvalidCastException();
            }

            // Console.WriteLine($"{Name}: Neue Unwetterwarnung auf ({args.X_Koordinate}/{args.Y_Koordinate})");


            double x_länge = args.X_Koordinate - X_Position_Aktuell;
            double y_länge = args.Y_Koordinate - Y_Position_Aktuell;
            x_länge = Math.Pow(x_länge, 2); // quadriert
            y_länge = Math.Pow(y_länge, 2); // quadriert

            double distanz = Math.Sqrt(x_länge + y_länge);

            if(distanz < 4)
            {
                Notlandung?.Invoke(this, new NotlandungEventArgs(X_Position_Aktuell, Y_Position_Aktuell));
            }
        }
    }
}
