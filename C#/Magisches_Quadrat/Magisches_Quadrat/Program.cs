using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magisches_Quadrat
{
    class Program
    {
        static void OutputArray(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col],4}");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            // 5-dimensionales Array
            int n = 5;
            int[,] square = new int[n, n];


            // Mitte der ersten Zeile

            // number = Zahl, die gesetzt wird
            // i = counter, der erhöht wird nach jedem Setzen
            int number = 1;
            int row = 0;
            int col = n / 2;
            int i = 2; // 2 weil die 1 schon reingeschrieben wurde

            square[row, col] = number;

            while (i <= n * n)
            {
                int row_old = row; // previous positions
                int col_old = col; // required for rule 2

                row--; // one row up

                if (row < 0)
                    row = n - 1;

                col++; // one column right

                if (col > n - 1)
                    col = 0;

                if (square[row, col] != 0)
                {

                    /*  if (row + 1 >= n - 1)
                      {
                          row = row_old +1;
                          col = col_old;
                      }
                     */

                    row = row_old + 1;
                    col = col_old;
                }


                OutputArray(square);
                Console.WriteLine();
                number++;
                square[row, col] = number;


                Console.ReadKey();

                #region Counter
                i++;
                #endregion
            }

            Console.WriteLine("Ergebnis:\n");
            OutputArray(square);
            Console.WriteLine();
            OutputTotalRow(square);
            Console.WriteLine();
            OutputTotalColumn(square);  
            Console.ReadKey();
        }

        static void OutputTotalRow(int[,] array)
        {
            int sum = 0;
            int i = 1;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    sum += array[row, col];
                }

                Console.WriteLine($"Summe der {i}. Zeile: {sum}");
                i++;
                sum = 0;
            }
        }

        static void OutputTotalColumn(int[,] array)
        {

        }
    }
}
