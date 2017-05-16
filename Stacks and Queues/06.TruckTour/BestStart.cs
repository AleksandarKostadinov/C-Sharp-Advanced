namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class BestStart
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new List<Pump>();

            for (var i = 0; i < n; i++)
            {
                var pumpTokens = ReadListOfInt();

                var fuelAdded = pumpTokens[0];
                var distanceToNextPump = pumpTokens[1];

                var currentPump = new Pump();

                currentPump.Fuel = fuelAdded;
                currentPump.Distance = distanceToNextPump;

                pumps.Add(currentPump);
            }

            var canFinish = false;
            var bestStart = 0;

            for (var i = 0; i < n; i++)
            {
                if (pumps[i].Fuel < pumps[i].Distance)
                {
                    continue;
                }
                
                BigInteger truck = 0;

                for (var j = 0; j < n; j++)
                {
                    var currentIndex = (i + j) % n;

                    truck = truck + pumps[currentIndex].Fuel - pumps[currentIndex].Distance;

                    if (truck < 0)
                    {
                        break;
                    }
                    else if (j == n - 1)
                    {
                        canFinish = true;
                    }
                }

                if (canFinish)
                {
                    bestStart = i;
                    break;
                }
            }

            Console.WriteLine(bestStart);
        }

        public static List<long> ReadListOfInt()
        {
            List<long> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            return numbers;
        }
    }
}
