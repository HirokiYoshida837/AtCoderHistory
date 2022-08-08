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

namespace ABC166C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var hList = ReadList<long>().ToArray();

            (int a, int b)[] abList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .Select(x => (x.Item1 - 1, x.Item2 - 1))
                .ToArray();

            var dictionary = Enumerable.Range(0, n)
                .Select(x => x)
                .ToDictionary(x => x, x => -1L);


            foreach (var (a, b) in abList)
            {
                dictionary[a] = Math.Max(dictionary[a], hList[b]);
                dictionary[b] = Math.Max(dictionary[b], hList[a]);
            }

            var count = 0L;
            foreach (var (key, max) in dictionary)
            {
                var h = hList[key];
                if (max == -1)
                {
                    count++;
                    continue;
                }

                if (h > max)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
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