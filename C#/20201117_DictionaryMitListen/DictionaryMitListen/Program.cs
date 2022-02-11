using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryMitListen
{
    class Program
    {
        enum Zahlenart { Ungerade, Gerade };

        static void Main(string[] args)
        {
            string s = "4 8 9 12 223 25 18";

            // Erstelle ein Dictionary, dass getrennt alle geraden und ungeraden Zahlen enthält
            var dic = new Dictionary<Zahlenart, List<int>>();

            //   Key    ->  Value
            // Ungerade -> 9, 223, 25
            // Gerade   -> 4, 8, 12, 18

            string[] parts = s.Split(' ');

            foreach (string part in parts)
            {
                int zahl = int.Parse(part);

                Zahlenart art; // = zahl % 2 == 0 ? Zahlenart.Gerade : Zahlenart.Ungerade;

                if (zahl % 2 == 0)
                {
                    art = Zahlenart.Gerade;
                }
                else
                {
                    art = Zahlenart.Ungerade;
                }

                // 1. Nachschauen, ob der Key schon enthalten ist.
                // Version 1
                //if (!dic.ContainsKey(art))
                //{   // key ist noch nicht enthalten
                //    dic.Add(art, new List<int>() { zahl });  // zuerst kommt eine leere Liste rein
                //}
                //else
                //{   // Key ist schon enthalten. Einfach zahl zur Liste hinzufügen.
                //    dic[art].Add(zahl);
                //}

                // Version 2
                if (!dic.ContainsKey(art))
                {   // key ist noch nicht enthalten
                    dic.Add(art, new List<int>());  // zuerst kommt eine leere Liste rein
                }

                // Key ist schon enthalten. Einfach zahl zur Liste hinzufügen.
                dic[art].Add(zahl);
            }

            // Ausgabe
            foreach (var element in dic)
            {   // element.Value ist eine Liste!
                Console.WriteLine($"{element.Key} -> {String.Join(", ", element.Value)}");
            }

            Console.ReadKey();
        }
    }
}
