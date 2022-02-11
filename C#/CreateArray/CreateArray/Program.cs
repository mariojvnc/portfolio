using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine($"'Create Array.exe' <rows> <cols>");
                Console.ReadKey();
                return;
            }

            if (!(int.TryParse(args[0], out int rows_) || int.TryParse(args[0], out int cols)))
            {
                Console.WriteLine($"ERROR: Values have to be <int>");
                Console.ReadKey();
                return;
            }

            int rows = int.Parse(args[0]);
            int columns = int.Parse(args[1]);
            Table table = new Table(rows, columns);
            Console.WriteLine(table);

            Console.ReadKey();
        }
    }
}
