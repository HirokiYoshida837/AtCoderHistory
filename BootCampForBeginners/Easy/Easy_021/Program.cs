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

namespace Easy_021
{
    // https://atcoder.jp/contests/abc149/tasks/abc149_c
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = ReadValue<int>();

            var longs = EratosthenesSieve.calc(1000000).ToList();

            var lb = longs.BinarySearch(x, new LowerBound<int>());
            if (lb < 0) lb = ~lb;


            Console.WriteLine(longs[lb]);
        }

        /// <summary>
        /// ソート済Arrayを二部探索して、LowerBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getLowerBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 <= x.CompareTo(y) ? 1 : -1;
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

    // エラトステネスの篩（適当実装）
    public class EratosthenesSieve
    {
        // 適当実装なのでバグってるかも
        public static IEnumerable<int> calc(int n)
        {
            var primes = Enumerable.Range(0, 2 * n).Select(_ => true).ToArray();

            primes[0] = false;
            primes[1] = false;
            primes[2] = true;
            primes[^1] = false;

            for (long p = 2; p < primes.Length; p++)
            {
                if (primes[p])
                {
                    for (long i = p * p; i < primes.Length; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }

            for (var i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    yield return i;
                }
            }
        }
    }
}