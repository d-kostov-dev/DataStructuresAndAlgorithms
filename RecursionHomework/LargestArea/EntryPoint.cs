namespace LargestArea
{
    using System;

    /// <summary>
    /// Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.
    /// </summary>
    public class EntryPoint
    {
        private static int[,] matrix;

        public static void Main()
        {
            matrix = new int[,]
            {
                {1,1,1,1,1,},
                {1,0,0,1,1,},
                {1,1,1,1,0,},
                {1,1,0,1,0,},
                {1,1,0,0,0,},
                {1,1,1,1,1,},
                {1,1,0,0,0,},
            };

            int longestAdjacentCells = FindLongestAdjacent();
            Console.WriteLine(longestAdjacentCells);
        }

        private static int FindLongestAdjacent()
        {
            int longest = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        var startPosition = new Position(row, col);
                        int adjecentsCount = FindAdjacentsFromPosition(startPosition, 0);

                        if (adjecentsCount > longest)
                        {
                            longest = adjecentsCount;
                        }
                    }
                }
            }

            return longest;
        }

        private static int FindAdjacentsFromPosition(Position currentPos, int counter)
        {
            if (!IsInRange(currentPos))
            {
                return counter;
            }
            else if (matrix[currentPos.Row, currentPos.Col] != 0)
            {
                return counter;
            }
            else
            {
                // We are in range and on a zero. Increase counter and go count in all other directions.
                counter++;
                matrix[currentPos.Row, currentPos.Col] = 1;

                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        var nextPosition = new Position(currentPos.Row + row, currentPos.Col + col);
                        counter += FindAdjacentsFromPosition(nextPosition, 0);
                    }
                }

                return counter;
            }
        }

        private static bool IsInRange(Position position)
        {
            if (position.Row < 0 || position.Row >= matrix.GetLength(0))
            {
                return false;
            }

            if (position.Col < 0 || position.Col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
