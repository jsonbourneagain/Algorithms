using System;
namespace karatsuba
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1342;
            int y = 5673;
            Console.WriteLine(RecIntMul(x, y));
        }

        // Input: two n-digit positive integers x and y
        // Output: the product x.y
        // Assumption: n is a power of 2.

        static Int32 RecIntMul(int x, int y)
        {
            // If any of the numbers are zero, return 0
            if (x == 0 || y == 0)
                return 0;

            // Calculate the number of digits in x & y and take min() of that for computation
            var n = Convert.ToInt32(Math.Min(Math.Floor(Math.Log10(x) + 1), Math.Floor(Math.Log10(y) + 1)));

            var m = n / 2;
            // Base case for the recursion
            if (n == 1)
                return x * y;

            // Divide the given number in 2 halves, first and second
            else
            {
                var a = Convert.ToInt32(Math.Floor(x / Math.Pow(10, m)));
                var b = Convert.ToInt32(Math.Floor(x % Math.Pow(10, m)));
                var c = Convert.ToInt32(Math.Floor(y / Math.Pow(10, m)));
                var d = Convert.ToInt32(Math.Floor(y % Math.Pow(10, m)));

                Int32 p = a + b; Int32 q = c + d;

                var ac = RecIntMul(a, c);
                var bd = RecIntMul(b, d);
                var pq = RecIntMul(p, q);

                var adbc = pq - ac - bd;

                var result = Convert.ToInt32(Math.Pow(10, n) * ac + Math.Pow(10, n / 2) * adbc + bd);

                return result;
            }
        }
    }
}
