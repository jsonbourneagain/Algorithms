using System;
using System.Linq;

namespace SplitInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[6] { 1, 3, 5, 2, 4, 6 };

            Console.WriteLine(SortAndCountInversion(arr).Inversions);
        }

        public static ArrayAndInversion SortAndCountInversion(int[] A)
        {
            int length = A.Length;
            int n = length / 2;

            if (length == 0 || length == 1)
                return new ArrayAndInversion { Arr = A, Inversions = 0 };

            ArrayAndInversion left = SortAndCountInversion(A.Take(n).ToArray());
            ArrayAndInversion right = SortAndCountInversion(A.Skip(n).ToArray());
            ArrayAndInversion split = MergeAndCountSplitInversion(left, right);

            return new ArrayAndInversion { Arr = split.Arr, Inversions = left.Inversions + right.Inversions + split.Inversions };

            ArrayAndInversion MergeAndCountSplitInversion(ArrayAndInversion left, ArrayAndInversion right)
            {
                int i = 0, j = 0, splitInversions = 0;
                int length = left.Arr.Length + right.Arr.Length;

                int[] B = new int[length];

                for (int k = 0; k < length; k++)
                {
                    if (i < left.Arr.Length && j < right.Arr.Length)
                    {

                        if (left.Arr[i] < right.Arr[j])
                        {
                            B[k] = left.Arr[i];
                            i++;
                        }
                        else
                        {
                            B[k] = right.Arr[j];
                            j++;
                            splitInversions += (length / 2 - i);
                        }
                    }
                    else if (i < left.Arr.Length && j == right.Arr.Length)
                    {
                        B[k] = left.Arr[i];
                        i++;
                    }
                    else if (i == left.Arr.Length && j < right.Arr.Length)
                    {
                        B[k] = right.Arr[j];
                        j++;
                    }
                }
                return new ArrayAndInversion { Arr = B, Inversions = splitInversions };
            }
        }
    }
}