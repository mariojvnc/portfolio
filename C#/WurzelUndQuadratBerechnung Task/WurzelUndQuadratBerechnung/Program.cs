using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurzelUndQuadratBerechnungTask
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

            Console.WriteLine($"\n\n--Berechnung mit Tasks--\n\n");

            Task t_1 = new Task(zahlentabelle.QuadrateAusgeben);
            //thread_1.Name = "QuadrateAusgeben"; // Für Debugger

            Task t_2 = new Task(zahlentabelle.WurzelnAusgeben);
            //thread_2.Name = "WurzelnAusgeben"; // Für Debugger

            Console.WriteLine($"Threadssind angelegt");

            stopwatch.Restart();
            t_1.Start();
            t_2.Start();
            Console.WriteLine("Threads sind gestartet");
            t_1.Wait();
            t_2.Wait();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000f + " Sekunden");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
