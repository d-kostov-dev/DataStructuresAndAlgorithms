namespace QueueSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// We are given the following sequence:
    /// S1 = N;
    /// 
    /// S2 = S1 + 1;
    /// S3 = 2*S1 + 1;
    /// S4 = S1 + 2;
    /// 
    /// S5 = S2 + 1;
    /// S6 = 2*S2 + 1;
    /// S7 = S2 + 2;
    /// 
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    /// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            QueueSequence(2, 50);
        }

        /// <summary>
        /// Prints a sequence by given starting number and length.
        /// </summary>
        /// <param name="startingNumber">Starting number of the sequence.</param>
        /// <param name="queueLength">Length of the sequence to be printed</param>
        public static void QueueSequence(int startingNumber, int queueLength)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(startingNumber);

            for (int i = 1; i <= queueLength; i++)
            {
                int currentMember = sequence.Dequeue();

                Console.WriteLine("Member {1}: {0}", currentMember, i);

                sequence.Enqueue(currentMember + 1);
                sequence.Enqueue((2 * currentMember) + 1);
                sequence.Enqueue(currentMember + 2);
            }
        }
    }
}
