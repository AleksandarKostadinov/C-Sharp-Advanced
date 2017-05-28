namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var students = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var averigeGrade = ReadArrayOfDouble().Average();

                students[name] = averigeGrade;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value}");
            }
        }

        public static double[] ReadArrayOfDouble()
        {
            var numbers = Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            return numbers;
        }
    }
}
