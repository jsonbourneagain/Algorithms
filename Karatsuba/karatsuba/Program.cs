using System;
using System.Numerics;

namespace KaratsubaMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");

            BigInteger y = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");

            //BigInteger x = BigInteger.Parse("3141592653589793");

            //BigInteger y = BigInteger.Parse("2718281828459045");

            Console.WriteLine(RecIntMul(x, y));
            Console.ReadKey();
        }

        // Input: two n-digit positive integers x and y
        // Output: the product x.y
        // Assumption: n is a power of 2.

        static BigInteger RecIntMul(BigInteger x, BigInteger y)
        {
            // Base case for the recursion
            if (x < 10 && y < 10)
                return x * y;

            // Divide the given number in 2 halves, first and second
            else
            {
                // Calculate the number of digits in x & y and take max() of that for computation
                var n = (int)Math.Max(Math.Floor(BigInteger.Log10(x) + 1), Math.Floor(BigInteger.Log10(y) + 1));

                var m = (n + 1) / 2;

                var a = (x / BigInteger.Parse(BigInteger.Pow(10, m).ToString()));
                var b = (x % BigInteger.Parse(BigInteger.Pow(10, m).ToString()));
                var c = (y / BigInteger.Parse(BigInteger.Pow(10, m).ToString()));
                var d = (y % BigInteger.Parse(BigInteger.Pow(10, m).ToString()));

                BigInteger p = a + b; BigInteger q = c + d;

                var ac = RecIntMul(a, c);
                var bd = RecIntMul(b, d);
                var pq = RecIntMul(p, q);
                var ad = RecIntMul(a, d);
                var bc = RecIntMul(b, c);
                //var adbc = pq - ac - bd;

                var result = (BigInteger.Parse(BigInteger.Pow(10, n).ToString()) * ac) + (BigInteger.Parse(BigInteger.Pow(10, m).ToString()) * (ad + bc)) + bd;

                return result;
            }
        }
    }
}
