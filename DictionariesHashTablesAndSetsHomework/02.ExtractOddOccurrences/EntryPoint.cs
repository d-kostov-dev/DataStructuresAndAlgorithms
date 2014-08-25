namespace ExtractOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
    /// Example: {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL} 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var stringsArray = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var extractedStrings = ExtractOddOccurrences(stringsArray);
            Console.WriteLine(string.Join(",", extractedStrings));

            var stringsArrayTwo = new string[] { "SQL", "SQL", "JS", "PHP", "PHP", "SQL" };
            var extractedStringsTwo = ExtractOddOccurrences(stringsArrayTwo);
            Console.WriteLine(string.Join(",", extractedStringsTwo));
        }

        /// <summary>
        /// Extracts all strings with odd occurrence in list/array. Using dictionary to count the occurances and LINQ
        /// to return IEnumerable with only the strings that match the criteria.
        /// </summary>
        /// <param name="stringsArray">Strings list/array.</param>
        /// <returns>Strings Enumerable with only odd occurrence words.</returns>
        private static IEnumerable<string> ExtractOddOccurrences(IEnumerable<string> stringsArray)
        {
            var resultingList = new Dictionary<string, int>();

            foreach (var item in stringsArray)
            {
                if (!resultingList.ContainsKey(item))
                {
                    resultingList.Add(item, 0);
                }

                resultingList[item]++;
            }

            return resultingList.Where(word => word.Value % 2 != 0).Select(str => str.Key);
        }
    }
}
