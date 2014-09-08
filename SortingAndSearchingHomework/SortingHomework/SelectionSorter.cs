namespace SortingHomeworkApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int minValue;

            for (int i = 0; i < collection.Count; i++)
            {
                minValue = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minValue]) == -1)
                    {
                        minValue = j;
                    }
                }

                if (minValue != i)
                {
                    SwapPositions(collection, i, minValue);
                }
            }
        }

        private static void SwapPositions(IList<T> collection, int firstIndex, int secondIndex)
        {
            var oldValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldValue;
        }
    }
}
