using System;
using System.Collections.Generic;

namespace SortingOfPersons
{
    class ComparerByBirthdayOrder : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            DateTime now = DateTime.Now;
            int monthNow = now.Month;   // e.g. 10
            int dayNow = now.Day;       // e.g. 2

            // e.g. distance = -12 bei Mario    (10)
            //      distance =  -4 bei Thomas   (2)
            //      distance = -10 bei Schamma  (8)
            int distance = ((x.Birthdate.Month + 12) - monthNow) * -1;
            return distance.CompareTo(dayNow);
        }
    }
}