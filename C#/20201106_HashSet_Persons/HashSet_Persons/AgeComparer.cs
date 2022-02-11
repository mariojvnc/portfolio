using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSet_Persons
{
    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Birthday.CompareTo(y.Birthday);
        }
    }
}
