namespace ImplementHashTable
{
    using System;
    using System.Collections.Generic;

    public class HashTable<K, V>
    {
        private LinkedList<KeyValueStruct<K, V>>[] itemsList;
        private int currentUsedSize;

        public HashTable()
        {
            this.itemsList = new LinkedList<KeyValueStruct<K, V>>[16];
            this.currentUsedSize = 0;
        }

        public int Count { get; set; }

        public LinkedList<KeyValueStruct<K, V>> this[int index]
        {
            get
            {
                return this.itemsList[index];
            }
        }

        public void Add(K inputKey, V inputValue)
        {
            int position = this.GetPosition(inputKey);
            var linkedList = this.GetList(position);

            var item = new KeyValueStruct<K, V>() { Key = inputKey, Value = inputValue };

            linkedList.AddLast(item);
            this.Count++;
        }

        public V Find(K key)
        {
            int position = this.GetPosition(key);
            var linkedList = this.GetList(position);

            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }

        public void Remove(K key)
        {
            int position = this.GetPosition(key);
            var linkedList = this.GetList(position);

            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    linkedList.Remove(item);
                    this.Count--;
                    break;
                }
            }
        }

        public void Clear()
        {
            foreach (var item in this.itemsList)
            {
                if (item != null)
                {
                    item.Clear();
                }
            }

            this.Count = 0;
        }

        public IList<K> GetAllKeys()
        {
            var keys = new List<K>();

            foreach (var item in this.itemsList)
            {
                if (item != null)
                {
                    foreach (var subItem in item)
                    {
                        keys.Add(subItem.Key);
                    }
                }
            }

            return keys;
        }

        private LinkedList<KeyValueStruct<K, V>> GetList(int position)
        {
            var linkedList = this.itemsList[position];

            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValueStruct<K, V>>();
                this.itemsList[position] = linkedList;
                this.currentUsedSize++;
                this.ResizeItemsList();
            }

            return linkedList;
        }

        private void ResizeItemsList()
        {
            int percentFromTotal = (this.itemsList.Length / 4) * 3;

            if (this.currentUsedSize >= percentFromTotal)
            {
                var newList = new LinkedList<KeyValueStruct<K, V>>[this.itemsList.Length * 2];

                for (int i = 0; i < this.itemsList.Length; i++)
                {
                    newList[i] = this.itemsList[i];
                }

                this.itemsList = newList;
            }
        }

        private int GetPosition(K key)
        {
            int position = key.GetHashCode() % this.itemsList.Length;
            return Math.Abs(position);
        }
    }
}
