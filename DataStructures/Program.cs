using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(7);

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            list.Remove(5);

            Console.ReadLine();
        }
    }
}
