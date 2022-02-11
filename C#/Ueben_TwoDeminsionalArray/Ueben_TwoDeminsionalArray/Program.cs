using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ueben_TwoDeminsionalArray
{
    class Program
    {
        static void OutputArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col], 4}");
                }
                Console.WriteLine();
            }
        }
        static public int GetSumRow(int[,] array, int row)
        {
            int sum = 0;
            for (int col = 0; col < array.GetLength(1); col++)
            {
                sum += array[row, col];
            }
            return sum;
        }
        static public int GetSumCol(int[,]array, int col)
        {
            int sum = 0;
            int index = 0;
            int maxIndex = array.GetLength(0) - 1;
            while(index <= maxIndex)
            {
                sum += array[index, col];
                index++;
            }
            return sum;
        }
        static void Main(string[] args)
        {

            int[,] array = new int[,] {
                { 30, 53, 43, 8}, // 134 (row), 74 (col 0)
                { 12, 48, 5, 9}, // 74 (row), 166 (col 1)
                { 32, 65, 3, 1 }
            };

            OutputArray(array);

            Console.WriteLine();
            Console.WriteLine(GetSumRow(array, 0));
            Console.WriteLine(GetSumRow(array, 1));
            Console.WriteLine(GetSumRow(array, 2));
            Console.WriteLine();

            Console.WriteLine(GetSumCol(array, 0));
            Console.WriteLine(GetSumCol(array, 1));
            Console.WriteLine(GetSumCol(array, 2));

            Console.ReadKey();
        }
    }
}
