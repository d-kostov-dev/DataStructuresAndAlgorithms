namespace CountOccurrence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
    /// how many times each of them occurs. 
    /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    /// 2 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            int[] integersArray = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            ShowOccurrenceCount(integersArray);
            ShowOccurrenceCountLINQ(integersArray);
        }

        /// <summary>
        /// Shows the occurrence count for each number in integer array.
        /// </summary>
        public static void ShowOccurrenceCount(int[] integersArray)
        {
            var occurrenceDictionary = new Dictionary<int, int>();

            for (int i = 0; i < integersArray.Length; i++)
            {
                int currentNum = integersArray[i];

                if (!occurrenceDictionary.ContainsKey(currentNum))
                {
                    occurrenceDictionary.Add(currentNum, 1);
                }
                else
                {
                    occurrenceDictionary[currentNum]++;
                }
            }

            foreach (var item in occurrenceDictionary)
            {
                Console.WriteLine("The number {0} occurs {1} times!", item.Key, occurrenceDictionary[item.Key]);
            }
        }

        /// <summary>
        /// Shows the occurrence count for each number in integer array using LINQ.
        /// </summary>
        public static void ShowOccurrenceCountLINQ(int[] integersArray)
        {
            var result = integersArray.GroupBy(x => x).OrderBy(g => g.Key);

            foreach (var item in result)
            {
                Console.WriteLine("The number {0} occurs {1} times!", item.Key, item.Count());
            }
        }
    }
}
