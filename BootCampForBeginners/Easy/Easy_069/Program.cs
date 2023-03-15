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

namespace Easy_069
{
    // https://atcoder.jp/contests/agc037/tasks/agc037_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            var dp = new int[s.Length + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[5];
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // 1文字つかうか、2文字使うか
                    for (int k = 1; k <= 4; k++)
                    {
                        if (i + k >= dp.Length)
                        {
                            break;
                        }

                        if (i - j < 0)
                        {
                            dp[i + k][k] = Math.Max(dp[i + k][k], dp[i][j] + 1);
                        }
                        else
                        {
                            var previous = s.Substring(i - j, j);
                            var current = s.Substring(i, k);

                            if (previous == current)
                            {
                                continue;
                            }


                            dp[i + k][k] = Math.Max(dp[i + k][k], dp[i][j] + 1);
                        }
                    }
                }
            }


            var i1 = dp.Last()[1];
            var i2 = dp.Last()[2];

            Console.WriteLine(Math.Max(i1, i2));
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