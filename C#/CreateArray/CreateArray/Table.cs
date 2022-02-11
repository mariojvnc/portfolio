using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CreateArray
{
    class Table
    {
        int[,] data;
        public Table(int rows, int cols)
        {
            data = new int[rows, cols];
            CreateArray(rows, cols);
        }

        #region Methods
        public int[,] CreateArray(int rows, int columns)
        {
            Random rnd = new Random();
            //int number = rnd.Next(31) - 15;
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int col = 0; col < data.GetLength(1); col++)
                    data[row, col] = rnd.Next(-15, 16);
            }
            return data;
        }
        #endregion

        #region ToString();
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int sum = 0;

            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    builder.Append($"{data[row, col],3}");
                    sum += data[row, col];

                }
                builder.AppendLine($" --- Summe: {sum}");
                sum = 0;
                builder.AppendLine();
            }

            return builder.ToString();
        }
        #endregion
    }
}
