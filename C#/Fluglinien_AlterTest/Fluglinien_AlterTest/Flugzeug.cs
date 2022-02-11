using System;

namespace Fluglinien_AlterTest
{
    class Flugzeug
    {
        #region props and constructor
        public DateTime Startzeit { get; private set; }
        public DateTime Endzeit => Startzeit.AddMinutes(Flugdauer);


        public int Flugdauer { get; private set; }
        public string Name { get; private set; }
        public double X_Start { get; private set; }
        public double Y_Start { get; private set; }
        public double X_Landung { get; private set; }
        public double Y_Landung { get; private set; }

        public double X_Akutell { get; private set; }
        public double Y_Akutell { get; private set; }

        public Flugzeug(DateTime startzeit, int flugdauer, string name, double x_Start, double y_Start, double x_Landung, double y_Landung)
        {
            Startzeit = startzeit;
            Flugdauer = flugdauer;
            Name = name;
            X_Start = x_Start;
            Y_Start = y_Start;
            X_Landung = x_Landung;
            Y_Landung = y_Landung;

            X_Akutell = x_Start;
            Y_Akutell = y_Start;
        }
        #endregion

        public event EventHandler<NotlandungEventArgs> Notlandung;

        public void Fly()
        {
            for (DateTime time = Startzeit; time <= Endzeit; time = time.AddMinutes(15))
            {
                Console.WriteLine($"    {Name} auf {X_Akutell}/{Y_Akutell}");
                System.Threading.Thread.Sleep(1000);
                double x_step = Math.Round(15.0 / Flugdauer * (X_Landung - X_Start), 3);
                double y_step = Math.Round(15.0 / Flugdauer * (Y_Landung - Y_Start), 3);

                X_Akutell += x_step;
                Y_Akutell += y_step;
            }
        }

        // 3.
        // Event wurde getrigget.   
        public void UnwetterwarnungGetriggert(object sender, UnwetterEventArgs args)
        {
            if (!(sender is Flugsicherung))
            {
                throw new InvalidOperationException();
            }

            //Console.WriteLine($"UNWETTERWARNUNG auf {args.X_Koordinate}/{args.Y_Koordinate} Art: {args.Unwetterart}");

            double x_länge = args.X_Koordinate - X_Akutell;
            double y_länge = args.Y_Koordinate - Y_Akutell;
            x_länge = Math.Pow(x_länge, 2); // quadriert
            y_länge = Math.Pow(y_länge, 2); // quadriert

            double distanz = Math.Sqrt(x_länge + y_länge);

            if(distanz < 4)
            {
                Notlandung?.Invoke(this, new NotlandungEventArgs(Name, Math.Round(X_Akutell), Math.Round(Y_Akutell)));
            }
            //Console.WriteLine($"{Name} wurde benachrichtigt, dass über eine Unwetterwarnung benachrichtigt.");
        }

        public override string ToString()
        {
            return $"{Startzeit.ToShortTimeString()},{Flugdauer},{Name},{X_Start},{Y_Start},{X_Landung},{Y_Landung}";
        }
    }
}
