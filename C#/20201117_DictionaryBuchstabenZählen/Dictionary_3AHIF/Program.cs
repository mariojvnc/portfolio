using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_3AHIF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Zählen wie oft ein Buchstabe vorkommt.
            string s = "Heute werde ich Autofahren gehen.";

            // Übung: Zähle wie oft jeder Buchstabe vorkommt.
            // Buchstabe -> Anzahl

            // Algorithmus
            // 0. Ein Dictionary anlegen
            //var letterToCount = new Dictionary<char, int>();
            var letterToCount = new SortedDictionary<char, int>();

            // 1. Buchstabe für Buchstabe durchlaufen
            //for ( int i = 0; i < s.Length; i++ )
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                    continue;

                // 2. Mit ContainsKey nachschauen, ob c schon im Dictionary enthalten ist.
                if (!letterToCount.ContainsKey(c))
                {
                    // 2.1 Wenn c noch nicht enthalten ist, hinzufügen und Value auf 1 setzen.
                    letterToCount.Add(c, 1);
                }
                else
                {
                    // 2.2 Wenn c bereits enthalten ist, Value um 1 erhöhen.
                    // Mit dictionary[key] greift man auf den Value zu.
                    letterToCount[c]++;
                }
            }

            // Ausgeben
            foreach ( var element in letterToCount )
            {
                Console.WriteLine($"{element.Key} -> {letterToCount[element.Key]}");
            }

            Console.ReadKey();
        }
    }
}
