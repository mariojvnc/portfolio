using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion_Faculty
{
    class Program
    {
        static long Factorial__Iterative(long x)
        {
            long product = 1;

            for (int i = 1; i <= x; i++)
            {
                product = product * i;
            }

            return product;
        }

        // n! = Factorial__Recursive
        static long Factorial__Recursive(long n)
        {
            if (n == 1)
            {
                // Abbruchbedingung
                // Verlassen der Methode ohne, dass die eigene Methode aufgerufen wird
                return 1;
            }

            // recursive call
            return Factorial__Recursive(n - 1) * n;
        }

        static void Main(string[] args)
        {
            long x = 66;
            
            Console.WriteLine($"(Iterative) {x}! = {Factorial__Iterative(x)}");
            Console.WriteLine($"(Recursive) {x}! = {Factorial__Recursive(x)}");

            Console.ReadKey();
        }
    }
}
