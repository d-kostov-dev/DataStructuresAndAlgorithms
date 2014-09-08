namespace CombinationsWithoutDuplicates
{
    using System;

    /// <summary>
    /// Modify the previous program to skip duplicates: 
    /// n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
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
                PrintCombinations(vector, i + 1, endNumber, currentIndex + 1);
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));
        }
    }
}
