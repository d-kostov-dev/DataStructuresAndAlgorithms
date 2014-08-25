namespace PriorityQueue
{
    using System;

    /// <summary>
    /// Implement a class PriorityQueue<T> based on the data structure "binary heap".
    /// </summary>
    public class EntryPoint
    {
        private static readonly Random GetRandomNumber = new Random();

        public static void Main()
        {
            var queue = new PriorityQueue<int>();

            for (int i = 0; i < 100; i++)
            {
                int randomNum = GetRandomNumber.Next(100);
                Console.WriteLine("Inserting: {0}", randomNum);
                queue.Enqueue(randomNum);
            }

            Console.WriteLine("Dequeue all values...");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
