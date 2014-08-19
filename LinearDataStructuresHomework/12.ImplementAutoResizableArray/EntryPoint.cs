namespace ImplementAutoResizableStack
{
    using System;

    /// <summary>
    /// Implement the ADT stack as auto-resizable array. 
    /// Resize the capacity on demand (when no space is available to add / insert a new element).
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var stackArray = new StackArray<int>();

            stackArray.Push(5);
            stackArray.Push(6);
            stackArray.Push(7);

            Console.WriteLine(stackArray.Peek());

            while (stackArray.Count > 0)
            {
                Console.WriteLine(stackArray.Pop());
            }
        }
    }
}
