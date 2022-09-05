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

namespace Hard_8
{
    /// <summary>
    /// [E - Double Factorial](https://atcoder.jp/contests/abc148/tasks/abc148_e)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();

            if (n % 2 != 0)
            {
                Console.WriteLine(0);
                return;
            }

            var ans = 0L;
            
            // nに何個10の倍数が含まれているか。
            ans += n / 10;
            
            n /= 10;

            var p = 5L;

            while (p <= n)
            {
                ans += n / p;
                p *= 5;
            }

            // var ans = Math.Min(g2(n, 2), g2(n, 5));

            Console.WriteLine(ans);
        }

        // public static long g1(long n, int p)
        // {
        //     if (n == 0)
        //     {
        //         return 0;
        //     }
        //
        //     return n / p + g1(n / p, p);
        // }
        //
        // public static long g2(long n, int p)
        // {
        //     if (n % 2 == 1)
        //     {
        //         return g1(n, p) - g2(n - 1, p);
        //     }
        //
        //
        //     var res = g1(n / 2, p);
        //
        //     if (p == 2)
        //     {
        //         res += n / 2;
        //     }
        //
        //     return res;
        // }


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