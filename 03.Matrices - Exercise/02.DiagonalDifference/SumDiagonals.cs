namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class SumDiagonals
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var currentRow = ReadInts();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            var primaryDiagonalSum = GetPrimaryDiagonalSum(matrix);
            var secondaryDiagonalSum = GetSecondaryDiagonalSum(matrix);

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        public static long GetSecondaryDiagonalSum(int[,] matrix)
        {
            var sum = 0L;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == matrix.GetLength(1) - col - 1)
                    {
                        sum += matrix[row, col];
                    }
                }
            }


            return sum;
        }

        public static long GetPrimaryDiagonalSum(int[,] matrix)
        {
            var sum = 0L;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            return sum;
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
