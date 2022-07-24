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

namespace ABC252D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var a = ReadList<int>().ToArray();


            // 累積和を作る
            var count = new long[200000 + 1];
            for (int i = 0; i < a.Length; i++)
            {
                count[a[i]] += 1;
            }

            for (int i = 0; i < 200000; i++)
            {
                count[i + 1] += count[i];
            }


            var ans = 0L;
            // jを全探索する
            for (int j = 0; j < a.Length; j++)
            {
                // a[j]未満の数の個数
                var left = count[a[j] - 1];
                // a[j]より大きい数の個数
                var right = n - count[a[j]];

                ans += left * right;
            }


            Console.WriteLine(ans);
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