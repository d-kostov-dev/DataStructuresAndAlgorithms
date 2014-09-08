namespace CombinationsWithDuplicates
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. 
    /// Example: n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("N:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("K:");
            int k = int.Parse(Console.ReadLine());

            int[] vector = new int[k];

            PrintCombinations(vector, 1, n, 0);
        }

        private static void PrintCombinations(int[] vector, int startNumber, int endNumber, int currentIndex)
        {
            if (currentIndex == vector.Length)
            {
                PrintVector(vector);
                return;
            }

            for (int i = startNumber; i <= endNumber; i++)
            {
                vector[currentIndex] = i;
                PrintCombinations(vector, i, endNumber, currentIndex + 1);
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));
        }
    }
}
