namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GuestsNotCame
    {
        public static void Main()
        {
            var guests = new HashSet<string>();

            var currentGuest = Console.ReadLine();

            while (currentGuest != "PARTY")
            {
                guests.Add(currentGuest);

                currentGuest = Console.ReadLine();
            }

            var guestThatCame = Console.ReadLine();

            while (guestThatCame != "END")
            {
                if (guests.Contains(guestThatCame))
                {
                    guests.Remove(guestThatCame);
                }

                guestThatCame = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests.Where(g => g[0] >= '0' && g[0] <= '9').OrderBy(g => g))
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guests.Where(g => !(g[0] >= '0' && g[0] <= '9')).OrderBy(g => g))
            {
                Console.WriteLine(guest);
            }
        }
    }
}
