namespace _11.ParkingSystem
{
    using System;
    using System.Linq;


    public class SoftUniParking
    {
        public static void Main()
        {
            var rowsAndCols = ReadInts();

            var parkingLot = new byte [rowsAndCols[0]][];

            var line = Console.ReadLine();
            while (line != "stop")
            {
                var tokens = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = tokens[0];
                var parkingRow = tokens[1];
                var parkingCol = tokens[2];

                if (parkingLot[parkingRow] == null)
                {
                    parkingLot[parkingRow] = new byte[rowsAndCols[1]];
                }

                if (parkingLot[parkingRow][parkingCol] == 0)
                {
                    parkingLot[parkingRow][parkingCol] = 1;
                    var distance = Math.Abs(entryRow - parkingRow) + 1 + parkingCol;

                    Console.WriteLine(distance);
                }
                else
                {
                    var freeSpotCol = GetFreeSpotCol(parkingLot, parkingRow, parkingCol);

                    if (freeSpotCol == -1)
                    {
                        Console.WriteLine($"Row {parkingRow} full");
                    }
                    else
                    {
                        var distance = Math.Abs(entryRow - parkingRow) + 1 + freeSpotCol;
                        parkingLot[parkingRow][freeSpotCol] = 1;
                        Console.WriteLine(distance);
                    }
                }

                line = Console.ReadLine();
            }

        }

        public static int GetFreeSpotCol(byte[][] parkingLot,int parkingRow, int parkingCol)
        {
            var col = -1;

            var spotOnLeftCol = -1;
            for (int i = parkingCol - 1; i >= 1; i--)
            {
                if (parkingLot[parkingRow][i] == 0)
                {
                    spotOnLeftCol = i;
                    break;
                }
            }

            var spotOnRightCol = -1;
            for (int i = parkingCol + 1; i < parkingLot[parkingRow].Length; i++)
            {
                if (parkingLot[parkingRow][i] == 0)
                {
                    spotOnRightCol = i;
                    break;
                }
            }

            if (spotOnRightCol == -1 && spotOnLeftCol == -1)
            {
                return -1;
            }
            else if (spotOnLeftCol == -1)
            {
                col = spotOnRightCol;
            }
            else if (spotOnRightCol == -1)
            {
                col = spotOnLeftCol;
            }
            else
            {
                col =  spotOnRightCol - parkingCol < parkingCol - spotOnLeftCol ?
                    spotOnRightCol:spotOnLeftCol;
            }

            return col;
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
