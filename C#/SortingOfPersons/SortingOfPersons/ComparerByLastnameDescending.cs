using System.Collections.Generic;

namespace SortingOfPersons
{
    class ComparerByLastnameDescending : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {       
            return -x.LastName.CompareTo(y.LastName);
        }
    }
}