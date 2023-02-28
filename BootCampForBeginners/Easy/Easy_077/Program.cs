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

namespace Easy_077
{
    // https://atcoder.jp/contests/agc012/tasks/agc012_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().ToArray();


            aList = aList.OrderByDescending(x => x).ToArray();

            var groups = new List<long[]>();

            // var takeCount = 0;

            for (var i = 0; i < n; i += 1)
            {
                var l = aList[i * 2];
                var m = aList[i * 2 + 1];
                var r = aList[^(1 + i)];
                groups.Add(new[] {l, m, r});

                // takeCount += 1;
            }

            var sum = groups
                .Select(x => x.OrderBy(x => x).ToArray())
                .Select(x => x[1])
                .Sum();


            Console.WriteLine(sum);
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