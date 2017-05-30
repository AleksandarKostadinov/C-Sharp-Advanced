namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CharCount
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var charCount = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charCount.ContainsKey(input[i]))
                {
                    charCount[input[i]] = 0;
                }

                charCount[input[i]]++;
            }

            foreach (var ch in charCount)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
