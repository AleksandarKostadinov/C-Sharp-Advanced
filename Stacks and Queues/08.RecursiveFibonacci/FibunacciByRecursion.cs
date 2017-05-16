namespace _08.RecursiveFibonacci
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;

    public class FibunacciByRecursion
    {
        public static BigInteger[] memo;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            memo = new BigInteger[n + 1];

            BigInteger fibunacciNum = CalcFibunacci(n);

            Console.WriteLine(fibunacciNum);
        }

        public static BigInteger CalcFibunacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = CalcFibunacci(n - 1) + CalcFibunacci(n - 2);

            return memo[n];
        }
    }
}
