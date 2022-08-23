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

namespace ABC162C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var k = ReadValue<int>();

            var gcdMemo = new Dictionary<(long, long), long>();

            var sum = 0L;
            for (int a = 1; a <= k; a++)
            {
                for (int b = 1; b <= k; b++)
                {
                    for (int c = 1; c <= k; c++)
                    {
                        if (!gcdMemo.ContainsKey((a, b)))
                        {
                            gcdMemo.Add((a, b), GCD(a, b));
                            if (a != b)
                            {
                                gcdMemo.Add((b, a), gcdMemo[(a, b)]);
                            }
                        }

                        var v = gcdMemo[(a, b)];

                        if (!gcdMemo.ContainsKey((v, c)))
                        {
                            gcdMemo.Add((v, c), GCD(v, c));
                            if (v != c)
                            {
                                gcdMemo.Add((c, v), gcdMemo[(v, c)]);
                            }
                        }

                        var gcd = gcdMemo[(v, c)];
                        sum += gcd;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// 最大公約数 (the Greatest Common Divisor) を計算します。(再帰なし)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static long GCD(long a, long b)
        {
            while (true)
            {
                if (b == 0) return a;
                a %= b;
                if (a == 0) return b;
                b %= a;
            }
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