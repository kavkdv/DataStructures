using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        public int Count { get; private set; }

        public DoublyNode<T> Head { get; private set; }

        public DoublyNode<T> Tail { get; private set; }

        public bool IsReadOnly => false;

        public void AddFirst(T item)
        {
            AddFirst(new DoublyNode<T> { Value = item });
        }

        public void AddFirst(DoublyNode<T> node)
        {
            var temp = Head;

            Head = node;

            Head.Next = temp;

            Count++;

            if (Count == 1)
            {
                Tail = Head;
            }
            else
            {
                temp.Prev = Head;
            }
        }

        public void AddLast(T item)
        {
            AddLast(new DoublyNode<T> { Value = item });
        }

        public void AddLast(DoublyNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;

                node.Prev = Tail;
            }

            Tail = node;

            Count++;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.Prev.Next = null;
                    Tail = Tail.Prev;
                }

                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    Head.Prev = null;
                }
            }
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
                if (current.Value.Equals(item))
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

            while (current != null)
            {
                array[arrayIndex++] = current.Value;

                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            DoublyNode<T> prev = null;
            DoublyNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (prev != null)
                    {
                        prev.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = prev;
                        }
                        else
                        {
                            current.Next.Prev = prev;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }
    }
}
