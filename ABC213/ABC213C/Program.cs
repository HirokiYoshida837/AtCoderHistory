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

namespace ABC213C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w, n) = ReadValue<int, int, int>();
            (int, int)[] ab = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // 座標圧縮
            var aList = ab.Select(x => x.Item1).Distinct().OrderBy(x => x).ToList();
            var bList = ab.Select(x => x.Item2).Distinct().OrderBy(x => x).ToList();


            var aPressed = aList.Select((x, i) => (x, i))
                .ToDictionary(x => x.x, x => x.i);

            var bPressed = bList.Select((x, i) => (x, i))
                .ToDictionary(x => x.x, x => x.i);

            foreach (var (a, b) in ab)
            {
                var item1 = aPressed[a] + 1;
                var item2 = bPressed[b] + 1;

                Console.WriteLine($"{item1} {item2}");
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