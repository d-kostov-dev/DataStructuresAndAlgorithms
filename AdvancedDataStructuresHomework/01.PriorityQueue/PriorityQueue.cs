namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
    {
        private T[] itemsData;
        private int heapSize;
        private Comparison<T> comparisonType;

        public PriorityQueue()
            : this(4, null)
        {
        }

        public PriorityQueue(Comparison<T> comparison)
            : this(4, comparison)
        {
        }

        public PriorityQueue(int capacity)
            : this(capacity, null)
        {
        }

        public PriorityQueue(int capacity, Comparison<T> comparison)
        {
            this.itemsData = new T[capacity];
            this.comparisonType = comparison;

            if (comparison == null)
            {
                this.comparisonType = new Comparison<T>(Comparer<T>.Default.Compare);
            }
        }

        public int Count
        {
            get
            {
                return this.heapSize;
            }

            set
            {
                this.heapSize = value;
            }
        }

        public void Enqueue(T item)
        {
            if (this.Count == this.itemsData.Length)
            {
                this.ResizeHeap();
            }

            this.itemsData[this.Count] = item;
            this.HeapUp(this.Count);
            this.Count++;
        }

        public T Peak()
        {
            return this.itemsData[0];
        }

        public T Dequeue()
        {
            T item = this.itemsData[0];
            this.Count--;

            this.itemsData[0] = this.itemsData[this.Count];
            this.HeapDown(0);

            return item;
        }

        private void ResizeHeap()
        {
            T[] resizedData = new T[this.itemsData.Length * 2];
            Array.Copy(this.itemsData, 0, resizedData, 0, this.itemsData.Length);
            this.itemsData = resizedData;
        }

        private void HeapUp(int childIndex)
        {
            if (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (this.CompareItems(childIndex, parentIndex))
                {
                    this.SwapItems(parentIndex, childIndex);
                    this.HeapUp(parentIndex);
                }
            }
        }

        private void HeapDown(int parentIndex)
        {
            int leftChildIndex = (2 * parentIndex) + 1;
            int rightChildIndex = leftChildIndex + 1;
            int largestChildIndex = parentIndex;

            if (leftChildIndex < this.Count && this.CompareItems(leftChildIndex, largestChildIndex))
            {
                largestChildIndex = leftChildIndex;
            }

            if (rightChildIndex < this.Count && this.CompareItems(rightChildIndex, largestChildIndex))
            {
                largestChildIndex = rightChildIndex;
            }

            if (largestChildIndex != parentIndex)
            {
                this.SwapItems(parentIndex, largestChildIndex);
                this.HeapDown(largestChildIndex);
            }
        }

        private void SwapItems(int parentIndex, int childIndex)
        {
            T tempItem = this.itemsData[parentIndex];
            this.itemsData[parentIndex] = this.itemsData[childIndex];
            this.itemsData[childIndex] = tempItem;
        }

        private bool CompareItems(int indexA, int indexB)
        {
            if (this.comparisonType.Invoke(this.itemsData[indexA], this.itemsData[indexB]) > 0)
            {
                return true;
            }

            return false;
        }
    }
}