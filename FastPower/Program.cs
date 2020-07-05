using System;

namespace FastPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FastPower(3,4));
        }

        static int FastPower(int a, int b)
        {
            int c = default, answer = default;
            if (b == 1)
                return a;
            else
            {
                c = a * a;
                answer = FastPower(c, b / 2);
            }
            if (b % 2 == 0)
                return answer;
            else
                return a * answer;
        }
    }
}
