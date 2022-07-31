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

namespace EDCP_E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, w) = ReadValue<int, long>();

            (long w, long v)[] wvList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long>())
                .ToArray();


            var dp = new long[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = Enumerable.Range(0, n * 1010 + 1).Select(_ => int.MaxValue).Select(x => (long) x).ToArray();
            }

            dp[0][0] = 0;

            var max = 0L;

            for (int i = 0; i < n; i++)
            {
                // i個目の荷物までを詰めていくときの、最大値を順番に考えていく。
                var (weight, value) = wvList[i];

                for (int j = 0; j < n * 1010 + 1; j++)
                {
                    if (j - value >= 0)
                    {
                        dp[i + 1][j] = Math.Min(dp[i][j], dp[i][j - value] + weight);
                    }
                    else
                    {
                        dp[i + 1][j] = dp[i][j];
                    }
                }
            }

            var ans = 0L;
            for (int val = 0; val < n * 1010 + 1; val++)
            {
                if (dp[n][val] <= w)
                {
                    ans = Math.Max(ans, val);
                }
            }

            Console.WriteLine(ans);
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