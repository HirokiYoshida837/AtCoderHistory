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

namespace Hard_024
{
    /// <summary>
    /// [B - Robot Arms](https://atcoder.jp/contests/keyence2020/tasks/keyence2020_b)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            var xlList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long>())
                .ToArray();


            var eventList = xlList.Select(x => (left: x.Item1 - x.Item2, right: x.Item1 + x.Item2))
                .OrderBy(x => x.right)
                .ToArray();


            var last = long.MinValue + 10;
            var removeCount = 0L;


            foreach (var (left, right) in eventList)
            {
                if (last > left)
                {
                    removeCount += 1;
                }
                else
                {
                    last = right;
                }
            }

            Console.WriteLine(n - removeCount);
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