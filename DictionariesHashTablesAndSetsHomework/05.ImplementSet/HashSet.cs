namespace ImplementSet
{
    using ImplementHashTable;

    public class HashSet<T>
    {
        private HashTable<int, T> hashTable;

        public HashSet()
        {
            this.hashTable = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Add(T item)
        {
            int itemKey = item.GetHashCode();
            this.hashTable.Add(itemKey, item);
        }

        public T Find(T item)
        {
            int itemKey = item.GetHashCode();
            var foundItem = this.hashTable.Find(itemKey);

            return foundItem;
        }

        public void Remove(T item)
        {
            int itemKey = item.GetHashCode();
            this.hashTable.Remove(itemKey);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }
    }
}
