namespace NestedLoops
{
    using System;

    /// <summary>
    /// Write a recursive program that simulates the execution of n nested loops from 1 to n. 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("N: ");
            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];
            NestedLoop(vector, 0);
        }

        private static void NestedLoop(int[] vector, int currentIndex)
        {
            if (currentIndex == vector.Length)
            {
                PrintVector(vector);
                return;
            }

            for (int i = 1; i <= vector.Length; i++)
            {
                vector[currentIndex] = i;
                NestedLoop(vector, currentIndex + 1);
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));
        }
    }
}
