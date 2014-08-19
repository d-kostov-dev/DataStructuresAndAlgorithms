namespace ImplementLinkedList
{
    /// <summary>
    /// Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
    public class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public LinkedList(ListItem<T> firstElement)
        {
            this.FirstElement = firstElement;
        }

        public ListItem<T> FirstElement { get; set; }
    }
}
