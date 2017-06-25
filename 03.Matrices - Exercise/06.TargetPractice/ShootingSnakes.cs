namespace _06.TargetPractice
{
    using System;
    using System.Linq;

    public class ShootingSnakes
    {
        public static void Main()
        {
            var dimensions = ReadInts();
            var pattern = Console.ReadLine();
            var shotParameters = ReadInts();
            var matrix = new char[dimensions[0],dimensions[1]];

            // snakes climbing
            var patternCounter = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i -= 2)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[i, j] = pattern[patternCounter];
                    patternCounter++;
                    patternCounter %= pattern.Length;
                }

                if (i == 0)
                {
                    break;
                }

                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i - 1, k] = pattern[patternCounter];
                    patternCounter++;
                    patternCounter %= pattern.Length;
                }
            }
            // PrintCharMatrix(matrix);


            // The shot
            var shotRow = shotParameters[0];
            var shotCol = shotParameters[1];
            var shotRadius = shotParameters[2];

            var rowStart = shotRow - shotRadius;
            if (rowStart < 0 )
            {
                rowStart = 0;
            }

            var rowEnd = shotRow + shotRadius;
            if (rowEnd > matrix.GetLength(0) - 1)
            {
                rowEnd = matrix.GetLength(0) - 1;
            }

            var colStart = shotCol - shotRadius;
            if (colStart < 0)
            {
                colStart = 0;
            }

            var colEnd = shotCol + shotRadius;
            if (colEnd > matrix.GetLength(1) - 1)
            {
                colEnd = matrix.GetLength(1) - 1;
            }

            for (int row = rowStart; row <= rowEnd; row++)
            {
                for (int col = colStart; col <= colEnd; col++)
                {
                    var inRadius =  (row - shotRow) * (row - shotRow) + (col - shotCol) * (col - shotCol) <= shotRadius * shotRadius;

                    if (inRadius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            FallingDown(matrix,colStart, colEnd, shotRow, rowEnd, shotRadius);

            PrintCharMatrix(matrix);

            //PrintSquareFromCharMatrix(matrix, 10, 0, 0);
        }

        private static void PrintCharMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void FallingDown(char[,] matrix,int colStart, int colEnd, int shotRow, int rowEnd, int radius)
        {
            for (int row = rowEnd; row >= shotRow; row--)
            {
                for (int col = colEnd; col >= colStart; col--)
                {
                    var counter = 1;
                    while (matrix[row, col] == ' ' && counter <= radius * 2 + 1)
                    {
                        SlideDownOnce(row, col, matrix);
                        counter++;
                    }
                }
            }
        }

        public static void SlideDownOnce(int bottom, int col, char[,] matrix)
        {
            for (int row = bottom; row > 0; row--)
            {
                matrix[row, col] = matrix[row - 1, col];
            }

            matrix[0, col] = ' ';
        }

        public static int[] ReadInts()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public static void PrintSquareFromCharMatrix(char[,] matrix, int squareSide, int bestStartY, int bestStartX)
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
