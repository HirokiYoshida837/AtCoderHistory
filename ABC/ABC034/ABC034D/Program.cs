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

namespace ABC034D
{
    // https://atcoder.jp/contests/abc034/tasks/abc034_d
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();

            (long w, long p)[] wpList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long>())
                .ToArray();

            // 答え決め打ちの二分探索 x greedy

            // 少なくとも0%は満たすはず。101%は満たさない。
            var ok = 0f;
            var ng = 101f;

            bool solve(float m)
            {
                // 貪欲に選んでチェック

                var floats = wpList.Select(x => x.w * (x.p - m))
                    .OrderByDescending(x => x)
                    .Take(k)
                    .Sum();

                return floats >= 0;
            }

            // めぐる式二分探索。
            while (Math.Abs(ok - ng) > 0.00001)
            {
                var mid = (ok + ng) / 2f;

                if (solve(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }

            Console.WriteLine(ok);
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