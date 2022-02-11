using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                4, 6, 1, -3, 0, 3
            };

            Console.WriteLine($"Unsorted: {string.Join(", ", numbers)}");

            numbers.Sort(); // ascending (=aufsteigend) is the natural sorting order

            Console.WriteLine($"Sorted: {string.Join(", ", numbers)}");

            // How to sort descending (=absteigend)?

            numbers.Sort(new ComparerOfNumbersDescending());
            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();
        }
    }
}
