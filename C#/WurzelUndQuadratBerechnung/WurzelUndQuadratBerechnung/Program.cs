using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WurzelUndQuadratBerechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            Zahlentabelle zahlentabelle = new Zahlentabelle();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            zahlentabelle.QuadrateAusgeben();
            zahlentabelle.WurzelnAusgeben();

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000f + " Sekunden");
            Console.ReadKey();

            Console.WriteLine($"\n\n--Berechnung mit Threads--\n\n");

            Thread thread_1 = new Thread(zahlentabelle.QuadrateAusgeben);
            thread_1.Name = "QuadrateAusgeben"; // Für Debugger

            Thread thread_2 = new Thread(zahlentabelle.WurzelnAusgeben);
            thread_2.Name = "WurzelnAusgeben"; // Für Debugger

            Console.WriteLine($"Threadssind angelegt");

            stopwatch.Restart();
            thread_1.Start();   
            thread_2.Start();
            Console.WriteLine("Threads sind gestartet");
            thread_1.Join();
            thread_2.Join();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000f + " Sekunden");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
