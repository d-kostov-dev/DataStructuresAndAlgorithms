namespace SubsetsOfStrings
{
    using System;

    /// <summary>
    /// Write a program for generating and printing all subsets of k strings from given set of strings.
    /// Example: s = {test, rock, fun}, k=2 (test rock),  (test fun),  (rock fun)
    /// </summary>
    public class EntryPoint
    {
        private static string[] stringsSet;
        private static int resultLength; // k
        private static string[] resultingSet;

        public static void Main()
        {
            stringsSet = new string[] { "test", "rock", "fun" };
            resultLength = 2;
            resultingSet = new string[resultLength];
            PrintStringSets(0, 0);
        }

        private static void PrintStringSets(int currentIndex, int loopStart)
        {
            if (currentIndex == resultLength)
            {
                PrintSet();
                return;
            }

            for (int i = loopStart; i < stringsSet.Length; i++)
            {
                resultingSet[currentIndex] = stringsSet[i];
                PrintStringSets(currentIndex + 1, i + 1);
            }
        }

        private static void PrintSet()
        {
            Console.WriteLine(string.Join(", ", resultingSet));
        }
    }
}
