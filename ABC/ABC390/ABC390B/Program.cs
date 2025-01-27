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

namespace ABC390B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var a = ReadList<long>().ToList();

            if (n == 2)
            {
                Console.WriteLine("Yes");
                return;
            }

            if (a.All(x => x == a[0]))
            {
                Console.WriteLine("Yes");
                return;
            }

            if (a[1] < a[0])
            {
                a = a.ToArray().Reverse().ToList();
            }


            var a0 = a[0];
            var a1 = a[1];

            var gcdA0A1 = GCD(a0, a1);
            var lm1 = a0 / gcdA0A1;
            var rm1 = a1 / gcdA0A1;

            var tuple = (Math.Min(lm1, rm1), Math.Max(lm1, rm1));


            for (int i = 0; i < n - 1; i++)
            {
                var l = a[i];
                var r = a[i + 1];

                var gcd = GCD(l, r);


                var lm = l / gcd;
                var rm = r / gcd;

                var tuple2 = (Math.Min(lm, rm), Math.Max(lm, rm));


                if (tuple != tuple2)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
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
            return (T)Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2)),
                (T3)Convert.ChangeType(input[2], typeof(T3))
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
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}