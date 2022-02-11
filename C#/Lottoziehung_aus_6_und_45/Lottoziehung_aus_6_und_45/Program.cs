using System;
using System.Collections.Generic;

namespace Lottoziehung_aus_6_und_45
{
    class Program
    {
        public static int GetCountOfRightNumbers(Tipp tipp, SortedSet<int> gewinnZahlen)
        {
            int sum = 0;

            foreach (int number in tipp.zahlen)
                if (gewinnZahlen.Contains(number))
                    sum++;

            return sum;
        }
        static void Main(string[] args)
        {
            #region Gewinnzahlen
            SortedSet<int> gewinnZahlen = new SortedSet<int>();

            Random rnd = new Random();

            while (gewinnZahlen.Count < 6)
            {
                gewinnZahlen.Add(rnd.Next(1, 46));
            }
            // Console.WriteLine(string.Join("\n", gewinnZahlen));

            Console.Write($"Gewinnzahlen: ");

            foreach (int zahl in gewinnZahlen)
                Console.Write($"{zahl} ");

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            List<Tipp> tipps = new List<Tipp>();

            int j = 0;
            int i = 1;

            while (i <= 10_000)
            {
                #region In jede Liste 6 Zahlen einfügen
                while (j < 6)
                {
                    tipps.Add(new Tipp());
                    j++;
                }
                j = 0;
                /*Console.WriteLine(tipps[i]);
                Console.WriteLine($"EINE LISTE\n");
                Console.WriteLine(string.Join(" ", tipps[i]));*/
                #endregion               
                i++;
            }

            #region Counts
            int sixWinnerCount = 0;
            int fiveWinnerCount = 0;
            int fourWinnerCount = 0;
            int threeWinnerCount = 0;
            #endregion

            foreach (Tipp tipp in tipps)
            {
                switch (GetCountOfRightNumbers(tipp, gewinnZahlen))
                {
                    case 6: sixWinnerCount++; break;
                    case 5: fiveWinnerCount++; break;
                    case 4: fourWinnerCount++; break;
                    case 3: threeWinnerCount++; break;
                }
            }

            #region Ausgabe
            Console.WriteLine($"6er: {sixWinnerCount}");
            Console.WriteLine($"5er: {fiveWinnerCount}");
            Console.WriteLine($"4er: {fourWinnerCount}");
            Console.WriteLine($"3er: {threeWinnerCount}");
            #endregion

            Console.ReadKey();
        }
    }
}
