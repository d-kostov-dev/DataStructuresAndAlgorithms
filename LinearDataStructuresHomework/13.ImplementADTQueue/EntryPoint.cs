namespace ImplementADTQueue
{
    using System;

    /// <summary>
    /// Implement the ADT queue as dynamic linked list. 
    /// Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var linkedQueue = new LinkedQueue<string>("Pesho");
            linkedQueue.Enqueue("Gosho");
            linkedQueue.Enqueue("Misho");

            Console.WriteLine(linkedQueue.Peek());

            while (linkedQueue.Count > 0)
            {
                Console.WriteLine(linkedQueue.Dequeue());
            }
        }
    }
}
