using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {

        public static void Main()
        {
            var commands = ReadListOfInt();

            var numbers = ReadListOfInt();

            var stack = new Stack<int>(numbers.Take(commands[0]));

            var countOfPops = commands[1];

            for (var i = 0; i < countOfPops; i++)
            {
                var current = stack.Pop();
            }

            if (stack.Any())
            {
                if (stack.Contains(commands[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.ToArray().Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        public static List<int> ReadListOfInt()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
    }
}
