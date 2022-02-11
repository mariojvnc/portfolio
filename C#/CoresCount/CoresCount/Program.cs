using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoresCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.ProcessorCount);

            Console.ReadKey();
        }
    }
}
