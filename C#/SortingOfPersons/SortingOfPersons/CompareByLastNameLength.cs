using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingOfPersons
{
    class CompareByLastNameLength : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.LastName.Length.CompareTo(y.LastName.Length);

            if(result == 0)
            {
                result = x.LastName.CompareTo(y.LastName);
            }

            return result;
        }
    }
}
