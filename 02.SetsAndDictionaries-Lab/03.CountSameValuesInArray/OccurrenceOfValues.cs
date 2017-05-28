namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OccurrenceOfValues
    {
        public static void Main()
        {
            double[] numbers = ReadArrayOfDouble();

            var occurrence = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                if (!occurrence.ContainsKey(currentNumber))
                {
                    occurrence[currentNumber] = 0;
                }

                occurrence[currentNumber]++;
            }

            foreach (var num in occurrence)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }

        public static double[] ReadArrayOfDouble()
        {
            var numbers = Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            return numbers;
        }
    }
}
