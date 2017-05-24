namespace _3.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class StackConverter
    {
        public static void Main()
        {
            var decimalNum = int.Parse(Console.ReadLine());

            if (decimalNum == 0)
            {
                Console.WriteLine(0);
            }

            var remainders = new Stack<int>();

            while (decimalNum > 0)
            {
                var remainder = decimalNum % 2;

                remainders.Push(remainder);

                decimalNum /= 2;
            }

            while (remainders.Count > 0)
            {
                Console.Write(remainders.Pop());
            }

            Console.WriteLine();
        }
    }
}
