namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    public class ThreeByThreeMaxSum
    {
        public const int  SquareSide = 3;
        public static void Main()
        {
            var rowAndCol = ReadInts();
            var matrixRow = rowAndCol[0];
            var matrixCol = rowAndCol[1];

            int[,] matrix = ReadMatrix(matrixRow, matrixCol);

            var greatestSum = Int64.MinValue;

            var bestStartX = 0;
            var bestStartY = 0;

            for (int row = 0; row < matrixRow - 2; row++)
            {
                for (int col = 0; col < matrixCol - 2; col++)
                {
                    var startY = row;
                    var startX = col;

                    long currentSum = GetSquareSum(matrix, SquareSide, startX, startY);
                        

                    if (currentSum > greatestSum)
                    {
                        greatestSum = currentSum;

                        bestStartY = row;
                        bestStartX = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {greatestSum}");

            PrintSquareFromMatrix(matrix, SquareSide, bestStartY, bestStartX);
        }

        public static void PrintSquareFromMatrix(int[,] matrix, int squareSide,int bestStartY,int bestStartX)
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

        public static long GetSquareSum(int[,] matrix, int squareSide, int startX, int startY)
        {
            long sum = 0L;

            for (int row = startY; row < matrix.GetLength(0) && row < squareSide + startY; row++)
            {
                for (int col = startX; col < matrix.GetLength(0) && col < squareSide + startX; col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }

        public static int[,] ReadMatrix(int matrixRow, int matrixCol)
        {
            var matrix = new int[matrixRow, matrixCol];

            for (int row = 0; row < matrixRow; row++)
            {
                var currentRow = ReadInts();
                for (int col = 0; col < matrixCol; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

        public static int[] ReadInts()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
