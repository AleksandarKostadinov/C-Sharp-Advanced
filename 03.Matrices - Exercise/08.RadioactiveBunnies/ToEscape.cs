namespace _08.RadioactiveBunnies
{
    using System;
    using System.Linq;

    public class ToEscape
    {
        public static Player player;
        public static char[,] lair;
        public static void Main()
        {
            var RowsAndCols = ReadInts();
            lair = ReadCharArray(RowsAndCols);
            var directions = Console.ReadLine();

            player = new Player();
            player.IsAlive = true;

            GetPlayersInitialPosition();

            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                MovePlayer(currentDirection);
                //Fill array with ones and zeroes so I have the currnt bunnies schema
                byte[,] currentBunnies = GetBunniesSchema();
                
                SpreadTheBunnies(currentBunnies);

                if (!player.IsAlive || player.IsOut)
                {
                    break;
                }
            }

            PrintCharMatrix(lair);

            if (player.IsAlive)
            {
                Console.Write("won: ");
            }
            else
            {
                Console.Write("dead: ");
            }

            Console.WriteLine($"{player.Row} {player.Col}");
        }

        public static byte[,] GetBunniesSchema()
        {
            var schema = new byte[lair.GetLength(0), lair.GetLength(1)];

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        schema[row, col] = 1;
                    }
                }
            }

            return schema;
        }

        public static void SpreadTheBunnies(byte[,] bunniesSchema)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (bunniesSchema[row, col] == 1)
                    {
                        var upperBunnyRow = row == 0 ? row : row - 1;
                        var lowerBunnyRow = row == lair.GetLength(0) - 1 ? row : row + 1;
                        var leftBunnyCol = col == 0 ? col : col - 1;
                        var rightBunnyCol = col == lair.GetLength(1) - 1 ? col : col + 1;

                        if (lair[upperBunnyRow, col] == 'P' 
                            || lair[lowerBunnyRow, col] == 'P'
                            || lair[row, leftBunnyCol] == 'P'
                            || lair[row, rightBunnyCol] == 'P')
                        {
                            player.IsAlive = false;
                        }

                        lair[upperBunnyRow, col] = 'B';
                        lair[lowerBunnyRow, col] = 'B';
                        lair[row, leftBunnyCol] = 'B';
                        lair[row, rightBunnyCol] = 'B';
                    }
                }
            }
        }

        public static void MovePlayer(char currentDirection)
        {
            if (currentDirection == 'U') {
                if (player.Row == 0) {
                    player.IsOut = true;
                    lair[player.Row, player.Col] = '.';
                }
                else if (lair[player.Row - 1, player.Col] == 'B') {
                    player.IsAlive = false;
                    lair[player.Row, player.Col] = '.';
                    player.Row -= 1;
                }
                else {
                    player.Row -= 1;
                    lair[player.Row, player.Col] = 'P';
                    lair[player.Row + 1, player.Col] = '.';
                }
            }
            else if (currentDirection == 'D') {
                if (player.Row == lair.GetLength(0) - 1) {
                    player.IsOut = true;
                    lair[player.Row, player.Col] = '.';
                }
                else if (lair[player.Row + 1, player.Col] == 'B') {
                    player.IsAlive = false;
                    lair[player.Row, player.Col] = '.';
                    player.Row += 1;
                }
                else {
                    player.Row += 1;
                    lair[player.Row, player.Col] = 'P';
                    lair[player.Row - 1, player.Col] = '.';
                }
            }
            else if (currentDirection == 'L') {
                if (player.Col == 0) {
                    player.IsOut = true;
                    lair[player.Row, player.Col] = '.';
                }
                else if (lair[player.Row, player.Col - 1] == 'B') {
                    player.IsAlive = false;
                    lair[player.Row, player.Col] = '.';
                    player.Col -= 1;
                }
                else {
                    player.Col -= 1;
                    lair[player.Row, player.Col] = 'P';
                    lair[player.Row, player.Col + 1] = '.';
                }
            }
            else if (currentDirection == 'R'){
                if (player.Col == lair.GetLength(1) - 1) {
                    player.IsOut = true;
                    lair[player.Row, player.Col] = '.';
                }
                else if (lair[player.Row, player.Col + 1] == 'B'){
                    player.IsAlive = false;
                    lair[player.Row, player.Col] = '.';
                    player.Col += 1;
                }
                else{
                    player.Col += 1;
                    lair[player.Row, player.Col] = 'P';
                    lair[player.Row, player.Col - 1] = '.';
                }
            }
        }

        public static void GetPlayersInitialPosition()
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'P')
                    {
                        player.Row = row;
                        player.Col = col;
                    }
                }
            }

        }

        public static char[,] ReadCharArray(params int[] rowsAndCols)
        {
            var matrix = new char[rowsAndCols[0],rowsAndCols[1]];

            for (int row = 0; row < rowsAndCols[0]; row++)
            {
                var currentLine = Console.ReadLine();

                for (int col = 0; col < rowsAndCols[1]; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            return matrix;
        }

        public static int[] ReadInts()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static void PrintCharMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }

    public class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsAlive { get; set; }
        public bool IsOut { get; set; }
    }
}
