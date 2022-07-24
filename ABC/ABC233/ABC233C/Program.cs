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

namespace ABC233C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nx = Console.ReadLine().Split().Select(long.Parse).ToList();
            var (n, x) = (nx[0], nx[1]);

            var la = Enumerable.Range(0, (int) n)
                .Select(_ => Console.ReadLine().Split().Select(long.Parse).ToList())
                .ToList();

            var l = la.Select(x => x[0]).ToList();
            var a = la.Select(x => x.GetRange(1, x.Count - 1)).ToList();

            var count = 0;

            dfs(1, -1);

            Console.WriteLine(count);

            void dfs(long cv, int depth)
            {
                if (depth == n - 1)
                {
                    if (cv == x)
                    {
                        count++;
                    }

                    return;
                }

                depth++;
                foreach (var item in a[depth])
                {
                    // オーバーフローのチェック
                    var v = 0l;
                    try
                    {
                        checked
                        {
                            v = cv * item;
                        }
                    }
                    catch (Exception e)
                    {
                        // 例外でても握る
                        continue;
                    }

                    dfs(v, depth);
                }
            }
        }
    }
}