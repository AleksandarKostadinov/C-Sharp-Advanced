namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionsWithQueue
    {
        public static void Main()
        {
            var parameters = ReadListOfInt();

            var numbers = ReadListOfInt();
            var toTake = parameters[0];

            var queue = new Queue<int>(numbers.Take(toTake));
            var dequeueCount = parameters[1];
            var checkNum = parameters[2];

            for (var i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Any())
            {
                if (queue.Contains(checkNum))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.ToList().Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        public static List<int> ReadListOfInt()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
    }
}
