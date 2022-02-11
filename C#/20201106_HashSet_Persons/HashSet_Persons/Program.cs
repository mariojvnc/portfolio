using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet_Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Hugo", new DateTime(2004, 5, 2));
            Person p2 = new Person("Ralf", new DateTime(2005, 3, 1));
            Person p3 = new Person("Ralf", new DateTime(2004, 8, 22));
            Person p4 = new Person("Ralf", new DateTime(2004, 8, 22));

            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());
            Console.WriteLine(p3.GetHashCode());
            Console.WriteLine(p4.GetHashCode());

            if( p3 == p4 )
            {
                Console.WriteLine("p3 und p4 sind gleich");
            }
            else
            {
                Console.WriteLine("p3 und p4 sind nicht gleich");
            }

            SortedSet<Person> set = new SortedSet<Person>( new AgeComparer() )
            {
                p1,
                p2,
                p3,
                p4,
            };

            // Die Dauer des Suchens in einem HashSet ist völlig unabhängig 
            // von der Anzahl der Elemente im HashSet! 
            // Ein HashSet verwendet den HashCode DIREKT! D. h. bei der Suche 
            // in einem HashSet werden nie alle Elemente einzeln durchgelaufen.
            // Aufwand: O(1)

            // Liste mit 10000 Personen: Dauert eine Suche länger, als wenn die Liste 
            //       nur   100 Personen hat.
            // Nein! Geht ja alle durch!
            // Aufwand: O(n)

            Console.WriteLine(set.Contains(p2));

            Console.WriteLine(String.Join("\n", set));

            Console.ReadKey();
        }
    }
}
