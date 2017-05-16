namespace _07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class ClosedParenthesis
    {
        public static void Main()
        {
            var parenthesis = Console.ReadLine().ToCharArray();

            var stack = new Stack<char>();
            stack.Push(parenthesis[0]);

            for (int i = 1; i < parenthesis.Length; i++)
            {
                var leftCh = '-';
                if (stack.Count > 0)
                {
                    leftCh = stack.Peek();
                }
                
                var rightCh = parenthesis[i];

                var balanced = AreBalenced(leftCh, rightCh);

                if (balanced)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(rightCh);
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public static bool AreBalenced(char leftChar, char rightChar)
        {
            bool balanced = false;

            if (leftChar == 32 && rightChar == 32)
            {
                balanced = true;
            }
            else if (leftChar == '(' && rightChar == ')')
            {
                balanced = true;
            }
            else if (leftChar == '[' && rightChar == ']')
            {
                balanced = true;
            }
            else if (leftChar == '{' && rightChar == '}')
            {
                balanced = true;
            }

            return balanced;
        }
    }
}
