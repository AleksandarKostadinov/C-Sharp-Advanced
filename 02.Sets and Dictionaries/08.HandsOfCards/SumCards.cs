namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumCards
    {
        public static void Main()
        {
            Dictionary<string, int> cardPowers = GetCardPowers();
            Dictionary<string, int> cardTypes = GetCardTypes();
            var playerWithCards = new Dictionary<string, HashSet<int>>();

            var line = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            while (line[0] != "JOKER")
            {
                var name = line[0];

                if (!playerWithCards.ContainsKey(name))
                {
                    playerWithCards[name] = new HashSet<int>();
                }

                var playerCards = line[1]
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var card in playerCards)
                {
                    var currentPower = card.Substring(0, card.Length - 1);
                    var currentType = card[card.Length - 1].ToString();
                    var currentMultiply = cardPowers[currentPower] * cardTypes[currentType];
                    playerWithCards[name].Add(currentMultiply);

                }

                line = Console.ReadLine().Split(':');
            }

            foreach (var player in playerWithCards)
            {
                var sum = player.Value.Sum();
                Console.WriteLine($"{player.Key}: {sum}");
            }
        }

        public static Dictionary<string, int> GetCardPowers()
        {
            var cardPowers = new Dictionary<string, int>();

            for (int i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }

            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;

            return cardPowers;
        }

        public static Dictionary<string, int> GetCardTypes()
        {
            var cardTypes = new Dictionary<string, int>();

            cardTypes["S"] = 4;
            cardTypes["H"] = 3;
            cardTypes["D"] = 2;
            cardTypes["C"] = 1;

            return cardTypes;
        }
    }
}
