using System;
using System.Collections.Generic;

namespace DemoDi
{
    class Program
    {
        static void Main(string[] args)
        {
            Schüler mario = new Schüler("Mario");
            Schüler mario2 = new Schüler("Mario");
            Schüler leon = new Schüler("Leon");
            Schüler schamma = new Schüler("Schamma");
            Schüler fabian = new Schüler("Fabian");
            Schüler marko = new Schüler("Marko");
            Schüler marko2 = new Schüler("Marko");
            Schüler marko3 = new Schüler("Marko");
            Schüler fatima = new Schüler("Fatima");

            List<Schüler> schule = new List<Schüler>
            {
                mario, leon, schamma, fabian, marko, fatima, mario2, marko2, marko3
            };

            // Erstelle ein Dictionary, das mitzählt, wie oft es eine Person in einer Schule mit gleichem Namen gibt
            // KEY = Name
            // VALUE = Anzahl der Schüler mit dem Namen


            //         Name    Anz
            Dictionary<string, int> schülerToCount = new Dictionary<string, int>();

            foreach(var schüler in schule)
            {
                if (!schülerToCount.ContainsKey(schüler.Name))
                {
                    // Es gibt die Person noch nicht
                    // -> Also hinzufügen
                    schülerToCount.Add(schüler.Name, 1); 
                    // Wenn ein neuer Schüler hinzugefügt wird, dann ist er der erste mit dem Namen
                    // deswegen 1
                }
                else
                {
                    // Die Person gibt es schon
                    // -> Anzahl erzhöhen
                    schülerToCount[schüler.Name]++;
                    // Er erhöht den Value um 1
                    // Es wird ein neuer Schüler dazugezählt
                }
            }


            // Gib die Schüler und wie oft sie vorkommen aus.

            foreach(var element in schülerToCount)
            {
                // Key = Name
                // Value = Anzahl
                Console.WriteLine($"{element.Key} -> Gibt es {element.Value} Mal in der Schule.");
            }

            Console.ReadKey();
        }
    }
}
