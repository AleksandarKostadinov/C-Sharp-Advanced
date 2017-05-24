namespace _6.MathPotato
{
    using System;
    using System.Collections.Generic;

    public class RrimeToRemove
    {
        public static void Main()
        {
            var players = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var queueOfPlayers = new Queue<string>(players);
            var cycle = 1;
            while (queueOfPlayers.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queueOfPlayers.Enqueue(queueOfPlayers.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queueOfPlayers.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queueOfPlayers.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {queueOfPlayers.Dequeue()}");
        }

        public static bool IsPrime(int n)
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (n < 2)
            {
                return false;
            }

            return isPrime;
        }
    }
}
