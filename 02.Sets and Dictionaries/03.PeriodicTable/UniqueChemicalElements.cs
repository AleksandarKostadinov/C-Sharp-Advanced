namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UniqueChemicalElements
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var chemicalElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentElements = Console.ReadLine()
                    .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentElements.Length; j++)
                {
                    chemicalElements.Add(currentElements[j]);
                }
            }

            foreach (var element in chemicalElements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
