namespace _03.SquaresInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountTwoByTwoWithEqualChars
    {
        public static void Main()
        {
            var dimensions = ReadInts();

            var matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                var currentRow = Console.ReadLine().Replace(" ", "");

                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var areEqual = matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1];

                    if (areEqual)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
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
