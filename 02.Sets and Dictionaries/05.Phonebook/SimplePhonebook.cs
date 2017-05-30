namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class SimplePhonebook
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var phonebook = new SortedDictionary<string, string>();

            while (input != "search")
            {
                var tokens = input.Split('-');

                phonebook[tokens[0]] = tokens[1];

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
