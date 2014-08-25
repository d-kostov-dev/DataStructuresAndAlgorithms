namespace ImplementHashTable
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implement the data structure "hash table" in a class HashTable<K,T>. 
    /// Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16.
    /// When the hash table load runs over 75%, perform resizing to 2 times larger capacity. 
    /// Implement the following methods and properties: 
    /// - Add(key, value), 
    /// - Find(key)->value,
    /// - Remove(key), 
    /// - Count, 
    /// - Clear(), 
    /// - this[]
    /// - Keys
    /// // TO DO: Try to make the hash table to support iterating over its elements with foreach.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var hashTable = new HashTable<string, string>();

            // Add
            hashTable.Add("Pesho", "Peshkata");
            hashTable.Add("Gosho", "Gecata");
            hashTable.Add("Kencho", "I.K.");

            // Find
            Console.WriteLine(hashTable.Find("Pesho"));
            Console.WriteLine(hashTable.Find("Gosho"));
            Console.WriteLine(hashTable.Find("Kencho"));

            // Remove and Count
            Console.WriteLine("Elements in the table: {0}", hashTable.Count);
            Console.WriteLine("Removing element...");
            hashTable.Remove("Pesho");
            Console.WriteLine("Elements in the table: {0}", hashTable.Count);
            
            // Indexers
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(hashTable[i]);
            }

            // Keys
            Console.WriteLine(string.Join(", ", hashTable.GetAllKeys()));

            // Clear
            Console.WriteLine("Clearing the table...");
            hashTable.Clear();
            Console.WriteLine("Elements in the table: {0}", hashTable.Count);
        }
    }
}
