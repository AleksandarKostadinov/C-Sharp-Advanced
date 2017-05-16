namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class FibunacciByStack
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fibunacciStack = new Stack<long>();
            fibunacciStack.Push(1);
            fibunacciStack.Push(1);

            var first = 1L;
            var second = 1L;

            for (int i = 3; i <= n; i++)
            {
                var third = first + fibunacciStack.Peek();

                fibunacciStack.Push(third);
                first = second;
                second = third;
            }

            Console.WriteLine(fibunacciStack.Peek());
        }
    }
}
