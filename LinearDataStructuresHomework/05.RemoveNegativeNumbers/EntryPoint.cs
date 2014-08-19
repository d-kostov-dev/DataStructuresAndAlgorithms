namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class EntryPoint
    {
        private static readonly Random RandomNumberGenerator = new Random();

        public static void Main()
        {
            var integersList = GenerateIntsList();
            Console.WriteLine(string.Join(", ", integersList));

            Console.WriteLine(new string('-', 20));

            var positiveIntegersList = RemoveNegativeNumbers(integersList);
            Console.WriteLine(string.Join(", ", positiveIntegersList));

            Console.WriteLine(new string('-', 20));

            var positiveIntegersListLINQ = RemoveNegativeNumbersWithLINQ(integersList);
            Console.WriteLine(string.Join(", ", positiveIntegersListLINQ));
        }

        /// <summary>
        /// Generates a random IList<int> with default size 20.
        /// </summary>
        /// <param name="listSize">Size of the list to be generated.</param>
        /// <returns>List with random numbers in the range -10 to 10</returns>
        private static IList<int> GenerateIntsList(int listSize = 20)
        {
            IList<int> integersList = new List<int>();

            for (int i = 0; i < listSize; i++)
            {
                integersList.Add(RandomNumberGenerator.Next(-10, 11));
            }

            return integersList;
        }

        /// <summary>
        /// Removes negative numbers from list of integers
        /// </summary>
        /// <param name="numbersList">The list that we are going to loop through</param>
        /// <returns>A new list with only the positive numbers left</returns>
        private static IList<int> RemoveNegativeNumbers(IList<int> numbersList)
        {
            // We will use a new list where we will add only the positive numbers. 
            // We are not going to rearange the old list each time we see a negative number.
            var positiveList = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                int currentNumber = numbersList[i];

                if (currentNumber >= 0)
                {
                    positiveList.Add(currentNumber);
                }
            }

            return positiveList;
        }

        /// <summary>
        /// Same as previous method but here i'm using LINQ
        /// </summary>
        private static IList<int> RemoveNegativeNumbersWithLINQ(IList<int> numbersList)
        {
            IList<int> resultingList = numbersList.Where(x => x >= 0).ToList();
            return resultingList;
        }
    }
}
