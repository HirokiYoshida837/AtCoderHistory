using System;
using System.Linq;

namespace ABC238C
{
    class Program
    {
        const long MOD = 998244353;

        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var ans = 0L;


            var p = 1L;
            for (int i = 1; i <= 18; i++)
            {
                var left = p;
                var right = Math.Min(p * 10 - 1, n);

                ans += (calc(right, left));
                ans %= MOD;

                if (right == n)
                {
                    break;
                }

                p *= 10;
            }


            Console.WriteLine(ans);
        }

        private static long calc(long r, long l)
        {
            // var nums = r - l + 1;
            var x = (r - l + 1) % MOD;

            long res = x;

            res *= ((x + 1) % MOD);
            res %= MOD;

            res *= 499122177;
            res %= MOD;

            return res;
        }
    }
}