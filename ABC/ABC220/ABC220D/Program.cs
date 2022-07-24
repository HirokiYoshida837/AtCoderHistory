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

namespace ABC220D
{
    public static class Program
    {
        private static long MOD = 998244353L;

        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var a = ReadList<long>().ToArray();

            long[,] dp = new long[n + 1, 10];
            dp[1, a[0]] = 1;

            static long F(long x, long y)
            {
                return (x + y) % 10;
            }

            static long G(long x, long y)
            {
                return (x * y) % 10;
            }

            // 配るDP的に考える。
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    dp[i + 1, F(j, a[i])] = (dp[i + 1, F(j, a[i])] + dp[i, j]) % MOD;
                    dp[i + 1, G(j, a[i])] = (dp[i + 1, G(j, a[i])] + dp[i, j]) % MOD;
                }
            }


            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(dp[n, i]);
            }
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