using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // set = Menge
            // { 4, 8, 3, 1 }
            // Eine Menge enthält nie ein Element mehrmals! Immer nur maximal einmal!
            HashSet<int> zahlen = new HashSet<int>();
            Console.WriteLine(zahlen.Add(4));
            zahlen.Add(8);
            zahlen.Add(3);
            Console.WriteLine(zahlen.Add(4));
            zahlen.Add(1);

            foreach (int zahl in zahlen)
            {
                Console.Write($"{zahl} ");
            }
            Console.WriteLine();

            // Zahlenbereich von 1 bis 10
            // Gesucht: 5 Zufallszahlen haben, die nicht doppelt sind
            Console.WriteLine("Zufallszahlen");
            //HashSet<int> zufallszahlen = new HashSet<int>();
            SortedSet<int> zufallszahlen = new SortedSet<int>(new NumberDescendingComparer());

            Random rnd = new Random();

            while (zufallszahlen.Count < 5)
            {
                Console.WriteLine( zufallszahlen.Add(rnd.Next(1, 11)));
            }

            foreach (int zahl in zufallszahlen)
            {
                Console.Write($"{zahl} ");
            }

            Console.ReadKey();
        }
    }
}
