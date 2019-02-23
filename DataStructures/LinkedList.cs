using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>, IEnumerable<T>
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void AddFirst(T item)
        {
            AddFirst(new Node<T> { Value = item });
        }

        public void AddFirst(Node<T> node)
        {
            var temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if(Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(Node<T> node)
        {
            if(Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;

            Count++;
        }

        public void RemoveLast()
        {
            if(Count != 0)
            {
                if(Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    var current = Head;

                    while(current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }

                Count--;
            }
        }

        public void RemoveFirst()
        {
            if(Count != 0)
            {
                Head = Head.Next;
                Count--;

                if(Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while(current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;

            while (current != null)
            {
                if(current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;

            while(current != null)
            {
                array[arrayIndex++] = current.Value;

                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T> prev = null;
            Node<T> current = Head;

            while(current != null)
            {
                if(current.Value.Equals(item))
                {
                    if(prev != null)
                    {
                        prev.Next = current.Next;

                        if(current.Next == null)
                        {
                            Tail = prev;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }

                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }
    }
}
