namespace SortList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line 
    /// and sorts them in an increasing order.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            IList<int> integersList = new List<int>();

            // We keep storing numbers till there is no empty line entered to the console.
            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == string.Empty)
                {
                    break;
                }

                int currentNumber = 0;

                if (int.TryParse(inputLine, out currentNumber))
                {
                    integersList.Add(currentNumber);
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer number.");
                }
            }

            SortIntList(integersList);

            Console.WriteLine(string.Join(", ", integersList));
        }

        /// <summary>
        /// Sorts all integer in a given list.
        /// List types are passed by refference so i'm using void method. The list will be sorted.
        /// I'm using Selection Sort: http://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        /// <param name="integersList">The integers list to be sorted.</param>
        private static void SortIntList(IList<int> integersList)
        {
            int minValue;

            for (int i = 0; i < integersList.Count; i++)
            {
                minValue = i;

                for (int j = i + 1; j < integersList.Count; j++)
                {
                    if (integersList[j] < integersList[minValue])
                    {
                        minValue = j;
                    }
                }

                if (minValue != i)
                {
                    SwapPositions(integersList, i, minValue);
                }
            }
        }

        /// <summary>
        /// Used by the sorting method, this method swaps the positions of two numbers.
        /// </summary>
        /// <param name="integersList">The list where we will swap.</param>
        /// <param name="firstIndex">First number index.</param>
        /// <param name="secondIndex">Second number index.</param>
        private static void SwapPositions(IList<int> integersList, int firstIndex, int secondIndex)
        {
            int oldValue = integersList[firstIndex];
            integersList[firstIndex] = integersList[secondIndex];
            integersList[secondIndex] = oldValue;
        }
    }
}
