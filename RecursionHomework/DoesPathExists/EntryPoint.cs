namespace DoesPathExists
{
    using System;

    /// <summary>
    /// Modify the above program to check whether a path exists between two cells without finding all possible paths. 
    /// Test it over an empty 100 x 100 matrix.
    /// </summary>
    public class EntryPoint
    {
        private static char[,] matrix;

        public static void Main()
        {
            // True
            //matrix = new char[,]
            //{
            //    {'p','p','p','p','p'},
            //    {'p','x','x','x','p'},
            //    {'p','p','p','x','p'},
            //    {'p','p','p','x','p'},
            //    {'p','p','p','x','p'}
            //};

            // True
            //matrix = new char[,]
            //{
            //    {'p','p','p','p','p'},
            //    {'p','x','x','x','p'},
            //    {'p','x','p','x','p'},
            //    {'p','x','x','x','p'},
            //    {'p','p','p','p','p'}
            //};

            // False
            matrix = new char[,]
            {
                {'p','p','p','p','p'},
                {'p','x','x','x','p'},
                {'p','p','p','p','p'},
                {'p','x','x','x','x'},
                {'p','p','p','x','p'}
            };

            var startPos = new Position(0, 0);
            var endPos = new Position(4, 4);

            Console.WriteLine(FindPathBeteenPositions(startPos, endPos));
        }

        private static bool FindPathBeteenPositions(Position currentPos, Position endPos)
        {
            if (!IsInRange(currentPos))
            {
                return false;
            }
            else if (currentPos.Equals(endPos))
            {
                return true;
            }
            else if (matrix[currentPos.Row, currentPos.Col] == 'x' || matrix[currentPos.Row, currentPos.Col] == 'v')
            {
                return false;
            }
            else
            {
                bool isPathFound = false;
                matrix[currentPos.Row, currentPos.Col] = 'v';

                var upPos = new Position(currentPos.Row - 1, currentPos.Col);
                isPathFound = FindPathBeteenPositions(upPos, endPos);

                if (isPathFound)
                {
                    return true;
                }

                var downPos = new Position(currentPos.Row + 1, currentPos.Col);
                isPathFound = FindPathBeteenPositions(downPos, endPos);

                if (isPathFound)
                {
                    return true;
                }

                var leftPos = new Position(currentPos.Row, currentPos.Col - 1);
                isPathFound = FindPathBeteenPositions(leftPos, endPos);

                if (isPathFound)
                {
                    return true;
                }

                var rightPos = new Position(currentPos.Row, currentPos.Col + 1);
                isPathFound = FindPathBeteenPositions(rightPos, endPos);

                if (isPathFound)
                {
                    return true;
                }

                matrix[currentPos.Row, currentPos.Col] = 'p';
            }

            return false;
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
