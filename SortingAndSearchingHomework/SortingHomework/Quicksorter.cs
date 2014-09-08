namespace SortingHomeworkApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// A Quicksort algorithm implementation works in place, 
        /// by swapping elements within the array, 
        /// to avoid the memory allocation of more arrays.
        /// </summary>
        /// <param name="collection"></param>
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentOutOfRangeException("Can't sort null collection");
            }

            QuickSort(collection, 0, collection.Count - 1);
        }

        /// <summary>
        /// Optimised for low memory usage. No new collections!
        /// http://rosettacode.org/wiki/Sorting_algorithms/Quicksort
        /// </summary>
        private void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            int left = startIndex;
            int right = endIndex;

            var pivot = collection[(startIndex + endIndex) / 2];

            while (left <= right)
            {
                while (collection[left].CompareTo(pivot) < 0)
                {
                    left++;
                }

                while (collection[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    SwapPositions(collection, left, right);
                    left++;
                    right--;
                }
            }

            if (startIndex < right)
            {
                QuickSort(collection, startIndex, right);
            }

            if (left < endIndex)
            {
                QuickSort(collection, left, endIndex);
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
