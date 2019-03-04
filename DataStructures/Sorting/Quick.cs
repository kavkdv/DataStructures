using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Sorting
{
    public static class Quick
    {
        public static void Sort(int[] inputArray, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = Partition(inputArray, start, end);

            Sort(inputArray, start, pivot - 1);
            Sort(inputArray, pivot + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

    }
}
