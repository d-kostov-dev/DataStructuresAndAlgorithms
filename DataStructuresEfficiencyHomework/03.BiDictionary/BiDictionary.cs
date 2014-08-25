namespace BiDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BiDictionary<K, SK, V>
    {
        private Dictionary<K, List<V>> baseDictionary;
        private Dictionary<SK, K> subToPrimaryKeys;
        private Dictionary<K, SK> primaryToSubKeys;

        public BiDictionary()
        {
            this.baseDictionary = new Dictionary<K, List<V>>();
            this.subToPrimaryKeys = new Dictionary<SK, K>();
            this.primaryToSubKeys = new Dictionary<K, SK>();
        }

        public int Count { get; set; }

        public List<V> this[K key]
        {
            get
            {
                if (!this.baseDictionary.ContainsKey(key))
                {
                    throw new KeyNotFoundException();
                }

                return this.baseDictionary[key];
            }
        }

        public List<V> this[SK key]
        {
            get
            {
                if (!this.subToPrimaryKeys.ContainsKey(key))
                {
                    throw new KeyNotFoundException();
                }

                var primaryKey = this.subToPrimaryKeys[key];

                if (!this.baseDictionary.ContainsKey(primaryKey))
                {
                    throw new KeyNotFoundException();
                }

                return this.baseDictionary[primaryKey];
            }
        }

        public void Add(K key, V value)
        {
            if (!this.baseDictionary.ContainsKey(key))
            {
                this.baseDictionary.Add(key, new List<V>());
            }

            this.baseDictionary[key].Add(value);
            this.Count++;
        }

        public void Add(K key, SK subKey, V value)
        {
            this.Add(key, value);
            this.Associate(key, subKey);
        }

        public void Associate(K key, SK subKey)
        {
            this.primaryToSubKeys.Add(key, subKey);
            this.subToPrimaryKeys.Add(subKey, key);
        }

        public void Clear()
        {
            this.baseDictionary.Clear();
            this.subToPrimaryKeys.Clear();
            this.primaryToSubKeys.Clear();
        }

        public bool Contains(K key)
        {
            return this.baseDictionary.ContainsKey(key);
        }

        public bool Contains(SK key)
        {
            return this.subToPrimaryKeys.ContainsKey(key);
        }

        public void Remove(K key)
        {
            if (this.baseDictionary.ContainsKey(key))
            {
                this.baseDictionary.Remove(key);
            }

            if (this.primaryToSubKeys.ContainsKey(key))
            {
                var subKey = this.primaryToSubKeys[key];
                this.primaryToSubKeys.Remove(key);
                this.subToPrimaryKeys.Remove(subKey);
            }
        }

        public void Remove(SK key)
        {
            if (this.subToPrimaryKeys.ContainsKey(key))
            {
                var primaryKey = this.subToPrimaryKeys[key];
                this.subToPrimaryKeys.Remove(key);
                this.primaryToSubKeys.Remove(primaryKey);

                if (this.baseDictionary.ContainsKey(primaryKey))
                {
                    this.baseDictionary.Remove(primaryKey);
                }
            }
        }
    }
}
