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

namespace ABC267D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var aList = ReadList<long>().ToArray();

            var dp = new long[n + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = Enumerable.Repeat(long.MinValue / 2, m + 1).ToArray();
            }

            dp[0][0] = 0;
            dp[1][0] = 0;
            dp[1][1] = aList[0];

            // もらうDP
            for (long i = 2; i <= n; i++)
            {
                for (long j = 0; j <= m; j++)
                {
                    if (j == 0)
                    {
                        dp[i][j] = 0;
                        continue;
                    }

                    if (j <= m)
                    {
                        // 取らないケース と 取るケース (i-1,j-1) + a*jの比較。
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - 1] + aList[i - 1] * j);
                    }
                }
            }

            Console.WriteLine(dp[n][m]);
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