using System;
using System.IO;

namespace Fluglinien_AlterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Flugsicherung flugsicherung = new Flugsicherung(Directory.GetCurrentDirectory() + @"\..\..\Flugplan.csv");
            

            Console.WriteLine(flugsicherung.SimulationAsync());
            Console.ReadKey();
        }
    }
}
