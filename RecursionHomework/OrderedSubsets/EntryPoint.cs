namespace OrderedSubsets
{
    using System;

    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
    /// Example: n=3, k=2, set = {hi, a, b} => (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    public class EntryPoint
    {
        private static int n;
        private static int k;
        private static string[] set;
        private static string[] resultingSet;

        public static void Main()
        {
            // GetInput();
            HardcodedInput();
           
            PrintSubset(0);
        }

        private static void PrintSubset(int currentIndex)
        {
            if (currentIndex == k)
            {
                PrintSet();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                resultingSet[currentIndex] = set[i];
                PrintSubset(currentIndex + 1);
            }
        }

        private static void GetInput()
        {
            Console.WriteLine("Set Length:");
            n = int.Parse(Console.ReadLine());
            set = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter set value:");
                set[i] = Console.ReadLine();
            }

            Console.WriteLine("K:");
            k = int.Parse(Console.ReadLine());

            resultingSet = new string[k];
        }

        private static void PrintSet()
        {
            Console.WriteLine(string.Join(", ", resultingSet));
        }

        private static void HardcodedInput()
        {
            n = 3;
            k = 2;
            set = new string[] { "Hi", "a", "b" };
            resultingSet = new string[k];
        }
    }
}
