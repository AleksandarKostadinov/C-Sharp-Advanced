namespace _13.SerbianUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var venuesWithSingers = new Dictionary<string, Dictionary<string, int>>();
            var line = string.Empty;

            while (line != "End")
            {
                line = Console.ReadLine();

                if (!line.Contains(" @"))
                {
                    continue;
                }
                var tokens = line.Split();

                var ticketsCount = 0;
                var ticketPrice = 0;

                var lastTokenIsNum = int.TryParse(tokens[tokens.Length - 1], out ticketsCount);
                var secondLastTokenInNum = int.TryParse(tokens[tokens.Length - 2], out ticketPrice);
            
                if (!(lastTokenIsNum && secondLastTokenInNum))
                {
                    continue;
                }

                line = line
                    .Substring(0, line
                    .LastIndexOf(tokens[tokens.Length - 1]));
                line = line
                    .Substring(0, line
                    .LastIndexOf(tokens[tokens.Length - 2]));

                var singerName = line
                    .Split('@')
                    .First()
                    .Trim();
                var venueName = line
                    .Split('@')
                    .Last()
                    .Trim();

                if (!venuesWithSingers.ContainsKey(venueName))
                {
                    venuesWithSingers[venueName] = new Dictionary<string, int>();
                }
                if (!venuesWithSingers[venueName].ContainsKey(singerName))
                {
                    venuesWithSingers[venueName][singerName] = 0;
                }
                venuesWithSingers[venueName][singerName] += ticketPrice * ticketsCount;
            }

            foreach (var venue in venuesWithSingers)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venuesWithSingers[venue.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
