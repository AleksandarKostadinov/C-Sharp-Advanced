namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersIsSets
    {
        public static void Main()
        {
            var nAndM = ReadListOfInts();
            var n = nAndM[0];
            var m = nAndM[1];

            var nSet = new HashSet<double>();
            var mSet = new HashSet<double>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(double.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mSet.Add(double.Parse(Console.ReadLine()));
            }

            foreach (var number in nSet)
            {
                if (mSet.Contains(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        public static List<int> ReadListOfInts()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
    }
}
