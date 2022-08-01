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

namespace ABC211C
{
    public static class Program
    {
        private const long MOD = 1000000000 + 7;
        private const string chokudai = "chokudai";

        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            var dp = new long[chokudai.Length][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[s.Length];
            }

            if (s[0] == chokudai[0])
            {
                dp[0][0] = 1;
            }

            // 1行目を初期化
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == chokudai[0])
                {
                    dp[0][i] = dp[0][i - 1] + 1;
                }
                else
                {
                    dp[0][i] = dp[0][i - 1];
                }
            }


            for (int j = 1; j < chokudai.Length; j++)
            {
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == chokudai[j])
                    {
                        dp[j][i] = (dp[j][i - 1] + dp[j - 1][i - 1]) % MOD;
                    }
                    else
                    {
                        dp[j][i] = dp[j][i - 1];
                    }
                }
            }

            Console.WriteLine(dp.Last().Last());


            // // 配るDPで考える
            // // 一次元DPで考える場合
            //
            // var dp = new long[9];
            // dp[0] = 1;
            // for (int i = 0; i < s.Length; i++)
            // {
            //     for (int j = 0; j < chokudai.Length; j++)
            //     {
            //         if (s[i] == chokudai[j])
            //         {
            //             dp[j + 1] += dp[j];
            //             dp[j + 1] %= MOD;
            //         }
            //     }
            // }
            //
            // Console.WriteLine(dp[^1]);
            //
            // // 貰うDPで解く。
            // // 二次元DPで考える場合
            // // var dp = new long[s.Length][];
            // //
            // // for (int i = 0; i < s.Length; i++)
            // // {
            // //     dp[i] = new long[chokudai.Length];
            // // }
            // // if (s[0] == 'c')
            // // {
            // //     dp[0][0] = 1;
            // // }
            // //
            // // for (int i = 1; i < s.Length; i++)
            // // {
            // //     for (int j = 0; j < chokudai.Length; j++)
            // //     {
            // //         dp[i][j] = dp[i - 1][j];
            // //
            // //         if (s[i] == chokudai[j])
            // //         {
            // //             if (j >= 1)
            // //             {
            // //                 dp[i][j] = (dp[i][j] + dp[i - 1][j - 1]) % MOD;
            // //             }
            // //             else
            // //             {
            // //                 dp[i][j] = (dp[i][j] + 1) % MOD;
            // //             }
            // //         }
            // //     }
            // // }
            // // Console.WriteLine(dp[s.Length - 1][chokudai.Length - 1]);
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