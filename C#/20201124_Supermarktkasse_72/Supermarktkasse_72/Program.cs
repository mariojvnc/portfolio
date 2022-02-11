using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarktkasse_72
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarkt markt = new Supermarkt();
            markt.Simulate(
                new DateTime(2020, 11, 24, 9, 0, 0),
                new DateTime(2020, 11, 24,19, 0, 0)
                );

            Console.ReadKey();
        }
    }
}
