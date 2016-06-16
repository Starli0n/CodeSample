using System.Collections.Generic;

namespace LinkedListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new  List<int>();
            System.Collections.Generic.LinkedList<int> myLinkedList = new System.Collections.Generic.LinkedList<int>();

            LinkedListDll.LinkedListNode<int> myNode = new LinkedListDll.LinkedListNode<int>(42);
            // myNode.Next = null; // Compile error as far if the setter is internal
        }
    }
}
