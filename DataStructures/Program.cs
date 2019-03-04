using DataStructures.Sorting;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { -1, 25, -58964, 8547, -119, 0, 78596 };
            var sorted = Merge.Sort(data);

            foreach (int x in sorted)
                Console.Write(x + " ");

            Console.ReadLine();

            int[] data1 = new int[] { -1, 25, -58964, 8547, -119, 0, 78596 };
            Quick.Sort(data1, 0, data1.Length - 1);

            foreach (int x in data1)
                Console.Write(x + " ");

            Console.ReadLine();
        }
    }
}
