using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluglinienSchamma
{
    class Program
    {
        static void Main(string[] args)
        {
            Flugsicherung flugsicherung = new Flugsicherung();
            flugsicherung.ReadFile("Flugplan.csv");
            flugsicherung.Simulate();
            Console.ReadKey();
        }
    }
}
