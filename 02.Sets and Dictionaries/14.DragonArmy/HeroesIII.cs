namespace _14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HeroesIII
    {
        static void Main()
        {
            var dragonTypes = new Dictionary<string, SortedDictionary<string, int[]>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var dragonType = tokens[0];
                var dragonName = tokens[1];
                var damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                var health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                var armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (!dragonTypes.ContainsKey(dragonType))
                {
                    dragonTypes[dragonType] = new SortedDictionary<string, int[]>();
                }
                dragonTypes[dragonType][dragonName] = new int[] { damage, health, armor };
            }

            foreach (var type in dragonTypes)
            {
                var averageDamage = type.Value.Values
                    .Average(x => x[0]);
                var averageHealth = type.Value.Values
                    .Average(x => x[1]);
                var averageArmor = type.Value.Values
                    .Average(x => x[2]);

                Console.WriteLine($"{type.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in type.Value)
                {
                    var currentDamage = dragon.Value[0];
                    var currentHealth = dragon.Value[1];
                    var currentArmor = dragon.Value[2];

                    Console.WriteLine($"-{dragon.Key} -> damage: {currentDamage}, health: {currentHealth}, armor: {currentArmor}");
                }
            }
        }
    }
}
