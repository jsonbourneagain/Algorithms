using System;
using System.Linq;

namespace UnimodalArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 3, 5, 50, 54, 79, 80, 90, 91, 25, 24, 23, 22, 20 };

            Console.WriteLine(MaxOfUnimodalArray(A));
        }

        static int MaxOfUnimodalArray(int[] A)
        {

            if (A.Length == 1)
                return A[0];
            else
            {
                var n = A.Length;
                var left = A.Take(n / 2);
                var right = A.Skip(n / 2);

                if (left.Last() > right.First())
                    return MaxOfUnimodalArray(left.ToArray());
                else
                    return MaxOfUnimodalArray(right.ToArray());
            }
        }
    }
}
