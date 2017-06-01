namespace _01.SumOfAllElementsOfMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumJaggedArray
    {
        public static void Main()
        {
            var rowAndCol = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = rowAndCol[0];

            var jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            var sum = 0L;

            foreach (var row in jaggedArray)
            {
                foreach (var num in row)
                {
                    sum += num;
                }
            }

            Console.WriteLine($"{rows}\r\n{rowAndCol[1]}\r\n{sum}");
        }
    }
}
