using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockmarket_Events
{
    // Observor: Der der beobachtet
    class Investor
    {
        public string Name { get; private set; }

        public Investor(string name)
        {
            Name = name;
        }

        // 4.
        // sender ist der Absender des Events (in unserem Fall die Instanz von Stock für Apple)
        // Diese Methode wird aufegrufen durch das Event, das in Stock ausgelöst wird
        // Eventhandler, Callbacks
        public void VerständigungDassKursFällt(object sender, DroppingEventArgs args)
        {
            if (!(sender is Stock))
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine($"{Name} wurde informiert.");
            string name = (sender as Stock).Name;

            // 2021-02-09 12:45 Der Kurs von Apple ist um 0.5 % auf den Wert von 150 US$ gesunken
            Console.WriteLine($"{args.Zeitpunkt}: {name} ist um {Math.Round(args.DroppingProcenture, 6)} % auf {args.Kurs} US$ gesunken");
        }
    }
}
