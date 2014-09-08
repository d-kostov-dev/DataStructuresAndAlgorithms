namespace SortingHomeworkApplication
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private static readonly Random randomNumberGenerator = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var value in this.Items)
            {
                if (value.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new SelectionSorter<T>());

            if (this.BinarySearchRecursive(item, 0, this.Items.Count - 1) >= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the index of the searched item.
        /// </summary>
        private int BinarySearchRecursive(T item, int minIndex, int maxIndex)
        {
            if (maxIndex < minIndex)
            {
                return -1;
            }

            int middleIndex = minIndex + ((maxIndex - minIndex) / 2);

            if (this.Items[middleIndex].CompareTo(item) > 0)
            {
                return BinarySearchRecursive(item, minIndex, middleIndex - 1);
            }
            else if (this.Items[middleIndex].CompareTo(item) < 0)
            {
                return BinarySearchRecursive(item, middleIndex + 1, maxIndex);
            }
            else
            {
                return middleIndex;
            }
        }

        public void Shuffle()
        {
            for (int i = this.Items.Count - 1; i >= 1; i--)
            {
                var randomIndex = randomNumberGenerator.Next(0, i + 1);
                SwapPositions(this.Items, i, randomIndex);
            }
        }

        private static void SwapPositions(IList<T> collection, int firstIndex, int secondIndex)
        {
            var oldValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldValue;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
