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

namespace ABC228C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var p = Enumerable.Range(0, n)
                .Select(_ => ReadList<int>())
                .ToArray();

            var pSum = p.Select(x => x.Sum()).OrderByDescending(x => x).ToList();
            var pSumArray = p.Select(x => x.Sum()).ToList();
            
            // 順位は1-indexed、配列は0-indexedなので-1する。
            k -= 1;

            foreach (var item in pSumArray)
            {
                // 上からk番目の値より大きいかどうか
                Console.WriteLine(item+300 >= pSum[k] ? "Yes" : "No");
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
                (T3) Convert.ChangeType(input[1], typeof(T3))
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