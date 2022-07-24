using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC233D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split().Select(long.Parse).ToList();
            var (n, k) = (nk[0], nk[1]);
            var a = Console.ReadLine().Split().Select(long.Parse).ToList();

            // 累積和
            var cum = new List<long> {0};
            foreach (var l in a)
            {
                cum.Add(cum.Last() + l);
            }

            var ans = 0L;
            var map = new Dictionary<long, long>();

            for (int r = 1; r <= n; r++)
            {
                if (map.ContainsKey(cum[r - 1]))
                {
                    map[cum[r - 1]]++;
                }
                else
                {
                    map.Add(cum[r - 1], 1);
                }

                ans += map.TryGetValue(cum[r] - k, out var val) ? val : 0;
            }


            Console.WriteLine(ans);
        }
    }
}