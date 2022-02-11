using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stockmarket_Events
{
    // Enthält Daten, die bei einem Dropping-Event übermittelt werden
    class DroppingEventArgs : EventArgs
    {
        public decimal Kurs { get; }
        public DateTime Zeitpunkt { get; }
        public decimal DroppingProcenture { get; }

        public DroppingEventArgs(decimal kurs, DateTime zeitpunkt, decimal droppingProcenture)
        {
            Kurs = kurs;
            Zeitpunkt = zeitpunkt;
            DroppingProcenture = droppingProcenture;
        }
    }
}
