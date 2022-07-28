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

namespace EDCP_D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, w) = ReadValue<int, int>();

            (int w, int v)[] wvList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();


            var dp = new long[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new long[w+1];
            }


            // 配るDP
            for (int i = 0; i < n; i++)
            {
                // i個目の荷物までを詰めていくときの、最大値を順番に考えていく。
                var (weight, value) = wvList[i];
                
                // i個目の荷物の重さが total値以下であれば、total-weight からの遷移として考える。
                for (int total = 0; total <= w; total++)
                {
                    if (total >= weight)
                    {
                        dp[i + 1][total] = Math.Max(dp[i][total], dp[i][total - weight] + value);
                    }
                    else
                    {
                        dp[i + 1][total] = dp[i][total];
                    }
                }
            }

            Console.WriteLine(dp[n][w]);
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