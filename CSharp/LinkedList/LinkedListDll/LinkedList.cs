using System;
using System.Collections.Generic;

namespace LinkedListDll
{
    public class LinkedList<T>
    {
        public int Count { get; private set; }

        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();

                LinkedListNode<T> cursor = First;
                for (int i = 0; i < index; ++i)
                    cursor = cursor.Next;
                return cursor;
            }
        }

        public LinkedList()
        {
            Clear();
        }

        public LinkedList(T firstValue)
        {
            Clear();
            Add(firstValue);
        }

        public LinkedList(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            // beforeNew <-> newLink <-> afterNew
            LinkedListNode<T> beforeNew;
            LinkedListNode<T> newLink = new LinkedListNode<T>(item);
            LinkedListNode<T> afterNew;


            // Retrieve beforeNew and afterNew
            if (index == Count) // Insert at the end
            {
                afterNew = null; // Nothing after the item
                beforeNew = Last; // Could be null for count == 0
                Last = newLink;
            }
            else // Insert at the beginning or in the middle
            {
                afterNew = this[index]; // never null by design
                beforeNew = afterNew.Previous; // Could be null for index == 0
                afterNew.Previous = newLink;
            }

            if (beforeNew == null) // or index == 0, Insert at the beginning
                First = newLink;
            else // Insert in the middle or at the end
                beforeNew.Next = newLink;

            // At this point beforeNew and afterNew could be null
            newLink.Previous = beforeNew;
            newLink.Next = afterNew;

            ++Count;
        }

        public void RemoveAt(int index)
        {
            // beforeOld <-> oldLink <-> afterOld
            LinkedListNode<T> oldLink = this[index];
            LinkedListNode<T> beforeOld;
            LinkedListNode<T> afterOld;

            beforeOld = oldLink.Previous;
            afterOld = oldLink.Next;

            if (beforeOld == null)
                First = afterOld; // Removing the first item
            else
                beforeOld.Next = afterOld;

            if (afterOld == null)
                Last = beforeOld; // Removing the last item
            else
                afterOld.Previous = beforeOld;

            --Count;
        }

        public void RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
            return false;
        }

        public LinkedListNode<T> Find(T value)
        {
            throw new NotImplementedException();
            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}
