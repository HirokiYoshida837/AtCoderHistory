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

namespace Hard_030
{
    /// <summary>
    /// [A - Getting Difference](https://atcoder.jp/contests/agc018/tasks/agc018_a)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            // DFSやBFSでをやる方法だと、個数が多いのでTLEになる。(nが10^5くらいあるので、流石に厳しい。)
            var (n, k) = ReadValue<int, long>();
            var aList = ReadList<long>().Distinct().ToList();
            var aMax = aList.Max();

            var visited = new HashSet<long>();
            var aHashSet = aList.ToHashSet();

            if (aHashSet.Contains(k))
            {
                Console.WriteLine("POSSIBLE");
                return;
            }

            if (k > aMax)
            {
                Console.WriteLine("IMPOSSIBLE");
                return;
            }

            bool DFS(long target)
            {
                visited.Add(target);

                foreach (var l in aList)
                {
                    if (l - target > 0)
                    {
                        if (aHashSet.Contains(l - target))
                        {
                            return true;
                        }

                        if (visited.Contains(l - target))
                        {
                            continue;
                        }

                        var dfs = DFS(l - target);

                        if (dfs)
                        {
                            return true;
                        }
                    }

                    if (l + target <= aMax)
                    {
                        if (aHashSet.Contains(l + target))
                        {
                            return true;
                        }

                        if (visited.Contains(l + target))
                        {
                            continue;
                        }

                        var dfs = DFS(l + target);

                        if (dfs)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            var b = DFS(k);

            Console.WriteLine(b ? "POSSIBLE" : "IMPOSSIBLE");
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2)),
                (T3) Convert.ChangeType(input[2], typeof(T3))
            );
        }

        /// <summary>
        /// 指定した型として、一行読み込む。
        /// </summary>
        /// <param name="separator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
#nullable enable
        public static IEnumerable<T> ReadList<T>(params char[]? separator)
        {
            return Console.ReadLine()
                .Split(separator)
                .Select(x => (T) Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}