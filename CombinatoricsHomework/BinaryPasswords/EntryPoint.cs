namespace BinaryPasswords
{
    using System;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/132#9
    /// TASK 1
    /// 100 / 100
    /// </summary>
    public class EntryPoint
    {
        private static string passwordTemplate;

        public static void Main()
        {
            passwordTemplate = Console.ReadLine();
            int starsCount = CountStars();

            long result = Pow(2, starsCount);

            Console.WriteLine(result);
        }

        private static long Pow(int p, int starsCount)
        {
            long result = 1;

            for (int i = 0; i < starsCount; i++)
            {
                result *= p;
            }

            return result;
        }

        private static int CountStars()
        {
            var counter = 0;

            for (int i = 0; i < passwordTemplate.Length; i++)
            {
                if (passwordTemplate[i] == '*')
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
