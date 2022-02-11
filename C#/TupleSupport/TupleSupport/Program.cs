using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleSupport
{
    class Program
    {
        static (int row, int col) IndicesOf(string[,] data, string name)
        {
            for (int r = 0; r < data.GetLength(0); r++)
            {
                for (int c = 0; c < data.GetLength(1); c++)
                {
                    if (data[r, c] == name)
                    {
                        //row = r;
                        //col = c;
                        //return true;
                        return (r, c);
                    }
                }
            }
            return (-1, -1);
        }
        static bool IndicesOf(string[,] data, string name, out int row, out int col)
        {
            for (int r = 0; r < data.GetLength(0); r++)
            {
                for (int c = 0; c < data.GetLength(1); c++)
                {
                    if (data[r, c] == name)
                    {
                        row = r;
                        col = c;
                        return true;
                    }
                }
            }
            row = col = -1;
            return false;
        }
        static void Main(string[] args)
        {
            string[,] userdata =
            {
                {"Leona", "Marko", "Mario" }, // 1st row
                {"Fabian", "Alex", "Endrit" } // 2nd row
            };

            Console.Write($"Enter name to be searched: ");
            string name = Console.ReadLine();

            //if (IndicesOf(userdata, name, out int row, out int col))
            // Tuple
            (int row, int col) = IndicesOf(userdata, name);
            if (row != -1)
            {
                Console.WriteLine($"{name} was found at row {row + 1} and col {col + 1}");
            }
            else
            {
                Console.WriteLine($"{name} was not found");
            }
            Console.ReadKey();
        }
    }
}
