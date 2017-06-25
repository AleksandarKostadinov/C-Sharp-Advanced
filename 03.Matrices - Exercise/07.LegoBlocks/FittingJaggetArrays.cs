namespace _07.LegoBlocks
{
    using System;
    using System.Linq;

    public class FittingJaggetArrays
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var firstJagged = new int[n][];
            var secondJagged = new int[n][];
            var totalLength = 0;

            for (int i = 0; i < n; i++)
            {
                var currentArray = ReadInts();

                firstJagged[i] = currentArray;
                totalLength += currentArray.Length;
            }

            for (int i = 0; i < n; i++)
            {
                var currentArray = ReadInts();

                secondJagged[i] = currentArray;
                totalLength += currentArray.Length;
            }

            var resultLength = firstJagged[0].Length + secondJagged[0].Length;
            var theyFit = true;

            for (int i = 1; i < n; i++)
            {
                if (firstJagged[i].Length + secondJagged[i].Length != resultLength)
                {
                    theyFit = false;
                    break;
                }
            }


            if (theyFit)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"[{string.Join(", ", firstJagged[i])}, {string.Join(", ", secondJagged[i].Reverse())}]");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The total number of cells is: " + totalLength);
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
