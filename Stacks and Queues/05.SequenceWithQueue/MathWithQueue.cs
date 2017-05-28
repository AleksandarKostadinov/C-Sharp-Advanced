namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class MathWithQueue
    {
        public static void Main()
        {
            var n = BigInteger.Parse(Console.ReadLine());

            //S1 = N;
            //S2 = a*S1 + b;  S2 = S1   + 1;
            //S3 = a*S1 + b;  S3 = 2*S1 + 1;
            //S4 = a*S1 + b;  S4 = S1   + 2;
            //S5 = a*S2 + b;  S5 = S2   + 1; 
            //S6 = a*S2 + b;  S6 = 2*S2 + 1;
            //S7 = a*S2 + b;  S7 = S2   + 2;
            //S8 = a*S3 + b;  S8 = S3   + 1;

            // a = ((i + 1) % 3) % 2 + 1;
            // b = (i % 3) % 2 + 1;

            var sequeceQueue = new Queue<BigInteger>();

            sequeceQueue.Enqueue(n);

            var result = new List<BigInteger>();
            result.Add(n);

            for (var i = 2; i <= 50; i++)
            {
                BigInteger a = ((i + 1) % 3) % 2 + 1;
                BigInteger b = (i % 3) % 2 + 1;



                BigInteger currentElement = a * sequeceQueue.Peek() + b;

                sequeceQueue.Enqueue(currentElement);
                result.Add(currentElement);

                if (i % 3 == 1)
                {
                    sequeceQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
