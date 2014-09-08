namespace PermutationsOfMultiset
{
    using System;
    using System.Linq;

    /// <summary>
    /// * Write a program to generate all permutations with repetitions of given multi-set.
    /// </summary>
    public class EntryPoint
    {
        private static int[] multiSet;

        public static void Main()
        {
            multiSet = new int[] { 1, 3, 5, 5 };
            Array.Sort(multiSet);

            PrintPermutations(0);
        }

        private static void PrintPermutations(int permutationIndex)
        {
            PrintVector(multiSet);

            var setLength = multiSet.Length;

            if (permutationIndex < setLength)
            {
                for (int i = setLength - 2; i >= permutationIndex; i--)
                {
                    for (int j = i + 1; j < setLength; j++)
                    {
                        if (multiSet[i] != multiSet[j])
                        {
                            SwapValues(multiSet, i, j);
                            PrintPermutations(i + 1);
                        }
                    }

                    int previousValue = multiSet[i];

                    for (int k = i; k < setLength - 1;)
                    {
                        multiSet[k] = multiSet[++k];
                    }

                    multiSet[setLength - 1] = previousValue;
                }
            }
        }

        private static void SwapValues(int[] data, int indexA, int indexB)
        {
            var previousValue = data[indexA];
            data[indexA] = data[indexB];
            data[indexB] = previousValue;
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));
        }
    }
}
