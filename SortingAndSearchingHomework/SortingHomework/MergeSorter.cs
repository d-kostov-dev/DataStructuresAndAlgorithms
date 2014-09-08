namespace SortingHomeworkApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sortResult = MergeSort(collection);

            collection.Clear();
            foreach (var item in sortResult)
            {
                collection.Add(item);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> leftSide = new List<T>();
            IList<T> rightSide = new List<T>();
            int middleIndex = collection.Count / 2;

            for (int i = 0; i < middleIndex; i++)
            {
                leftSide.Add(collection[i]);
            }

            for (int i = middleIndex; i < collection.Count; i++)
            {
                rightSide.Add(collection[i]);
            }

            leftSide = this.MergeSort(leftSide);
            rightSide = this.MergeSort(rightSide);

            var mergedCollection = Merge(leftSide, rightSide);
            return mergedCollection;
        }

        private IList<T> Merge(IList<T> leftSide, IList<T> rightSide)
        {
            IList<T> resultingList = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftSide.Count > leftIndex || rightSide.Count > rightIndex)
            {
                if (leftSide.Count > leftIndex && rightSide.Count > rightIndex)
                {
                    if (leftSide[leftIndex].CompareTo(rightSide[rightIndex]) <= 0)
                    {
                        resultingList.Add(leftSide[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        resultingList.Add(rightSide[rightIndex]);
                        rightIndex++;
                    }
                }
                else if(leftSide.Count > leftIndex)
                {
                    resultingList.Add(leftSide[leftIndex]);
                    leftIndex++;
                }
                else if (rightSide.Count > rightIndex)
                {
                    resultingList.Add(rightSide[rightIndex]);
                    rightIndex++;
                }
            }

            return resultingList;
        }
    }
}
