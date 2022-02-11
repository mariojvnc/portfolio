using System;
using System.Collections.Generic;

namespace SortingOfPersons
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person("Ivan", "Musa", new DateTime(2004, 5, 24)),
                new Person("Fabian", "Reinold", new DateTime(2003, 5,13)),
                new Person("Adam", "Reinold", new DateTime(2003, 6, 11)),
                new Person("Susan", "Reinold", new DateTime(2003, 12,24)),
                new Person("Susan", "Reinold", new DateTime(2003, 11,24)),
                new Person("William", "Dalla Corte",  DateTime.Parse("2004-04-15")),
                new Person("Thomas", "Schlögl", new DateTime(1969, 2,8)),
                new Person("Mario", "Markovic", new DateTime(2003, 10,12)),
                new Person("Mario", "Markovic", new DateTime(2003, 4,12))
            };

            Console.WriteLine(string.Join("\n", persons));

            #region Sorting by Lastname ascending
            Console.WriteLine("\nSorted by lastname:");
            persons.Sort(new ComparerByLastname());
            Console.WriteLine(string.Join("\n", persons));
            #endregion

            #region Sorting by Lastname Descending
            Console.WriteLine("\nSorted by lastname descending:");
            persons.Sort(new ComparerByLastnameDescending());
            Console.WriteLine(string.Join("\n", persons));
            #endregion

            #region Sorting by next birthday ascending
            Console.WriteLine("\nSorted by next birthday:");
            persons.Sort(new ComparerByBirthdayOrder());
            Console.WriteLine(string.Join("\n", persons));
            #endregion

            #region Natürliche Sortierreihenfolge
            persons.Sort(); // natural sorting order
            Console.WriteLine("\nSorted by natural sorting order:");
            Console.WriteLine(string.Join("\n", persons));
            #endregion

            #region Sorting by Lastname Length
            Console.WriteLine("\nSorted by Lastname Length:");
            persons.Sort(new CompareByLastNameLength());
            Console.WriteLine(string.Join("\n", persons));
            #endregion

            Console.ReadLine();
        }
    }
}
