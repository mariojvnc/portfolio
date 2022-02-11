using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DeleteLeerzeichenNordVPN
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("722 N.o.r.d.V.P.N.txt");
            //int counter = 0;

            List<string> lineWithLeerZeichen = new List<string>();
            List<string> lineswithoutleerzeichen = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                //counter++;
                if (line.EndsWith(" "))
                {
                    line = line.Remove(line.Length - 1, 1);
                    lineWithLeerZeichen.Add(line);
                }
                else
                {
                    lineswithoutleerzeichen.Add(line);
                }
               
                //Console.WriteLine($"'{line}'");

            }
            reader.Close();
            //Console.WriteLine(counter);

            Console.WriteLine();

            StreamWriter writer = new StreamWriter("OhneLeerzeichenAmEnde.txt"); 

            foreach(var line in lineWithLeerZeichen)
            {
                //Console.WriteLine($"'{line}'");

                writer.WriteLine(line);
            }

            foreach (var line in lineswithoutleerzeichen)
            {
                //Console.WriteLine($"'{line}'");

                writer.WriteLine(line);
            }



            //StreamReader reader2 = new StreamReader("OhneLeerzeichenAmEnde.txt");

            //int counter = 0;
            //while (!reader2.EndOfStream)
            //{
            //    counter++;
            //    string line = reader2.ReadLine();
            //    Console.WriteLine(line);
            //}
            //Console.WriteLine(counter);
            //Console.ReadKey();
        }
    }
}
