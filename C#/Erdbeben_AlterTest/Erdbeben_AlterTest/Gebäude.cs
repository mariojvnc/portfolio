using System;

namespace Erdbeben_AlterTest
{
    class Gebäude
    {
        #region Props & Konstruktor
        public string Bezeichnung { get; private set; }
        public double X_Koordinate { get; private set; }
        public double Y_Koordinate { get; private set; }

        public Gebäude(string bezeichnung, double x_Koordinate, double y_Koordinate)
        {
            Bezeichnung = bezeichnung;
            X_Koordinate = x_Koordinate;
            Y_Koordinate = y_Koordinate;
        }
        #endregion

        public event EventHandler<NotrufEventArgs> Notruf;

        public void NeuerAusbruchBenachrichtigung(object sender, ErdbebenEventArgs args)
        {
            if (!(sender is Erdbeben))
                throw new InvalidOperationException();

            Console.WriteLine($"{Bezeichnung} wurde über einen Erdbeben auf {args.X_Koordinate}/{args.Y_Koordinate} informiert.");

            // Entfernung ausrechnen
            double arg1 = Math.Pow(X_Koordinate - args.X_Koordinate, 2);
            double arg2 = Math.Pow(Y_Koordinate - args.Y_Koordinate, 2);

            double entfernung = Math.Sqrt(arg1 + arg2);
            if (entfernung < 5)
                Notruf?.Invoke(this, new NotrufEventArgs(Bezeichnung, X_Koordinate, Y_Koordinate, args.Time, entfernung));
        }

        public void NotruforganisationKommt(object sender, EinsatzbestätigungEventArgs args)
        {
            Console.WriteLine($"{args.Name} wurde alarmiert und ist am Weg. Vorraussichtliche Ankunft: {args.Ankunftszeit.ToShortTimeString()}");
        }
    }
}
