namespace _2.SimpleCalculator
{
    using System;
    using System.Collections.Generic;

    public class StackCalculator
    {
        public static void Main()
        {
            var expression = Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                stack.Push(expression[i]);
            }

            var sum = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                var currentOperator = stack.Pop();
                var currentNumber = int.Parse(stack.Pop());

                if (currentOperator == "+")
                {
                    sum += currentNumber;
                }
                else if (currentOperator == "-")
                {
                    sum -= currentNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
