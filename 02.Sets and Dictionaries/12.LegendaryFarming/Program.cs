namespace _12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var legendaryItems = new Dictionary<string, long>();
            legendaryItems["fragments"] = 0;
            legendaryItems["motes"] = 0;
            legendaryItems["shards"] = 0;
            var junk = new SortedDictionary<string, long>();

            var itemObtained = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split();

                for (int j = 0; j < tokens.Length - 1; j += 2)
                {
                    var itemCount = long.Parse(tokens[j]);
                    var item = tokens[j + 1];

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += itemCount;

                        if (legendaryItems["shards"] >= 250)
                        {
                            legendaryItems["shards"] -= 250;
                            itemObtained = "Shadowmourne";
                            i = 10;
                            break;
                        }
                        else if (legendaryItems["fragments"] >= 250)
                        {
                            legendaryItems["fragments"] -= 250;
                            itemObtained = "Valanyr";
                            i = 10;
                            break;
                        }
                        else if (legendaryItems["motes"] >= 250)
                        {
                            legendaryItems["motes"] -= 250;
                            itemObtained = "Dragonwrath";
                            i = 10;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(item))
                        {
                            junk[item] = 0;
                        }

                        junk[item] += itemCount;
                    }
                }
            }

            Console.WriteLine(itemObtained + " obtained!");

            foreach (var item in legendaryItems.OrderByDescending(x => x.Value))
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

            foreach (var item in junk)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
