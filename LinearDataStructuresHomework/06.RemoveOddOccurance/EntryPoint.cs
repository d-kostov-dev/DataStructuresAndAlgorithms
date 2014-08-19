namespace RemoveOddOccurance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. 
    /// Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var integersList = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine("Original List: {0}", string.Join(", ", integersList));

            RemoveOddOccurances(integersList);

            Console.WriteLine("Removed ODD: {0}", string.Join(", ", integersList));
        }

        /// <summary>
        /// Removes all numbers that have odd number of occurrences.
        /// </summary>
        /// <param name="integersList">The list that is going to be cleared.</param>
        public static void RemoveOddOccurances(List<int> integersList)
        {
            var resultingList = integersList.GroupBy(x => x);

            foreach (var item in resultingList)
            {
                if (item.Count() % 2 != 0)
                {
                    integersList.RemoveAll(x => x == item.Key);
                }
            }
        }
    }
}
