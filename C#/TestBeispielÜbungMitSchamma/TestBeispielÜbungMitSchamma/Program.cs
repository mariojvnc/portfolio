using System;

namespace TestBeispielÜbungMitSchamma
{
    class Program
    {
        static void Main(string[] args)
        {
            Rennleitung rennleitung = new Rennleitung("runners.csv");
            rennleitung.Simulate();
            
            Console.ReadKey();
        }
    }
}
