using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC245C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, k) = (nk[0], nk[1]);

            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var A = new[] {a, b};

            var dp = new bool[n, 2];
            dp[0, 0] = true;
            dp[0, 1] = true;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int previousI = i - 1;

                    for (int previousJ = 0; previousJ < 2; previousJ++)
                    {
                        if (dp[previousI, previousJ])
                        {
                            if (Math.Abs(A[previousJ][previousI] - A[j][i]) <= k)
                            {
                                dp[i, j] = true;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(dp[n-1,0] || dp[n-1,1] ? "Yes" : "No");
        }
    }
}