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

namespace ABC261D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var xList = ReadList<long>().ToArray();

            var cyList = Enumerable.Range(0, m).Select(_ => ReadValue<int, long>())
                .ToDictionary(x => x.Item1, x => x.Item2);

            // Math.Max取るので、計算しやすくするため、値が入ってないところは0を入れておく。
            for (int i = 1; i <= n; i++)
            {
                if (!cyList.ContainsKey(i))
                {
                    cyList.Add(i, 0L);
                }
            }

            var dp = new long[n + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[n + 10];
            }

            // 配るDP
            dp[1][1] = xList[0];
            if (cyList.ContainsKey(1))
            {
                dp[1][1] += cyList[1];
            }

            for (int i = 1; i < n; i++)
            {
                for (int c = 0; c <= i; c++)
                {
                    // 裏のときは0に遷移する
                    dp[i + 1][0] = Math.Max(dp[i + 1][0], dp[i][c]);

                    // 表が出たときの遷移 (じつはこれはMath.maxは取らなくてもいい)
                    dp[i + 1][c + 1] = Math.Max(dp[i + 1][c + 1], dp[i][c] + xList[i] + cyList[c + 1]);
                }
            }
            Console.WriteLine(dp.Last().Max());
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