namespace CountOccurrences
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that counts in a given array of double values the number of occurrences of each value. 
    /// Use Dictionary<TKey,TValue>. 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var numbersListOne = new double[] { 5.5, 3.3, 4.4, 5.5, 3.3, 2.2, 3.3 };
            var numbersListTwo = new List<double>() { 1.5, 2.3, 3.4, 1.5, 2.3, 3.2, 2.3 };

            var countedOccurrencesOne = CountOccurences(numbersListOne);
            var countedOccurrencesTwo = CountOccurences(numbersListTwo);

            Print(countedOccurrencesOne);
            Console.WriteLine();
            Print(countedOccurrencesTwo);
        }

        /// <summary>
        /// Counts the occurrences of each number in the list/array. Each number is saved as key 
        /// and the value is increased each time it's seen.
        /// </summary>
        /// <param name="inputArray">Input array/list with numbers.</param>
        /// <returns>Dictionary with "<number,count>".</returns>
        private static Dictionary<double, int> CountOccurences(IEnumerable<double> inputArray)
        {
            var resultingList = new Dictionary<double, int>();

            foreach (var number in inputArray)
            {
                if (!resultingList.ContainsKey(number))
                {
                    resultingList.Add(number, 0);
                }

                resultingList[number]++;
            }

            return resultingList;
        }

        /// <summary>
        /// Prints the dictionary content.
        /// </summary>
        private static void Print(IDictionary<double, int> inputList)
        {
            foreach (var item in inputList)
            {
                Console.WriteLine("Number: {0} - Count:{1}", item.Key, item.Value);
            }
        }
    }
}
