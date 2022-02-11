using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurzelUndQuadratBerechnung
{
    // Könnte statisch sein.
    class Zahlentabelle
    {
        const int delay = 200; // in Millisekunden
        const double maxValue = 10.0;

        // Könnte statisch sein.
        public void QuadrateAusgeben()
        {
            for (int x = 0; x <= maxValue; x++)
            {
                string zeile = String.Format("{0}*{0} = {1}", x, x * x);
                Console.WriteLine(zeile);

                System.Threading.Thread.Sleep(delay);
            }
        }

        public void WurzelnAusgeben()
        {
            for (int x = 0; x <= maxValue; x++)
            {
                // '\u221A' ist das Wurzelzeichen
                string zeile = String.Format("\u221A{0} = {1}", x, Math.Sqrt(x));
                Console.WriteLine(zeile);

                System.Threading.Thread.Sleep(delay);
            }
        }
    }
}
