namespace _05.RubiksMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SolveMatrix
    {
        public static int[,] matrix;
        public static void Main()
        {
            var dimentions = ReadInts();
            matrix = new int[dimentions[0], dimentions[1]];

            var counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter++;
                }
            }

            var numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                var line = Console.ReadLine();
                var commandTokens = line
                    .Split(" ,\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                
                var direction = commandTokens[1];

                if (direction == "right" || direction == "left")
                {
                    var moves = long.Parse(commandTokens[2]);
                    moves %= dimentions[1];

                    if (moves == 0)
                    {
                        continue;
                    }

                    var row = int.Parse(commandTokens[0]);

                    ShiftRow(row, moves, direction);
                }
                else if (direction == "up" || direction == "down")
                {
                    var moves = long.Parse(commandTokens[2]);
                    moves %= dimentions[0];

                    if (moves == 0)
                    {
                        continue;
                    }

                    var col = int.Parse(commandTokens[0]);

                    ShiftCol(col, moves, direction);
                }
            }
            //PrintSquareFromMatrix(matrix, 3, 0, 0);

            Swapping();

            //PrintSquareFromMatrix(matrix, 3, 0, 0);
        }

        public static void Swapping()
        {
            var counter = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var currentNum = matrix[i, j];

                    if (currentNum == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                        continue;
                    }

                    int[] indicesOfOriginalNum = FindIdicesOfOriginalNum(i , j, counter);

                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[indicesOfOriginalNum[0], indicesOfOriginalNum[1]];
                    matrix[indicesOfOriginalNum[0], indicesOfOriginalNum[1]] = temp;

                    Console.WriteLine($"Swap ({i}, {j}) with ({indicesOfOriginalNum[0]}, {indicesOfOriginalNum[1]})");

                    counter++;
                }
            }
        }

        public static int[] FindIdicesOfOriginalNum(int startI, int startJ, int originalNum)
        {
            var indices = new int[] { startI, startJ };
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        i = startI;
                        j = startJ + 1;
                        if (startJ + 1 == matrix.GetLength(1))
                        {
                            i = startI + 1;
                            j = 0;
                            if (i == matrix.GetLength(0))
                            {
                                return indices;
                            }
                        }
                    }

                    if (matrix[i,j] == originalNum)
                    {
                        indices[0] = i;
                        indices[1] = j;

                        return indices;
                    }
                }
            }

            return indices;
        }

        public static void ShiftCol(int col, long moves, string direction)
        {
            if (direction == "down")
            {
                moves = matrix.GetLength(0) - moves;
            }

            for (int i = 0; i < moves; i++)
            {
                ShiftUpOnce(col);
            }
        }

        public static void ShiftUpOnce(int col)
        {
            var temp = matrix[0, col];

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                matrix[i, col] = matrix[i + 1, col];
            }

             matrix[matrix.GetLength(0) - 1, col] = temp;
        }

        public static void ShiftRow(int row, long moves, string direction)
        {
            if (direction == "left")
            {
                moves = matrix.GetLength(1) - moves;
            }

            for (int i = 0; i < moves; i++)
            {
                ShiftRightOnce(row);
            }
        }

        public static void ShiftRightOnce(int row)
        {
            var temp = matrix[row, matrix.GetLength(1) - 1];

            for (int i = matrix.GetLength(1) - 1; i > 0; i--)
            {
                matrix[row,i] = matrix[row, i - 1];
            }

            matrix[row, 0] = temp;
        }

        public static int[] ReadInts()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public static void PrintSquareFromMatrix(int[,] matrix, int squareSide, int bestStartY, int bestStartX)
        {
            for (int row = bestStartY; row < bestStartY + squareSide && row < matrix.GetLength(0); row++)
            {
                for (int col = bestStartX; col < bestStartX + squareSide && col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
