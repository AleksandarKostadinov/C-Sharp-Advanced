using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _12.StringMatrixRotation
{
    using System;

    public class RotatingMatrix
    {
        public static void Main()
        {
            var degries = int.Parse(
                Regex.Match(Console.ReadLine(), @"Rotate\((\d+)\)")
                .Groups[1].ToString());
            degries %= 360;

            var matrix = new List<string>();
            var maxStrLength = 0;

            var line = Console.ReadLine();
            while (line != "END")
            {
                matrix.Add(line);
                if (line.Length > maxStrLength)
                {
                    maxStrLength = line.Length;
                }
                line = Console.ReadLine();
            }

            if (degries == 0)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < maxStrLength; j++)
                    {
                        try
                        {
                            Console.Write(matrix[i][j]);
                        }
                        catch
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (degries == 90)
            {
                for (int j = 0; j < maxStrLength; j++)
                {
                    for (int i = matrix.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            Console.Write(matrix[i][j]);
                        }
                        catch
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (degries == 180)
            {
                for (int i = matrix.Count - 1; i >= 0; i--)
                {
                    for (int j = maxStrLength - 1; j >= 0; j--)
                    {
                        try
                        {
                            Console.Write(matrix[i][j]);
                        }
                        catch
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int j = maxStrLength - 1; j >= 0; j--)
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        try
                        {
                            Console.Write(matrix[i][j]);
                        }
                        catch
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
