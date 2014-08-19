namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when empty line is entered. 
    /// Calculate and print the sum and average of the elements of the sequence. 
    /// Keep the sequence in List<int>.
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

            // Calculate Average and Sum
            int averageValue = CalculateAvarageFromList(integersList);
            int sumValue = CalculateSumFromList(integersList);

            // And print
            Console.WriteLine(string.Format("Average value: {0}", averageValue));
            Console.WriteLine(string.Format("Sum value: {0}", sumValue));
        }

        /// <summary>
        /// Calculates sum from all the items in an integer list.
        /// </summary>
        /// <param name="integersList">The integer list to sum.</param>
        /// <returns>The sum of all numbers in the list.</returns>
        private static int CalculateSumFromList(IList<int> integersList)
        {
            int sum = 0;

            for (int i = 0; i < integersList.Count; i++)
            {
                sum += integersList[i];
            }

            return sum;
        }

        /// <summary>
        /// Calculates the average value from all numbers in a list.
        /// </summary>
        /// <param name="integersList">The numbers list.</param>
        /// <returns>The average value of all numbers.</returns>
        private static int CalculateAvarageFromList(IList<int> integersList)
        {
            int average = 0;

            for (int i = 0; i < integersList.Count; i++)
            {
                average += integersList[i];
            }

            average /= integersList.Count;

            return average;
        }
    }
}
