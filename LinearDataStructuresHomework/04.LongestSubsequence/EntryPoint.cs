namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a method that finds the longest subsequence of equal numbers in given List<int> 
    /// and returns the result as new List<int>. 
    /// Write a program to test whether the method works correctly.
    /// </summary>
    public class EntryPoint
    {
        private static readonly Random RandomNumberGenerator = new Random();

        public static void Main()
        {
            var integersList = GenerateIntsList();
            Console.WriteLine("Numbers list:\n " + string.Join(", ", integersList));

            Console.WriteLine(new string('-', 20));

            var longestSequence = FindLongesSequenceOfEqualNumbers(integersList);
            Console.WriteLine("Longest Sequence of equal numbers:\n " + string.Join(", ", longestSequence));

            Console.WriteLine(new string('-', 20));

            var longestSequenceTwo = FindLongesSequenceOfEqualNumbersTwo(integersList);
            Console.WriteLine("Longest Sequence of equal numbers VERSION 2:\n " + string.Join(", ", longestSequenceTwo));
        }

        /// <summary>
        /// Generates a random IList<int> with default size 100.
        /// </summary>
        /// <param name="listSize">Size of the list to be generated.</param>
        /// <returns>List with random numbers in the range 0 - 3</returns>
        private static IList<int> GenerateIntsList(int listSize = 100)
        {
            IList<int> integersList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                integersList.Add(RandomNumberGenerator.Next(0, 4));
            }

            return integersList;
        }

        /// <summary>
        /// Finds the longest sequence of equal numbers with O(n2) worst case.
        /// If there are 2 or more equaly longest sequences the last one will be returned.
        /// </summary>
        /// <param name="inputList">The list to search for the sequence.</param>
        /// <returns>New list with the found longest sequence.</returns>
        private static IList<int> FindLongesSequenceOfEqualNumbers(IList<int> inputList)
        {
            int longestSequenceCount = 0;
            int longestSequenceValue = 0;

            for (int i = 0; i < inputList.Count; i++)
            {
                int currentValue = inputList[i];
                int currentCount = 1;

                for (int j = i + 1; j < inputList.Count; j++)
                {
                    if (inputList[j] == currentValue)
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount >= longestSequenceCount)
                        {
                            longestSequenceCount = currentCount;
                            longestSequenceValue = currentValue;
                        }

                        break;
                    }
                }
            }

            // Creates the list to be returned
            var outputList = new List<int>(longestSequenceCount);
            outputList = Enumerable.Repeat(longestSequenceValue, longestSequenceCount).ToList();

            return outputList;
        }

        /// <summary>
        /// Finds the longest sequence of equal numbers with O(n) worst case (only one loop).
        /// If there are 2 or more equaly longest sequences the last one will be returned.
        /// </summary>
        /// <param name="inputList">The list to search for the sequence.</param>
        /// <returns>New list with the found longest sequence.</returns>
        private static IList<int> FindLongesSequenceOfEqualNumbersTwo(IList<int> inputList)
        {
            int listSize = inputList.Count;
            int longestSequenceCount = 0;
            int longestSequenceValue = 0;

            int currentLength = 1;

            for (int i = 1; i < listSize; i++)
            {
                if (inputList[i] == inputList[i - 1])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength >= longestSequenceCount)
                    {
                        longestSequenceCount = currentLength;
                        longestSequenceValue = inputList[i - 1];
                    }

                    // If longest count is larger than the rest of the list we break. 
                    // We can't find larger sequence at this point.
                    if (longestSequenceCount > listSize - 1 - i)
                    {
                        break;
                    }

                    currentLength = 1;
                }
            }

            // Creates the list to be returned
            var outputList = new List<int>(longestSequenceCount);
            outputList = Enumerable.Repeat(longestSequenceValue, longestSequenceCount).ToList();

            return outputList;
        }
    }
}
