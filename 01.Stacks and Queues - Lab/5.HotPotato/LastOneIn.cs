namespace _5.HotPotato
{
    using System;
    using System.Collections.Generic;

    public class LastOneIn
    {
        public static void Main()
        {
            var players = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var queueOfPlayers = new Queue<string>(players);
            var count = 1;
            while (queueOfPlayers.Count > 1)
            {
                if (count % n == 0)
                {
                    Console.WriteLine($"Removed {queueOfPlayers.Dequeue()}");
                }
                else
                {
                    queueOfPlayers.Enqueue(queueOfPlayers.Dequeue());
                }

                count++;
            }

            Console.WriteLine($"Last is {queueOfPlayers.Dequeue()}");
        }
    }
}
