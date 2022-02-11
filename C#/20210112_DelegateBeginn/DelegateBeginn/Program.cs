using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBeginn
{
    class Program
    {
        static double Plus1(double x)
        {
            Console.WriteLine("Plus1");
            return x + 1;
        }

        static double Mal2(double x)
        {
            Console.WriteLine("Mal2");
            return 2 * x;
        }

        static void Main(string[] args)
        {
            Console.Write("Welche Zahl x? ");
            double zahl = double.Parse(Console.ReadLine());

            Console.Write("x+1 oder x*2. Was möchten Sie?  (1/2) ");

            Func<double, double> methode = null;

            double result = 0;

            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (c)
            {
                case '1':
                    //result = Plus1(zahl);
                    methode = Plus1;
                    break;

                case '2':
                    //result = Mal2(zahl);
                    methode = Mal2;
                    break;
            }

            result = methode.Invoke(zahl);

            Console.WriteLine($"\n{result}");

            Console.ReadKey();
        }
    }
}
