namespace ImplementSet
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements.
    /// Implement all standard set operations like 
    /// - Add(T), 
    /// - Find(T), 
    /// - Remove(T), 
    /// - Count, 
    /// - Clear(), 
    /// // TO DO: union and intersect.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var myHashSet = new HashSet<string>();

            // Add
            myHashSet.Add("Pesho");
            myHashSet.Add("Gosho");
            myHashSet.Add("Ivan");

            // Find
            Console.WriteLine(myHashSet.Find("Pesho"));
            Console.WriteLine(myHashSet.Find("Gosho"));
            Console.WriteLine(myHashSet.Find("Ivan"));

            // Remove and Count
            Console.WriteLine("Elements in the table: {0}", myHashSet.Count);
            Console.WriteLine("Removing element...");
            myHashSet.Remove("Pesho");
            Console.WriteLine("Elements in the table: {0}", myHashSet.Count);

            // Clear
            Console.WriteLine("Clearing the table...");
            myHashSet.Clear();
            Console.WriteLine("Elements in the table: {0}", myHashSet.Count);
        }
    }
}
