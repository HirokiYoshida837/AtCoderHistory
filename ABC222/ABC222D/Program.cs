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

namespace ABC222D
{
    public static class Program
    {
        private static int MOD = 998244353;

        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();
            var bList = ReadList<int>().ToArray();

            long[,] dp = new long[n + 1, 3001];
            dp[0, 0] = 1;

            var cusum = new long[3001];


            // ナイーブなDPだとTLEなので、もらうDP(一つ前の値を取ってきて、nextに足し込んでいく)にしてみる。
            for (int i = 0; i < n; i++)
            {
                cusum[0] = dp[i, 0];
                for (int lst = 1; lst < 3001; lst++)
                {
                    cusum[lst] = (cusum[lst - 1] + dp[i, lst]) % MOD;
                    cusum[lst] %= MOD;
                }

                for (int nxt = aList[i]; nxt <= bList[i]; nxt++)
                {
                    // // 広義単調増加なので、一つ前が取りうるのは nxtまで
                    // for (int lst = 0; lst <= nxt; lst++)
                    // {
                    //     dp[i + 1, nxt] += (dp[i, lst] % MOD);
                    //     dp[i + 1, nxt] %= MOD;
                    // }

                    // dp[i,0]～dp[i,nxt]まで足し込んでる処理なので、累積和をつかって足し込むのを高速化してみる
                    dp[i + 1, nxt] += (cusum[nxt]) % MOD;
                    dp[i + 1, nxt] %= MOD;
                }
            }

            var ans = 0L;
            for (int lst = 0; lst < 3001; lst++)
            {
                ans += (dp[n, lst] % MOD);
                ans %= MOD;
            }

            Console.WriteLine(ans);
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
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