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

namespace Hard_10
{
    /// <summary>
    /// [D - Enough Array](https://atcoder.jp/contests/abc130/tasks/abc130_d)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, long>();

            var aList = ReadList<long>().ToArray();

            var cum = new List<long> {0};
            foreach (var l in aList)
            {
                cum.Add(cum.Last() + l);
            }

            var sum = 0L;
            for (var i = 0; i < cum.Count; i++)
            {
                var current = cum[i];
                var target = current + k;
                
                var lb = cum.BinarySearch(target, new LowerBound<long>());
                if (lb < 0) lb = ~lb;

                var diff = (n + 1) - lb;
                sum += diff;
            }

            Console.WriteLine(sum);
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
}