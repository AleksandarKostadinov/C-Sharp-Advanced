namespace SetsVsListsPerformance
{
    using System;
    using System.Collections.Generic;

    public class StopWatchExercise
    {
        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            watch.Start();

            var list = new List<string>();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i.ToString());
            }

            watch.Stop();

            Console.WriteLine("List adding: " + watch.ElapsedTicks);

            watch.Restart();

            list.Contains("888888");

            watch.Stop();

            Console.WriteLine("List Contains: " + watch.ElapsedTicks);

            watch.Restart();
            var set = new HashSet<string>();
            for (int i = 0; i < 1000000; i++)
            {
                set.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine("Set adding: " + watch.ElapsedTicks);

            watch.Restart();
            set.Contains("888888");

            watch.Stop();
            Console.WriteLine("Set contains: " + watch.ElapsedTicks);
        }
    }
}
