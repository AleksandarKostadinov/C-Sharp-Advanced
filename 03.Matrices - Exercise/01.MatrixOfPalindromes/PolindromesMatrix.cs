namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PolindromesMatrix
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var dimensions = ReadInts();

            var matrix = new string[dimensions[0],dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                for (int col = 0; col < dimensions[1]; col++)
                {
                    matrix[row, col] += alphabet[row].ToString() + alphabet[row + col] + alphabet[row];

                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
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
