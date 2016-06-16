namespace LinkedListDll
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }

        public LinkedListNode<T> Previous { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T value, LinkedListNode<T> previous = null, LinkedListNode<T> next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
}
