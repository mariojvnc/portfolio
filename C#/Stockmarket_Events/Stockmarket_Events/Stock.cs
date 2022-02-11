using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockmarket_Events
{
    // Obervable: Der der beobachtet wird
    class Stock
    {
        public string Name { get; private set; }
        public decimal Kurs { get; private set; }

        // 1. Event anlegen
        // 2. Definieren was ein Event an Daten mitschicken soll
        //    Definieren eine EventArgs-Klasse
        public event EventHandler<DroppingEventArgs> Dropping; // Event für fallende Kurse

        public Stock(string name, decimal kurs)
        {
            Name = name;
            Kurs = kurs;
        }

        private static Random rnd = new Random();
        // Methode für Kursanpassung
        public void RecalculateKurs()
        {
            // zu 30 % sinkt der Kurs
            // zu 10 % bleibt er gleich
            // zu 60 % steigt der Kurs
            int r = rnd.Next(0, 100);

            if (r < 30)
            {
                decimal vorher = Kurs;
                Kurs--;
                if (Kurs < 0)
                    Kurs = 0;

                decimal droppingProcenture = (vorher - Kurs) / vorher * 100;
                // 3. Methode Invoken
                Dropping?.Invoke(this, new DroppingEventArgs(Kurs, DateTime.Now, droppingProcenture));
            }
            else if (r < 40)
            {
                // 10 %
                // nothing to do
            }
            else
            {
                // 60 %
                Kurs++;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Kurs} US$";
        }
    }
}
