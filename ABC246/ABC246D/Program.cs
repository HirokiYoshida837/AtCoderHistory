using System;
using System.Collections.Generic;

namespace ABC246D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var ans = long.MaxValue;

            for (long a = 0; a <= 1000000; a++)
            {
                // aを固定してbが取りうる値を2分探索
                long ok = 1000000 + 1;
                long ng = -1;

                while (Math.Abs(ok - ng) > 1)
                {
                    var mid = (ok + ng) / 2;
                    if (solve(a, mid) >= n)
                    {
                        ok = mid;
                    }
                    else
                    {
                        ng = mid;
                    }
                }

                // 探索し終わったらansを更新
                ans = Math.Min(solve(a, ok), ans);
            }

            Console.WriteLine(ans);
        }

        static long solve(long a, long b)
        {
            return (a * a * a) + (a * a * b) + (a * b * b) + (b * b * b);
        }
    }
}