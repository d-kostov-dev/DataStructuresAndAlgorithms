namespace FindMajorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    /// Write a program to find the majorant of given array (if exists). 
    /// Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            int[] integersArray = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            try
            {
                string intArrayToString = string.Join(", ", integersArray);
                int majorantNumber = FindMajorantNumber(integersArray);

                Console.WriteLine("Majorant number of array {0} is {1}", intArrayToString, majorantNumber);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The array does not contain a majorant number!");
            }
        }

        /// <summary>
        /// Finds the majoran number in integers array. If no majorant is found an InvalidOperationException will be thrown.
        /// </summary>
        /// <param name="integersArray">Integers array to be searched for majorant.</param>
        /// <returns>The majorant number.</returns>
        public static int FindMajorantNumber(int[] integersArray)
        {
            int majorantValue = (integersArray.Length / 2) + 1;

            int majorantNumber =
                integersArray.GroupBy(x => x)
                .Where(g => g.Count() >= majorantValue)
                .First()
                .Key;

            return majorantNumber;
        }
    }
}
