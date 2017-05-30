namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Log
    {
        public static void Main()
        {
            var tokes = Console.ReadLine()
                .Split();
            var users = new SortedDictionary<string, Dictionary<string, int>>();

            while (tokes[0] != "end")
            {
                var userThird = tokes[2]
                    .Split('=');
                var userName = userThird[1];

                if (!users.ContainsKey(userName))
                {
                    users[userName] = new Dictionary<string, int>();
                }

                var IPThird = tokes[0].Split('=');
                var IP = IPThird[1];

                if (!users[userName].ContainsKey(IP))
                {
                    users[userName][IP] = 0;
                }

                users[userName][IP]++;

                tokes = Console.ReadLine().Split(' ');
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.Key + ":");

                var output = new List<string>();

                foreach (var ip in user.Value)
                {
                    output.Add(ip.Key + " => " + ip.Value);
                }

                Console.WriteLine(string.Join(", ", output) + ".");
            }
        }
    }
}
