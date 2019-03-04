using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Sorting
{
    public static class Merge
    {
        public static int[] Sort(int[] inputArray)
        {
            if (inputArray.Length <= 1)
            {
                return inputArray;
            }

            int middle = inputArray.Length / 2;

            var arrayLeft = Sort(inputArray.Take(middle).ToArray());
            var arrayRight = Sort(inputArray.Skip(middle).ToArray());

            return MergeRecursive(arrayLeft, arrayRight);
        }

        private static int[] MergeRecursive(int[] arrayLeft, int[] arrayRight)
        {
            int ptrLeft = 0, ptrRight = 0;
            int[] merged = new int[arrayLeft.Length + arrayRight.Length];

            for (int i = 0; i < merged.Length; i++)
            {
                if (ptrLeft < arrayLeft.Length && ptrRight < arrayRight.Length)
                {
                    merged[i] = arrayLeft[ptrLeft] > arrayRight[ptrRight] ? arrayRight[ptrRight++] : arrayLeft[ptrLeft++];
                }
                else
                {
                    merged[i] = ptrRight < arrayRight.Length ? arrayRight[ptrRight++] : arrayLeft[ptrLeft++];
                }
            }

            return merged;
        }
    }
}
