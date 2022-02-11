using System;

namespace SortingOfPersons
{
    #region Expl Sort()
    // natürliche Sortierreihenfolge kann man definieren
    // indem man in der Klasse IComparable<Person>
    // implementiert. Diese Implementierung wird beim
    // Aufruf von Sort() verwendet
    #endregion
    class Person : IComparable<Person>
    {
        #region Props
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        #endregion

        #region Konstruktor
        public Person(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }
        #endregion

        // public int Compare(Person x, Person y)
        public int CompareTo(Person y)
        {
            Person x = this;

            // 1. Kriterium: Nachname
            int result = x.LastName.CompareTo(y.LastName);


            if (result == 0)
            {   // 2. Kriterium: Vorname
                result = x.FirstName.CompareTo(y.FirstName);

                if (result == 0)
                {   // 3. Kriterium: Monat der Geburt
                    result = x.Birthdate.Month.CompareTo(y.Birthdate.Month);
                }
            }

            return result;
        }

        #region ToString()
        public override string ToString() => $"{FirstName} {LastName} --- Birthdate {Birthdate.ToShortDateString()}";
        #endregion
    }
}