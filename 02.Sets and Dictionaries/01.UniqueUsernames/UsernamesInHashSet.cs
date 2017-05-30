namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UsernamesInHashSet
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
