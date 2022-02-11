using System;

namespace Erdbeben_AlterTest
{
    class Notruforganisation
    {
        #region Props & Konstruktor
        public string Bezeichnung { get; private set; }
        public double X_Koordinate { get; private set; }
        public double Y_Koordinate { get; private set; }

        public Notruforganisation(string bezeichnung, double x_Koordinate, double y_Koordinate)
        {
            Bezeichnung = bezeichnung;
            X_Koordinate = x_Koordinate;
            Y_Koordinate = y_Koordinate;
        }
        #endregion

        public event EventHandler<EinsatzbestätigungEventArgs> Einsatzbestätigung;

        public void NotrufEingegangen(object sender, NotrufEventArgs args)
        {
            if (!(sender is Gebäude))
                throw new InvalidOperationException();

            Console.WriteLine($"{Bezeichnung}: Neuer Notruf eingegangen von: {args.Name} auf Position {args.X_Koordinate_Gebäude}/{args.Y_Koordinate_Gebäude}");

            DateTime eintreffzeitpunkt = args.Zeit.AddMinutes(1 + args.Entfernung / 2);
            Einsatzbestätigung?.Invoke(this, new EinsatzbestätigungEventArgs(Bezeichnung, eintreffzeitpunkt));
        }

    }
}
