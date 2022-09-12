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

namespace ABC250D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();

            var searchList = Enumerable.Range(0, 1000000 + 10).Select(_ => 1).ToArray();
            searchList[0] = 0;
            searchList[1] = 0;

            var primeList = new List<long>();

            for (var i = 0; i < searchList.Length; i++)
            {
                if (searchList[i] == 0)
                {
                    continue;
                }

                primeList.Add(i);

                for (int q = i * 2; q < searchList.Length; q += i)
                {
                    searchList[q] = 0;
                }
            }


            var ansSet = new HashSet<long>();
            var ansCount = 0L;

            for (var i = 0; i < primeList.Count; i++)
            {
                var q = primeList[i];
                var tq = q * q * q;

                if (tq > n)
                {
                    break;
                }

                // 使える数の最大値
                var d = n / tq;
                d = Math.Min(q - 1, d);

                // d以下の数の個数を二分探索で数える。
                var ub = primeList.BinarySearch(d, new UpperBound<long>());
                if (ub < 0) ub = ~ub;

                ansCount += ub;

                // // 全部の素数で確認していくと計算量ギリギリ (1900ms)。
                // for (var j = 0; j < i; j++)
                // {
                //     var p = primeList[j];
                //
                //     if (p * tq > n)
                //     {
                //         break;
                //     }
                //
                //     ansSet.Add(p * tq);
                // }
            }

            // Console.WriteLine(ansSet.Count);
            Console.WriteLine(ansCount);
        }

        /// <summary>
        /// ソート済Arrayを二部探索して、UpperBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getUpperBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class UpperBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 < x.CompareTo(y) ? 1 : -1;
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