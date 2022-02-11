using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    // comparer class for sorting interges descendingly
    class ComparerOfNumbersDescending : IComparer<int> // 
    {
        /*  
        *  returns value defines the sorting order
        *   x sorted before  y  : > 0,  e. g. -1
        *   x sorted like    y : == 0
        *   x sorted after   y  : < 0,  e. g. +1
        */
        public int Compare(int x, int y)
        {
            // - indicates a descending order
            // - zeigt an, dass absteigend sortiert werden soll.

            return -x.CompareTo(y); // *-1

            //if (x > y)
            //    return -1; // x ist in der Sortierreifenfolge VOR y

            //if (x < y)
            //    return 1; // x ist in der Sortierreifenfolge NACH y

            //return 0;     // x ist in der Sortierreifenfolge GLEICH WIE y
        }
    }
}
