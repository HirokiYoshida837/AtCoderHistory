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

namespace Easy_075
{
    // https://atcoder.jp/contests/abc115/tasks/abc115_c
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var hList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int>())
                .ToArray();

            var diffMin = int.MaxValue / 2;

            hList = hList.OrderBy(x => x).ToArray();

            for (var i = k - 1; i < hList.Length; i++)
            {
                var l = hList[i - (k - 1)];
                var r = hList[i];

                var diff = r - l;

                diffMin = Math.Min(diffMin, diff);
            }

            Console.WriteLine(diffMin);
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