namespace MinimumEditDistance
{
    using System;

    /// <summary>
    /// Write a program to calculate the "Minimum Edit Distance" (MED) between two words. 
    /// MED(x, y) is the minimal sum of costs of edit operations used to transform x to y. 
    /// Sample costs are given below:
    ///  - cost (replace a letter) = 1
    ///  - cost (delete a letter) = 0.9
    ///  - cost (insert a letter) = 0.8
    /// 
    /// Example: x = "developer", y = "enveloped" - cost = 2.7 
    /// delete ‘d’: "developer" - "eveloper", cost = 0.9
    /// insert ‘n’: "eveloper" - "enveloper", cost = 0.8
    /// replace ‘r’ - ‘d’: "enveloper" - "enveloped", cost = 1
    /// </summary>
    public class EntryPoint
    {
        private const double DeleteCost = 0.9;
        private const double InsertCost = 0.8;
        private const double ReplaceCost = 1;

        public static void Main()
        {
            char[] wordX = "developer".ToCharArray();
            char[] wordY = "enveloped".ToCharArray();
            double result = EditDistanceDP(wordX, wordY);
            Console.WriteLine(result);
        }

        private static double EditDistanceDP(char[] wordX, char[] wordY)
        {
            double leftCell = 0;
            double topCell = 0;
            double cornerCell = 0;

            int rows = wordX.Length + 1;
            int cols = wordY.Length + 1;

            double[,] solutionTable = new double[rows, cols];

            // Initial values
            for (int row = 0; row < rows; row++)
            {
                solutionTable[row, 0] = row * DeleteCost;
            }

            for (int col = 0; col < cols; col++)
            {
                solutionTable[0, col] = col * DeleteCost;
            }

            // Calculation
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    leftCell = solutionTable[i - 1, j];
                    leftCell += DeleteCost;

                    topCell = solutionTable[i, j - 1];
                    topCell += InsertCost;

                    cornerCell = solutionTable[i - 1, j - 1];

                    if (wordX[i - 1] != wordY[j - 1])
                    {
                        cornerCell += ReplaceCost;
                    }

                    solutionTable[i, j] = MinimumBetweenThree(leftCell, topCell, cornerCell);
                    //// PrintMatrix(solutionTable);
                }
            }

            return solutionTable[rows - 1, cols - 1];
        }

        private static double MinimumBetweenThree(double a, double b, double c)
        {
            return Math.Min(Math.Min(a, b), c);
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("[{0}]", matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
