using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbers
{
    class StackReversing
    {
        public static void Main()
        {
            var numbers = ReadListOfInt();

            var stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
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
