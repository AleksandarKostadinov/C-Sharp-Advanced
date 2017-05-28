namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxElStack
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];

                if (command == "1")
                {
                    var currentNum = int.Parse(tokens[1]);
                    stack.Push(currentNum);


                    if (!maxStack.Any())
                    {
                        maxStack.Push(currentNum);
                    }
                    else if (currentNum > maxStack.Peek())
                    {
                        maxStack.Push(currentNum);
                    }
                }
                else if (command == "2")
                {
                    if (stack.Peek() == maxStack.Peek())
                    {
                        maxStack.Pop();
                    }

                    stack.Pop();
                }
                else
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
