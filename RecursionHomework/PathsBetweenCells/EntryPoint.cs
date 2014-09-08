namespace PathsBetweenCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// We are given a matrix of passable and non-passable cells. 
    /// Write a recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    public class EntryPoint
    {
        private static Stack<Position> path;
        private static char[,] matrix;

        public static void Main()
        {
            path = new Stack<Position>();

            // 1 Path
            //matrix = new char[,]
            //{
            //    {'p','p','p','p','p'},
            //    {'p','x','x','x','p'},
            //    {'p','p','p','x','p'},
            //    {'p','p','p','x','p'},
            //    {'p','p','p','x','p'}
            //};

            // 2 Paths
            //matrix = new char[,]
            //{
            //    {'p','p','p','p','p'},
            //    {'p','x','x','x','p'},
            //    {'p','x','p','x','p'},
            //    {'p','x','x','x','p'},
            //    {'p','p','p','p','p'}
            //};

            // 4 Paths
            matrix = new char[,]
            {
                {'p','p','p','p','p'},
                {'p','x','x','x','p'},
                {'p','p','p','p','p'},
                {'p','x','x','x','p'},
                {'p','p','p','p','p'}
            };

            var startPos = new Position(0, 0);
            var endPos = new Position(4, 4);

            FindPathBeteenPositions(startPos, endPos);
        }

        private static void FindPathBeteenPositions(Position currentPos, Position endPos)
        {
            if (!IsInRange(currentPos))
            {
                return;
            }
            else if (currentPos.Equals(endPos))
            {
                var pathFound = path.ToArray();

                foreach (var item in pathFound.Reverse())
                {
                    Console.Write(item);
                }

                Console.Write(endPos);
                Console.WriteLine();

                return;
            }
            else if (matrix[currentPos.Row, currentPos.Col] == 'x' || matrix[currentPos.Row, currentPos.Col] == 'v')
            {
                return;
            }
            else
            {
                matrix[currentPos.Row, currentPos.Col] = 'v';
                path.Push(currentPos);

                var upPos = new Position(currentPos.Row - 1, currentPos.Col);
                FindPathBeteenPositions(upPos, endPos);

                var downPos = new Position(currentPos.Row + 1, currentPos.Col);
                FindPathBeteenPositions(downPos, endPos);

                var leftPos = new Position(currentPos.Row, currentPos.Col - 1);
                FindPathBeteenPositions(leftPos, endPos);

                var rightPos = new Position(currentPos.Row, currentPos.Col + 1);
                FindPathBeteenPositions(rightPos, endPos);

                path.Pop();
                matrix[currentPos.Row, currentPos.Col] = 'p';
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
