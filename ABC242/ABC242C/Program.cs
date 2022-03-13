using System;

namespace ABC242C
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            const long MOD = 998244353;


            var dp = new long[n + 1, 10];

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        dp[i, j] = 1;
                    }
                }

                for (int f = 0; f <= 9; f++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (1 <= k + f && k + f <= 9)
                        {
                            dp[i, f] += (dp[i - 1, k + f]) % MOD;
                        }
                    }
                }
            }

            var count = 0L;
            for (int i = 1; i <= 9; i++)
            {
                count += dp[n, i] % MOD;
            }

            Console.WriteLine(count % MOD);
        }
    }
}