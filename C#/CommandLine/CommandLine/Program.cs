using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (arg.Length <= 3)
                    Console.WriteLine($"Die Länge von dem Wort {arg} ist kleiner gleich 3");
                else if (arg == "Mario")
                    Console.WriteLine($"{arg} ist king");
                else
                    Console.WriteLine(arg);
            }

        }
    }
}
