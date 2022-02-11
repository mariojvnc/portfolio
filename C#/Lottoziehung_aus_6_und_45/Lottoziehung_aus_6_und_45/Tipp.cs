using System;
using System.Collections.Generic;

namespace Lottoziehung_aus_6_und_45
{
    class Tipp
    {
        public static Random rnd = new Random();
        public SortedSet<int> zahlen = new SortedSet<int>(); 
        public Tipp()
        {
            while (zahlen.Count < 6)
                zahlen.Add(rnd.Next(1, 46));
        }
        public override string ToString()
        {
            return $"{string.Join(" ", zahlen)}";
        }
    }
}
