using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recursive_Fibonacci
{
    class Program
    {
        // 1+2+3+4 = Sum(3)+4
        //         = (Sum(2)+3)+4
        //         = ((Sum(1)+2)+3+4
        //         = ((1+2)+3)+4
        static long Sum(int n)
        {
            return n == 1 ? 1 : Sum(n - 1) + n;
        }
        static long Fib(int n)
        {
            if (n <= 2)
                return 1;

            return Fib(n - 2) + Fib(n - 1);
        }
        static double Exp(double x, int n) => n == 0 ? 1 : x * Exp(x, n - 1);

        static void Main(string[] args)
        {
            Console.Write($"Gib n ein: ");

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Fibb({n}) = {Fib(n)}");
            Console.WriteLine($"Sum({n}) = {Sum(n)}");

            Console.Write($"Gib eine Basis ein: ");
            double x = int.Parse(Console.ReadLine());
            Console.WriteLine($"Exp({x}^{n}) = {Exp(x, n)}");

            Console.ReadKey();
        }
    }
}
