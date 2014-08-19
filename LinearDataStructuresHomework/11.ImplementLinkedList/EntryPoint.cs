namespace ImplementLinkedList
{
    using System;

    /// <summary>
    /// Implement the data structure linked list. 
    /// Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
    /// Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var firstItem = new ListItem<int>(5);
            var linkedList = new LinkedList<int>(firstItem);

            Console.WriteLine(linkedList.FirstElement.Value);

            firstItem.NextItem = new ListItem<int>(10);

            Console.WriteLine(linkedList.FirstElement.NextItem.Value);
        }
    }
}
