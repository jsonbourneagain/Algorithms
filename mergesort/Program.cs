using System;
using System.Linq;

namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsorted = new int[]{12,4,25,3,97,6};
            var sorted = MergeSort(unsorted);

            foreach(var item in sorted)
                System.Console.WriteLine(item);
        }

        static int[] MergeSort(int[] A)
        {
            // Input: Array A of n distinct integers.
            // Output: Array with the same integers, sorted from smallest to largest.

            if (A.Length == 0 || A.Length == 1)
                return A;

            int n = A.Length / 2;

            var C = MergeSort(A.Take(n).ToArray());
            var D = MergeSort(A.Skip(n).ToArray());

            return Merge(C, D);

            int[] Merge(int[] C, int[] D)
            {
                int i = default;
                int j = default;
                int size = C.Length + D.Length;

                int[] sorted = new int[size];

                for (int k = 0; k < size; k++)
                {
                    if (i < C.Length && j < D.Length)
                    {
                        if (C[i] < D[j])
                        {
                            sorted[k] = C[i];
                            i++;
                        }
                        else
                        {
                            sorted[k] = D[j];
                            j++;
                        }
                    }
                    else if (i == C.Length && j < D.Length)
                    {
                        sorted[k] = D[j];
                        j++;
                    }
                    else if(i < C.Length && j == D.Length){
                        sorted[k] = C[i];
                        i++;
                    }
                }
                return sorted;
            }
        }
    }
}
