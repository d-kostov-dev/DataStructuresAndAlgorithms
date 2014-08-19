namespace ReverseWithStack
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that reads N integers from the console and reverses them using a stack. 
    /// Use the Stack<int> class.
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.Write("Enter number of integers N: ");
            int numbersCount = int.Parse(Console.ReadLine());

            Stack<int> inputNumbers = new Stack<int>();

            // Get the numbers. Using white so we don't have problems with incorrect inputs.
            while (inputNumbers.Count < numbersCount)
            {
                string inputLine = Console.ReadLine();

                int currentNumber = 0;

                if (int.TryParse(inputLine, out currentNumber))
                {
                    inputNumbers.Push(currentNumber);
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer number.");
                }
            }

            // Just an empty line...for better "UI"
            Console.WriteLine();

            // Print the numbers. We are using stack so they will be reversed just by printing them.
            foreach (var item in inputNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
