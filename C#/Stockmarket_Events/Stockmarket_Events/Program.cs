using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stockmarket_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock("Apple", 136.91m);
            var investor_1 = new Investor("Mr. Phillips");
            var investor_2 = new Investor("Senior Kuba");
            
            // 5. Registrierung beim Event
            stock.Dropping += investor_1.VerständigungDassKursFällt;
            stock.Dropping += investor_2.VerständigungDassKursFällt;

            // Simulation für 10 Sekunden
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < 10_000) // 10 s
            {
                stock.RecalculateKurs();
                Console.WriteLine(stock);
                Thread.Sleep(500); // 0,5 s
            }

            watch.Stop();

            // Abmelden vom Event
            stock.Dropping -= investor_1.VerständigungDassKursFällt;
            stock.Dropping -= investor_2.VerständigungDassKursFällt;

            Console.ReadKey();
        }
    }
}
