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

namespace Hard_011
{
    /// <summary>
    /// [D - Disjoint Set of Common Divisors](https://atcoder.jp/contests/abc142/tasks/abc142_d)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b) = ReadValue<long, long>();

            var gcd = GCD(a, b);

            var longs = PrimeFactors(gcd).ToList();

            Console.WriteLine(longs.Distinct().Count()+1);
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
        
        /// <summary>
        /// 素因数分解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeFactors(long n)
        {
            long i = 2;
            long tmp = n;

            while (i * i <= n)
            {
                if (tmp % i == 0)
                {
                    tmp /= i;
                    yield return i;
                }
                else
                {
                    i++;
                }
            }

            if (tmp != 1) yield return tmp; //最後の素数も返す
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