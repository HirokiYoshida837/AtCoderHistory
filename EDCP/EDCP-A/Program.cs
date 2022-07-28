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

namespace EDCP_A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var hList = ReadList<int>().ToArray();


            var dp = new int[n];

            dp[0] = 0;
            dp[1] = Abs(hList[0] - hList[1]);

            // もらうDP
            for (int i = 2; i < n; i++)
            {
                var i1 = dp[i-1];
                var i2 = dp[i-2];

                var cost1 = i1 + Abs(hList[i] - hList[i - 1]);
                var cost2 = i2 + Abs(hList[i] - hList[i - 2]);

                dp[i] = Math.Min(cost1, cost2);
            }

            Console.WriteLine(dp.Last());
            


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