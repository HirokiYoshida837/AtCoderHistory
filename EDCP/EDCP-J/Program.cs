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

namespace EDCP_J
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();

            var dictionary = aList
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            var c = new int[4];
            if (dictionary.ContainsKey(1)) c[1] = dictionary[1];
            if (dictionary.ContainsKey(2)) c[2] = dictionary[2];
            if (dictionary.ContainsKey(3)) c[3] = dictionary[3];

            var dp = new double[n+2, n+2, n+2];

            for (int c3 = 0; c3 < n + 1; c3++)
            {
                for (int c2 = 0; c2 < n + 1; c2++)
                {
                    for (int c1 = 0; c1 < n + 1; c1++)
                    {
                        var sum = (double) c1 + c2 + c3;

                        if (sum == 0)
                        {
                            continue;
                        }

                        dp[c1, c2, c3] = (1.0d * n) / ((double) sum);

                        if (c1 != 0)
                        {
                            dp[c1, c2, c3] += dp[c1 - 1, c2, c3] * c1 / sum;
                        }

                        if (c2 != 0)
                        {
                            dp[c1, c2, c3] += dp[c1 + 1, c2 - 1, c3] * c2 / sum;
                        }

                        if (c3 != 0)
                        {
                            dp[c1, c2, c3] += dp[c1, c2 + 1, c3 - 1] * c3 / sum;
                        }
                    }
                }
            }

            Console.WriteLine(dp[c[1], c[2], c[3]]);
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