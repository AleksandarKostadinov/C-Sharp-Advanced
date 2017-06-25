namespace _10.TheHeiganDance
{
    using System;
    using System.Collections.Generic;

    public class TheLastBattle
    {
        public static Player player;
        public static int[,,] chamber;

        public static void Main()
        {
            var playerDamage = double.Parse(Console.ReadLine().Trim());
            player = new Player();

            player.Damage = playerDamage;
            player.Row = 7;
            player.Col = 7;
            player.IsAlive = true;
            player.HitPoints = 18500;
            player.KilledBy = string.Empty;
            player.IsHitFromCloud = false;

            var heigansHitPoints = 3000000d;

            chamber = new int[15, 15, 3];

            while (player.IsAlive)
            {
                DamageFromLastTurn();
                heigansHitPoints -= player.Damage;

                if (heigansHitPoints <= 0 || !player.IsAlive)
                {
                    break;
                }
                var spellTokens = Console.ReadLine()
                    .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var currentSpell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                SpellIsCasted(currentSpell, spellRow, spellCol);
                PlayerTurn();
                PlayerTakesDamage();
                DamageDissipates(currentSpell, spellRow, spellCol);

                //Console.WriteLine(player.Row + " " + player.Col);
            }

            Console.Write($"Heigan: ");
            if (heigansHitPoints > 0)
            {
                Console.WriteLine($"{heigansHitPoints:f2}");
            }
            else
            {
                Console.WriteLine("Defeated!");
            }

            Console.Write("Player: ");
            if (player.IsAlive)
            {
                Console.WriteLine(player.HitPoints);
            }
            else
            {
                Console.WriteLine($"Killed by {player.KilledBy}");
            }

            Console.WriteLine($"Final position: {player.Row}, {player.Col}");
        }

        private static void DamageFromLastTurn()
        {
            if (player.IsHitFromCloud)
            {
                player.HitPoints -= 3500;
                if (player.HitPoints <= 0)
                {
                    player.IsAlive = false;
                    player.KilledBy = "Plague Cloud";
                }
                player.IsHitFromCloud = false;
            }
        }

        public static void DamageDissipates(string spell, int spellRow, int spellCol)
        {
            for (int row = 0; row < chamber.GetLength(0); row++)
            {
                for (int col = 0; col < chamber.GetLength(1); col++)
                {
                    if (chamber[row, col, 1] > 0)
                    {
                        chamber[row, col, 1] -= 3500;
                    }
                }
            }

            for (int row = spellRow - 1; row <= spellRow + 1; row++)
            {
                for (int col = spellCol - 1; col <= spellCol + 1; col++)
                {
                    if (spell == "Cloud")
                    {
                        try
                        {
                            chamber[row, col, 1] += 3500;
                            chamber[row, col, 0] = 0;
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            chamber[row, col, 2] = 0;
                        }
                        catch { }
                    }
                }
            }
        }

        public static void PlayerTakesDamage()
        {
            player.HitPoints -= chamber[player.Row, player.Col, 0];
            if (chamber[player.Row, player.Col, 0] > 0)
            {
                player.IsHitFromCloud = true;
            }

            if (player.HitPoints <= 0)
            {
                player.IsAlive = false;
                player.KilledBy = "Plague Cloud";
                return;
            }

            player.HitPoints -= chamber[player.Row, player.Col, 2];

            if (player.HitPoints < 0)
            {
                player.IsAlive = false;
                player.KilledBy = "Eruption";
            }
        }

        public static void PlayerTurn()
        {
            var playerIsUnderAttack = chamber[player.Row, player.Col, 0] > 0
                || chamber[player.Row, player.Col, 2] > 0;

            if (playerIsUnderAttack)
            {
                if (player.Row != 0
                    && chamber[player.Row - 1, player.Col, 0] == 0
                    && chamber[player.Row - 1, player.Col, 2] == 0)
                {
                    player.Row--;
                }
                else if (player.Col != chamber.GetLength(1) - 1
                    && chamber[player.Row, player.Col + 1, 0] == 0
                    && chamber[player.Row, player.Col + 1, 2] == 0)
                {
                    player.Col++;
                }
                else if (player.Row != chamber.GetLength(0) - 1
                   && chamber[player.Row + 1, player.Col, 0] == 0
                   && chamber[player.Row + 1, player.Col, 2] == 0)
                {
                    player.Row++;
                }
                else if (player.Col != 0
                   && chamber[player.Row, player.Col - 1, 0] == 0
                   && chamber[player.Row, player.Col - 1, 2] == 0)
                {
                    player.Col--;
                }
            }
        }

        public static void SpellIsCasted(string currentSpell, int spellRow, int spellCol)
        {
            if (currentSpell == "Cloud")
            {
                for (int row = spellRow - 1; row <= spellRow + 1; row++)
                {
                    for (int col = spellCol - 1; col <= spellCol + 1; col++)
                    {
                        try
                        {
                            chamber[row, col, 0] += 3500;
                        }
                        catch { }
                    }
                }
            }
            else if (currentSpell == "Eruption")
            {
                for (int row = spellRow - 1; row <= spellRow + 1; row++)
                {
                    for (int col = spellCol - 1; col <= spellCol + 1; col++)
                    {
                        try
                        {
                            chamber[row, col, 2] = 6000;
                        }
                        catch{ }
                    }
                }
            }
        }
    }

    public class Player
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsAlive { get; set; }
        public int HitPoints { get; set; }
        public double Damage { get; set; }
        public string KilledBy { get; set; }
        public bool IsHitFromCloud { get; set; }
    }
}
