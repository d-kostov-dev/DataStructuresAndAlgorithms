namespace ShortestSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// * We are given numbers N and M and the following operations:
    /// N = N+1
    /// N = N+2
    /// N = N*2
    /// Write a program that finds the shortest sequence of operations from the list above that starts from N 
    /// and finishes in M. 
    /// Hint: use a queue.
    /// Example: N = 5, M = 16
    /// Sequence: 5 -> 7 -> 8 -> 16
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Enter Starting Number");
            int startingNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Target Number");
            int targetNumber = int.Parse(Console.ReadLine());

            int operationsCount = FindShortestSequence(startingNumber, targetNumber);

            Console.WriteLine("Operations needed to reach {0} from {1} = {2}", targetNumber, startingNumber, operationsCount);
        }

        /// <summary>
        /// Calculates how many operations are needed to reach the target number.
        /// </summary>
        /// <param name="startingNumber">Starting number.</param>
        /// <param name="targetNumber">Target number</param>
        /// <returns>The number of operations needed to reach the target number.</returns>
        public static int FindShortestSequence(int startingNumber, int targetNumber)
        {
            Queue<int> sequence = new Queue<int>();
            int operationsCounter = 0;

            sequence.Enqueue(startingNumber);

            while (true)
            {
                if (sequence.Contains(targetNumber))
                {
                    break;
                }

                for (int i = 0, len = sequence.Count; i < len; i++)
                {
                    int currentMember = sequence.Dequeue();

                    sequence.Enqueue(currentMember + 1);
                    sequence.Enqueue(currentMember + 2);
                    sequence.Enqueue(currentMember * 2);
                }

                operationsCounter++;
            }

            return operationsCounter;
        }
    }
}
