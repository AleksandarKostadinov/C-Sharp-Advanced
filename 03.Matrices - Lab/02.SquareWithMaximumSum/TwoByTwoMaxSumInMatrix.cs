namespace _02.SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TwoByTwoMaxSumInMatrix
    {
        public static void Main()
        {
            var rowAndCol = ReadInts();
            var matrixRow = rowAndCol[0];
            var matrixCol = rowAndCol[1];

            int[,] matrix = ReadMatrix(matrixRow, matrixCol);

            var greatestSum = Int64.MinValue;
            var topLeftIndicesxOfSubmarix = new int[] { 0, 0 };

            for (int row = 0; row < matrixRow - 1; row++)
            {
                for (int col = 0; col < matrixCol - 1; col++)
                {
                    long currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > greatestSum)
                    {
                        greatestSum = currentSum;

                        topLeftIndicesxOfSubmarix[0] = row;
                        topLeftIndicesxOfSubmarix[1] = col;
                    }
                }
            }

            PrintSubMatrixAndSum(matrix, topLeftIndicesxOfSubmarix, greatestSum);
        }

        public static void PrintSubMatrixAndSum(int[,] matrix, int[] topLeftIndicesxOfSubmarix, long greatestSum)
        {
            var topLeft = matrix[topLeftIndicesxOfSubmarix[0], topLeftIndicesxOfSubmarix[1]];
            var topRight = matrix[topLeftIndicesxOfSubmarix[0], topLeftIndicesxOfSubmarix[1] + 1];
            var bottomLeft = matrix[topLeftIndicesxOfSubmarix[0] + 1, topLeftIndicesxOfSubmarix[1]];
            var bottomRight = matrix[topLeftIndicesxOfSubmarix[0] + 1, topLeftIndicesxOfSubmarix[1] + 1];

            Console.WriteLine($"{topLeft} {topRight}");
            Console.WriteLine($"{bottomLeft} {bottomRight}");

            Console.WriteLine(greatestSum);
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
