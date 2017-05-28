namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayOfNoDying
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var days = new int[n];
            var proximityStack = new Stack<int>();

            proximityStack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;
                var currentPlant = plants[i];

                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= currentPlant)
                {
                    maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
                }

                if (proximityStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                proximityStack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
