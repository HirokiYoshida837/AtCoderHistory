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

namespace Hard_019
{
    /// <summary>
    /// [D - Grid Coloring](https://atcoder.jp/contests/abc069/tasks/arc080_b)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();

            var matrixBase = new List<int>();

            var dic = aList.Select((x, i) => (x, i + 1)).OrderByDescending(x => x).ToArray()
                .ToDictionary(x => x.Item2, x => x.x);

            foreach (var keyValuePair in dic.OrderByDescending(x => x.Value))
            {
                matrixBase.AddRange(Enumerable.Repeat(keyValuePair.Key, keyValuePair.Value));
            }


            var chunkSize = w;

            var chunked = matrixBase.Select((x, i) => (x, i))
                .GroupBy(x => x.i / chunkSize)
                .Select(x => x.Select(x => x.x))
                .ToList();


            var matrix = new List<List<int>>();

            var index = 0;
            foreach (var ints in chunked)
            {
                if (index % 2 == 0)
                {
                    matrix.Add(ints.ToList());
                }
                else
                {
                    matrix.Add(ints.Reverse().ToList());
                }

                index++;
            }


            foreach (var ints in matrix)
            {
                var @join = String.Join(' ', ints);
                Console.WriteLine(join);
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