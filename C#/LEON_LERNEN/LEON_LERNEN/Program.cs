using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LEON_LERNEN
{
    class Program
    {
        static double BerechneFlächeUndUmfang(double a,double b, double c)
        {
            double s = (a + b + c) / 2;
            return  Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
        static void StringZeile(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                //Console.WriteLine(s.Substring(i, 1).); 
                Console.WriteLine(s[i]);
            }
        }
        static int Zähle(string text, string s)
        {
            int anz = 0;
            for(int i = 0; i < text.Length; i++)
            {
                if (text.Substring(i,i+2).Contains(s))
                {
                    anz++;
                }
            }
            if (text == string.Empty)
            {
                return 0;
            }
            return anz;s
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(Math.Round(BerechneFlächeUndUmfang(3,4,5.5),3));

            // gebe jedes Zeichen eines strings zeilenweise aus

            //string s = "12345";
            //StringZeile(s);
            //Console.WriteLine();
            //Console.WriteLine();

            Console.WriteLine(Zähle("aabcabd","ab"));
            Console.WriteLine(Zähle("aabcabd","bc"));
            Console.WriteLine(Zähle("Schule", "ule"));
            Console.WriteLine(Zähle("Schule",""));

            Console.ReadKey();
        }
    }
}
