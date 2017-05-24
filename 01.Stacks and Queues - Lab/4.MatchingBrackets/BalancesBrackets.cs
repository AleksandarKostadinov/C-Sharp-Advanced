namespace _4.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class BalancesBrackets
    {
        public static void Main()
        {
            var expression = Console.ReadLine();

            var indicesOfBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                var currentCh = expression[i];

                if (currentCh == '(')
                {
                    indicesOfBrackets.Push(i);
                }

                if (currentCh == ')')
                {
                    var startingIndex = indicesOfBrackets.Pop();

                    for (int j = startingIndex; j <= i; j++)
                    {
                        Console.Write(expression[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
