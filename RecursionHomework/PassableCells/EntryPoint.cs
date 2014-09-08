namespace PassableCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// * We are given a matrix of passable and non-passable cells. 
    /// Write a recursive program for finding all areas of passable cells in the matrix.
    /// </summary>
    public class EntryPoint
    {
        private static Stack<Position> path;
        private static char[,] matrix;

        public static void Main()
        {
            path = new Stack<Position>();

            matrix = new char[,]
            {
                {'p','x'},
                {'p','p'},
            };

            PrintPathsCount();
        }
        private static void PrintPathsCount()
        {
            var paths = 0;
            //Finding the first possible start position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'p')
                    {
                        var startPos = new Position(row, col);
                        paths += FindPossibleAreas(startPos, 0);
                    }
                }
            }

            Console.WriteLine(paths);
        }

        private static int FindPossibleAreas(Position currentPos, int count)
        {
            if (!IsInRange(currentPos))
            {
                return count;
            }
            else if (matrix[currentPos.Row, currentPos.Col] == 'x' || matrix[currentPos.Row, currentPos.Col] == 'v')
            {
                return count;
            }
            else
            {
                count++;
                matrix[currentPos.Row, currentPos.Col] = 'v';

                // Im not going diagonaly.
                var upPos = new Position(currentPos.Row - 1, currentPos.Col);
                count += FindPossibleAreas(upPos, 0);

                var downPos = new Position(currentPos.Row + 1, currentPos.Col);
                count += FindPossibleAreas(downPos, 0);

                var leftPos = new Position(currentPos.Row, currentPos.Col - 1);
                count += FindPossibleAreas(leftPos, 0);

                var rightPos = new Position(currentPos.Row, currentPos.Col + 1);
                count += FindPossibleAreas(rightPos, 0);

                matrix[currentPos.Row, currentPos.Col] = 'p';

                return count;
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
