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

namespace EDCP_C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (int a, int b, int c)[] abcList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int, int>())
                .ToArray();

            var dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[3];
            }

            dp[0][0] = abcList[0].a;
            dp[0][1] = abcList[0].b;
            dp[0][2] = abcList[0].c;
            
            
            // もらうDPで考える
            for (int i = 1; i < n; i++)
            {
                var (a, b, c) = abcList[i];

                var nextA = Math.Max(dp[i - 1][1] + a, dp[i - 1][2] + a);
                
                var nextB = Math.Max(dp[i - 1][0] + b, dp[i - 1][2] + b);
                
                var nextC = Math.Max(dp[i - 1][0] + c, dp[i - 1][1] + c);

                dp[i][0] = nextA;
                dp[i][1] = nextB;
                dp[i][2] = nextC;
            }

            var max = dp.Last().Max();
            Console.WriteLine(max);
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