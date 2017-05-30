namespace _06.AMiner_sTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            var resource = Console.ReadLine();
            var resourceQuantity = new Dictionary<string, long>();

            while (resource != "Stop")
            {
                var quantity = long.Parse(Console.ReadLine());

                if (!resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] = 0;
                }

                resourceQuantity[resource] += quantity;

                resource = Console.ReadLine();
            }

            foreach (var pair in resourceQuantity)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
