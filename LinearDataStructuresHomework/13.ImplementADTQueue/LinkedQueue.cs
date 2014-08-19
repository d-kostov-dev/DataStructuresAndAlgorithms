namespace ImplementADTQueue
{
    public class LinkedQueue<T>
    {
        private QueueItem<T> firstItem;
        private int count;

        public LinkedQueue(T item)
        {
            this.FirstItem = new QueueItem<T>(item);
            this.Count = 1;
        }

        public int Count { get; set; }

        public QueueItem<T> FirstItem { get; set; }

        public void Enqueue(T item)
        {
            this.FirstItem.NextItem = new QueueItem<T>(item);
            this.Count++;
        }

        public T Dequeue()
        {
            var itemToReturn = this.FirstItem.Value;
            this.FirstItem = this.FirstItem.NextItem;
            this.Count--;

            return itemToReturn;
        }

        public T Peek()
        {
            return this.FirstItem.Value;
        }
    }
}
