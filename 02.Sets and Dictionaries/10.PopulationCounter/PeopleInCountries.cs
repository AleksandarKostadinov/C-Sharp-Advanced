namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleInCountries
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().Split('|');
            var countries = new Dictionary<string, Dictionary<string, long>>();
            var countryWithPopulation = new Dictionary<string, long>();

            while (tokens[0] != "report")
            {
                var countryName = tokens[1];

                if (!countries.ContainsKey(countryName))
                {
                    countries[countryName] = new Dictionary<string, long>();
                }

                var cityName = tokens[0];
                var population = long.Parse(tokens[2]);

                countries[countryName][cityName] = population;

                tokens = Console.ReadLine().Split('|');
            }

            foreach (var country in countries)
            {
                var currentCountryName = country.Key;

                if (!countryWithPopulation.ContainsKey(currentCountryName))
                {
                    countryWithPopulation[currentCountryName] = 0;
                }

                var currentCity = country.Key;

                foreach (var pair in country.Value)
                {
                    countryWithPopulation[currentCountryName] += pair.Value;
                }
            }

            foreach (var country in countryWithPopulation.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");

                foreach (var city in countries[country.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
