using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        // Factory methods = create instances based on params
        #region Methods
        static char[,] CreateBoard(int size, char character)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    board[row, col] = character;
                }
            }

            return board;
        }
        static bool IsValid(string location)
        {
            if (location == null || location.Length != 2)
                return false;
            
            location = location.ToLower();

            char firstCharacter = location[0];
            if (!(firstCharacter == 'a' || firstCharacter == 'b' || firstCharacter == 'c'))
                return false;

            string secondCharacter = location.Substring(1, 1);
            if (!"123".Contains(secondCharacter))
                return false;

            return true;
        }
        static (int row, int col) GetFieldFromLocation(string location)
        {
            char firstCharacter = location.ToUpper()[0];
            int row = firstCharacter - 'A';

            int col = int.Parse(location.Substring(1, 1)) - 1;

            return (row, col);

        }
        #endregion
        static void Main(string[] args)
        {
            Console.Write($"Name of Player 1:");
            string playerOneName = Console.ReadLine();

            Console.Write($"\nName of Player 2:");
            string playerTwoName = Console.ReadLine();

            char[,] board = CreateBoard(3, ' ');

            // while unentschieden oder gewinnen

            while (true)
            {
                #region Input of a field
                Console.Write($"Spieler '{playerOneName}' picks a field: ");
                string location = Console.ReadLine();

                #region Check if input IsValid()
                if (!IsValid(location))
                {
                    Console.WriteLine($"'{location}' is an invalid location!");
                    continue;
                }
                #endregion

                #endregion

                #region Get Indices
                (int row, int col) indices = GetFieldFromLocation(location);
                if (board[indices.row, indices.col] != ' ')
                {
                    Console.WriteLine($"That field is already taken!");
                    continue;
                }
                #endregion

                // Valid input here

            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
