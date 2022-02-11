using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TestNewDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader2 = new StreamReader("OhneLeerzeichenAmEnde.txt");

            int counter = 0;
            while (!reader2.EndOfStream)
            {
                counter++;
                string line = reader2.ReadLine();
                Console.WriteLine(line);
            }
            Console.WriteLine(counter);
            Console.ReadKey();
        }
    }
}
