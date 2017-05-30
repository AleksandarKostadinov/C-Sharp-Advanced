namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    class EmaiSeparator
    {
        static void Main()
        {
            var line = Console.ReadLine();
            var emailContacts = new Dictionary<string, string>();

            while (line != "stop")
            {
                var name = line;
                var email = Console.ReadLine();

                if (!email.ToLower().EndsWith("us") && !email.ToLower().EndsWith("uk"))
                {
                    emailContacts[name] = email;
                }

                line = Console.ReadLine();
            }

            foreach (var contact in emailContacts)
            {
                var name = contact.Key;
                var email = contact.Value;
                Console.WriteLine($"{name} -> {email}");
            }
        }
    }
}
