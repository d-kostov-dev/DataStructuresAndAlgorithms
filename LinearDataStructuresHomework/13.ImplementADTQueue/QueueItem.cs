namespace ImplementADTQueue
{
    public class QueueItem<T>
    {
        private T value;
        private QueueItem<T> nextItem;

        public QueueItem(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public QueueItem<T> NextItem 
        { 
            get
            {
                return this.nextItem;
            }

            set
            {
                // Recursively goes for all next next next items till the last one.
                if (this.nextItem != null)
                {
                    this.nextItem.NextItem = value;
                }
                else
                {
                    this.nextItem = value;
                }
            }
        }
    }
}
