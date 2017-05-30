namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TimeLogged
    {
        public static void Main()
        {
            var usersLog = new SortedDictionary<string, SortedDictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var userName = tokens[1];

                if (!usersLog.ContainsKey(userName))
                {
                    usersLog[userName] = new SortedDictionary<string, int>();
                }

                var ip = tokens[0];

                if (!usersLog[userName].ContainsKey(ip))
                {
                    usersLog[userName][ip] = 0;
                }

                var timeLogged = int.Parse(tokens[2]);

                usersLog[userName][ip] += timeLogged;
            }

            foreach (var user in usersLog)
            {
                var totalSum = user.Value.Values
                    .ToList()
                    .Sum();

                var ipes = string.Join(", ", user.Value.Keys.ToList());

                Console.WriteLine($"{user.Key}: {totalSum} [{ipes}]");
            }
        }
    }
}
