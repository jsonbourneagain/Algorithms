using System;
using System.Linq;

namespace StrassenMatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int[,] RecMatMult(int[,] X, int[,] Y, int n)
        {
            if (n <= 2)
            {
                int A = X[1, 1]; int B = X[1, 2]; int C = X[2, 1]; int D = X[2, 2];
                int E = Y[1, 1]; int F = Y[1, 2]; int G = Y[2, 1]; int H = Y[2, 2];

                int P1 = A * (F - H); int P2 = (A + B) * H; int P3 = (C + D) * E; int P4 = D * (G - E); int P5 = (A + D) * (E + H);
                int P6 = (B - D) * (G + H); int P7 = (A - C) * (E + F);

                int[,] result = new int[2, 2];
                result[1, 1] = P5 + P4 - P2 + P6; result[1, 2] = P1 + P2;
                result[2, 1] = P3 + P4; result[2, 2] = P1 + P5 - P3 - P7;

                return result;
            }
            else
            {
                int[,] A = new int[n / 2, n / 2]; int[,] B = new int[n / 2, n / 2]; int[,] C = new int[n / 2, n / 2]; int[,] D = new int[n / 2, n / 2];
                int[,] E = new int[n / 2, n / 2]; int[,] F = new int[n / 2, n / 2]; int[,] G = new int[n / 2, n / 2]; int[,] H = new int[n / 2, n / 2];


                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        A[i, j] = X[i, j];
                    }
                }
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = n / 2; j < n; j++)
                    {
                        B[i, j] = X[i, j];
                    }
                }
                for (int i = n / 2; i < n; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        C[i, j] = X[i, j];
                    }
                }
                for (int i = n / 2; i < n; i++)
                {
                    for (int j = n / 2; j < n; j++)
                    {
                        D[i, j] = X[i, j];
                    }
                }

                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        E[i, j] = Y[i, j];
                    }
                }
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = n / 2; j < n; j++)
                    {
                        F[i, j] = Y[i, j];
                    }
                }
                for (int i = n / 2; i < n; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        G[i, j] = Y[i, j];
                    }
                }
                for (int i = n / 2; i < n; i++)
                {
                    for (int j = n / 2; j < n; j++)
                    {
                        H[i, j] = Y[i, j];
                    }
                }
                
                int P1 = A * (F - H); int P2 = (A + B) * H; int P3 = (C + D) * E; int P4 = D * (G - E); int P5 = (A + D) * (E + H);
                int P6 = (B - D) * (G + H); int P7 = (A - C) * (E + F);

            }
        }
    }
}
