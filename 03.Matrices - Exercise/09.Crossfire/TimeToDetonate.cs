namespace _09.Crossfire
{
    using System;
    using System.Linq;

    public class TimeToDetonate
    {
        public static string[][] field;
        public static int[] dimentions;
        public static void Main()
        {
            dimentions = ReadInts();
            field = new string[dimentions[0]][];

            FillFieldWithCounter(dimentions[1]);

            var line = Console.ReadLine();
            while (line != "Nuke it from orbit")
            {
                var blastParameters = line
                    .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var blastRow = blastParameters[0];
                var blastCol = blastParameters[1];
                var blastRadius = blastParameters[2];

                Detonation(blastRow, blastCol, blastRadius);
                RenewTheField();

                line = Console.ReadLine();
            }

            PrintField();
        }

        public static void RenewTheField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == null)
                    {
                        field[row] = field[row].Where(n => n != null).ToArray();
                    }

                    if (field[row].Length == 0 && row != field.Length - 1)
                    {
                        field= field.Take(row).Concat(field.Skip(row + 1)).ToArray();
                        if (row != 0)
                        {
                            row--;
                        }
                    }
                }
            }
        }

        public static void SlideLeftOnce(int row, int col)
        {
            for (int i = dimentions[1] - 1; i > col; i--)
            {
                field[row][i - 1] = field[row][i];
            }

            field[row][dimentions[1] - 1] = null;
        }

        public static void PrintField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] != null)
                    {
                        Console.Write($"{field[row][col]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Detonation(int blastRow, int blastCol, int blastRadius)
        {
            if (blastRow >= 0 && blastRow < field.Length)
            {
                var startCol = blastCol - blastRadius < 0 ? 0 : blastCol - blastRadius;
                var endCol = blastCol + blastRadius > dimentions[1] - 1 ? dimentions[1] - 1 : blastCol + blastRadius;

                for (int col = startCol; col <= endCol; col++)
                {
                    try
                    {
                        field[blastRow][col] = null;
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }

            if (blastCol >= 0 && blastCol < dimentions[1])
            {
                var startRow = blastRow - blastRadius < 0 ? 0 : blastRow - blastRadius;
                var endRow = blastRow + blastRadius > field.Length - 1 ? field.Length - 1 : blastRow + blastRadius;

                for (int row = startRow; row <= endRow; row++)
                {
                    try
                    {
                        field[row][blastCol] = null;
                    }
                    catch (Exception) { }
                }
            }
        }

        public static void FillFieldWithCounter(int cols)
        {
            var counter = 1;

            for (int row = 0; row < field.Length; row++)
            {
                field[row] = new string[cols];

                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = (counter++).ToString();
                }
            }
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
