namespace _04.PascalTriangle
{
    using System;
    using System.Collections.Generic;

    public class PascalRecursive
    {
        public static long[][] pascalTriangle;
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            pascalTriangle = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascalTriangle[row] = new long[row + 1];
            }

            PrintPascalTriangle(n);
        }

        public static void PrintPascalTriangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write($"{GetPascal(i, j)} ");
                }

                Console.WriteLine();
            }
        }

        public static long GetPascal(int x, int y)
        {
            if (x == 0 || y == 0 || x == y)
            {
                return 1;
            }

            if (pascalTriangle[x][y] != 0)
            {
                return pascalTriangle[x][y];
            }

            return pascalTriangle[x][y] = GetPascal(x - 1, y - 1) + GetPascal(x - 1, y);
        }
    }
}
