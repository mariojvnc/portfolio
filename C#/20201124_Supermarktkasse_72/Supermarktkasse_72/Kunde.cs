using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarktkasse_72
{
    class Kunde
    {
        private static Random rnd = new Random();

        // Automatisches Durchnummerieren von Instanzen (Kunden)
        // erste Kunde soll Identifier 1 haben, ...
        public int Identifier { get; private set; }

        public int Bearbeitungszeit { get; private set; }

        public int Wartezeit { get; private set; }

        // Klassenvariable die für die Klasse gilt und nicht für die Instanz
        // Sie ist keine Instanzvariable
        private static int NaechsteNummer = 1;

        public Kunde()
        {
            Identifier = NaechsteNummer;
            NaechsteNummer++;

            Bearbeitungszeit = rnd.Next(1, 3); // -> 1 oder 2 Minuten
        }

        public void WirdBearbeitet()
        {
            Bearbeitungszeit--; // Wenn er zwei Minuten braucht, braucht er dann nur eine Minute.
        }

        public void Wartet()
        {
            Wartezeit++;
        }

        public bool IstFertig
        {
            get
            {
                return Bearbeitungszeit == 0;
            }
        }

        public override string ToString()
        {
            return $"{Identifier}({Bearbeitungszeit})";
        }
    }
}
