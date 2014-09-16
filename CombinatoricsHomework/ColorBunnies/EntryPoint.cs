namespace ColorBunnies
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012
    /// TASK 2
    /// 100 / 100
    /// </summary>
    public class EntryPoint
    {
        private static int[] bunniesAsked;
        private static Dictionary<int, int> bunniesCounted;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bunniesAsked = new int[n];
            bunniesCounted = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                bunniesAsked[i] = int.Parse(Console.ReadLine());
            }

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                int currentBunnyValue = bunniesAsked[i];

                if (bunniesCounted.ContainsKey(currentBunnyValue + 1))
                {
                    bunniesCounted[currentBunnyValue + 1]++;
                }
                else
                {
                    bunniesCounted.Add(currentBunnyValue + 1, 1);
                }
            }

            foreach (var item in bunniesCounted)
            {
                var num = (double)item.Value / (double)item.Key;
                count += (int)Math.Ceiling(num) * item.Key;
            }

            Console.WriteLine(count);
        }
    }
}
