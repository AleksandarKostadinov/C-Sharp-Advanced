namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ParkingWithSets
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var tokens = Regex.Split(input, ", ");
                var direction = tokens[0];
                var car = tokens[1];

                if (direction == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    if (parking.Contains(car))
                    {
                        parking.Remove(car);
                    }
                }

                input = Console.ReadLine();
            }

            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
