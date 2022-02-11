using System;

namespace TicTacToe
{
    class Program
    {
        // Factory methods = create instances based on params
        #region Methods
        static void OutputArray(char[,] array)
        {
            Console.WriteLine();
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write($"{array[row, col],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
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
        static bool PlayerHasWon(char[,] array, int player, int row, int col)
        {
            
            #region First Try xD
            //try
            //{
            //    if (array[0, 0] == character || array[0, 1] == character || array[0, 2] == character) // First row
            //        return true;
            //    else if (array[1, 0] == character || array[1, 1] == character || array[1, 2] == character) // Second row
            //        return true;
            //    else if (array[2, 0] == character || array[2, 1] == character || array[2, 2] == character) // Third row
            //        return true;
            //    else if (array[0, 0] == character || array[1, 0] == character || array[2, 0] == character) // First column
            //        return true;
            //    else if (array[0, 1] == character || array[1, 1] == character || array[2, 1] == character) // Second column
            //        return true;
            //    else if (array[0, 2] == character || array[1, 2] == character || array[2, 3] == character) // Third Column
            //        return true;
            //    else if (array[0, 0] == character || array[1, 1] == character || array[2, 2] == character) // diagonal to the bottom right
            //        return true;
            //    else if (array[0, 2] == character || array[1, 1] == character || array[2, 0] == character) // diagonal to the bottom left
            //        return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            //return false;
            #endregion

            if (EqualRow(row, array))
                return true;
            else if (EqualColumn(col, array))
                return true;
            else if (EqualDiagonale(array))
                return true;

            return false;
        }
        static bool EqualRow(int row, char[,] board)
        {
            if (board[row, 0] == ' ')
            {
                return false;
            }
            else
            {
                if (board[row, 1] != board[row, 0])
                {
                    return false;

                }
                else
                {
                    if (board[row, 2] == board[row, 0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        static bool EqualColumn(int column, char[,] board)
        {
            if (board[0, column] == ' ')
            {
                return false;
            }
            else
            {
                if (board[1, column] != board[0, column])
                {
                    return false;
                }
                else
                {
                    if (board[2, column] == board[0, column])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        static bool EqualDiagonale(char[,] board)
        {
            if (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2])
            {
                if (board[2, 0] != ' ')
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
                {
                    if (board[0, 0] != ' ')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        static bool IsBoardFull(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row, col] == ' ')
                        return true;
                }
            }
            return false;
        }
        #endregion
        static void Main(string[] args)
        {
            char[,] board = CreateBoard(3, ' ');
            int player = 1;
            int counterOfMoves = 0;

            #region Explanation
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"------------------------------------------------------------------" +
                $"\nHOW THE GAME WORKS:\nOn a square, 3 × 3 field, " +
                $"the two players take turns placing their\n" +
                $"mark in a free field. " +
                $"The first player to place three characters\n" +
                $"in a row, column or diagonal wins.\n\n" +
                $"a ... 1st row\t\t1 ... 1st column\n" +
                $"b ... 2nd row\t\t2 ... 2nd column\n" +
                $"c ... 3rd row\t\t3 ... 3rd column\n" +
                $"\ne.g.: a3\n------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            #endregion

            while (IsBoardFull(board))
            {
                #region Input of a field
                if (player == 1)
                    Console.WriteLine("(0)");
                else if (player == 2)
                    Console.WriteLine("(X)");
                else
                    throw new ArgumentException("Kann nicht wahr sein");

                Console.Write($"Player {player} picks a field: ");
                string location = Console.ReadLine();
                counterOfMoves++;
                #region Check if input IsValid()
                if (!IsValid(location))
                {
                    Console.WriteLine($"'{location}' is an invalid location!\n");
                    continue;
                }
                #endregion

                #endregion

                #region Get Indices
                (int row, int col) indices = GetFieldFromLocation(location);
                if (board[indices.row, indices.col] != ' ')
                {
                    Console.WriteLine($"That field is already taken!\n");
                    continue;
                }
                #endregion

                // Valid input here
                if (player == 1)
                {
                    // 0
                    board[indices.row, indices.col] = '0';
                    if (PlayerHasWon(board, player, indices.row, indices.col))
                    {
                        Console.WriteLine($"Player {player} has won!\nBoard:\n");
                        OutputArray(board);
                        break;
                    }
                    player = player + 1;

                }
                else if (player == 2)
                {
                    // X
                    board[indices.row, indices.col] = 'X';
                    if (PlayerHasWon(board, player, indices.row, indices.col))
                    {
                        Console.WriteLine($"Player {player} has won!\nBoard:\n");
                        OutputArray(board);
                        break;
                    }
                    player = player - 1;
                }

                if (!IsBoardFull(board))
                {
                    Console.Clear();
                    Console.WriteLine("\nDRAW!");
                }

                OutputArray(board);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nIn the game were {counterOfMoves} taken. Great Game!");
            Console.ReadKey();
        }
    }
}
