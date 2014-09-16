namespace FriendsOfPesho
{
    using System;

    public class PriorityQ<T> where T : IComparable<T>
    {
        private readonly BinaryHeap<T> queueHeap;

        public PriorityQ()
        {
            this.queueHeap = new BinaryHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.queueHeap.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.queueHeap.Add(element);
        }

        public T Peek()
        {
            return this.queueHeap.Peek();
        }

        public T Dequeue()
        {
            var element = this.queueHeap.Remove();
            return element;
        }
    }
}
