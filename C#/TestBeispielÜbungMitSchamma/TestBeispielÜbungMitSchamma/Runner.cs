using System;
using System.Threading;

namespace TestBeispielÜbungMitSchamma
{
    enum Geschlecht { m, w }
    class Runner
    {
        public static Random rnd = new Random();
        public int Startnummer { get; private set; }
        public string Name { get; private set; }
        public Geschlecht Geschlecht { get; private set; }
        private bool Hat50Erreicht = false;
        public event EventHandler<_50MeterErreichtEventArgs> _50MeterErreicht;
        public event EventHandler<_100MeterErreichtEventArgs> _100MeterErreicht;

        public Runner(int startnummer, string name, Geschlecht geschlecht)
        {
            Startnummer = startnummer;
            Name = name;
            Geschlecht = geschlecht;
        }

        public void Run()
        {
            double length = 0;
            while (length < 100/* noch nicht im Ziel*/ )
            {
                // TODO: length erhöhen um den zufälligen Weg
                length += 6 + 3 * rnd.NextDouble();

                // TODO: Wurden 50 m gerade zurückgelegt? -> Event auslösen
                if(length >= 50 && Hat50Erreicht == false)
                {
                    Hat50Erreicht = true;
                    _50MeterErreicht?.Invoke(this, new _50MeterErreichtEventArgs(length));
                }
                // TODO: Ziel erreicht? -> Event auslösen
                if (length >= 100)
                {
                    _100MeterErreicht?.Invoke(this, new _100MeterErreichtEventArgs(length));
                }

                Thread.Sleep(1000);
            }
        }
    }
}
