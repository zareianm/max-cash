using System;

namespace cash
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');

            long n = long.Parse(s[0]);
            long m = long.Parse(s[1]);

            long[] a = new long[n];

            for (long i = 0; i <n; i++)
            {
                a[i] = long.Parse(Console.ReadLine());
            }

            Console.WriteLine(MinPrice(a, n, m));
        }

        private static long MinPrice(long[] a, long n, long m)
        {
            long[,] DP = new long[m + 1, n + 1];

            for (long i = 1; i <= m; i++)
            {
                DP[i, 0] = long.MaxValue;
            }

            for (long i = 0; i <= m; i++)
            {
                for (long j = 1; j <= n; j++)
                {

                    DP[i,j] = long.MaxValue;

                    for (long k = 0; k <= Math.Sqrt(i); k++)
                    {
                        long area = k * k;
                        if (i - area >= 0 && DP[i - area, j - 1] != long.MaxValue)

                            DP[i, j] = Math.Min(DP[i,j], DP[i-area,j-1] + (a[j-1] - k)*(a[j-1] - k)) ;
                    }

                }
            }

            if (DP[m, n] == long.MaxValue)
                return -1;

            return DP[m, n];
        }
    }
}
