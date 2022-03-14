using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC240C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nx = Console.ReadLine().Split().Select(int.Parse).ToList();
            var n = nx[0];
            var x = nx[1];

            var ab = new List<(int A, int B)>();
            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split().Select(int.Parse).ToList();
                ab.Add((list[0], list[1]));
            }

            var dp = new Boolean[n + 1, 2 * (x + 1)];
            dp[0, 0] = true;


            for (var i = 0; i < ab.Count; i++)
            {
                for (int j = 0; j < 2 * (x + 1); j++)
                {
                    if (dp[i, j])
                    {
                        if (j + ab[i].A <= x + 1)
                        {
                            dp[i + 1, j + ab[i].A] = true;
                        }

                        if (j + ab[i].B <= x + 1)
                        {
                            dp[i + 1, j + ab[i].B] = true;
                        }
                    }
                }
            }

            var ans = dp[n, x];

            Console.WriteLine(ans ? "Yes" : "No");
        }
    }
}