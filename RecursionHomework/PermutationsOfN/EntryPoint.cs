namespace PermutationsOfN
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. 
    /// Example:
    /// n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("N: ");
            int n = int.Parse(Console.ReadLine());

             int[] vector = new int[n];

            PrintPermutations(vector, 0);
        }

        private static void PrintPermutations(int[] vector, int currentIndex)
        {
            if (currentIndex >= vector.Length)
            {
                PrintVector(vector);
                return;
            }

            for (int i = 1; i <= vector.Length; i++)
            {
                if (!IsUsed(i, vector))
                {
                    vector[currentIndex] = i;
                    PrintPermutations(vector, currentIndex + 1);
                    vector[currentIndex] = 0;
                }
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));
        }

        private static bool IsUsed(int number, int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == number)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
