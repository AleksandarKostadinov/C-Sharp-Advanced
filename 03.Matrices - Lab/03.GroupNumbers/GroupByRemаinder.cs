namespace _03.GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByRemаinder
    {
        public static void Main()
        {
            var nums = ReadInts();
            
            Console.WriteLine(string.Join(" ", nums.Where(n => n % 3 == 0)));
            Console.WriteLine(string.Join(" ", nums.Where(n => n % 3 == 1 || n % 3 == -1)));
            Console.WriteLine(string.Join(" ", nums.Where(n => n % 3 == 2 || n % 3 == -2)));
        }
        

        public static int[] ReadInts()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
