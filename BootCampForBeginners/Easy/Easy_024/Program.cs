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

namespace Easy_024
{
    // https://atcoder.jp/contests/hitachi2020/tasks/hitachi2020_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b, m) = ReadValue<int, int, int>();
            var aList = ReadList<int>().ToArray();
            var bList = ReadList<int>().ToArray();

            (int x, int y, int c)[] xycList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int, int>())
                .Select(x=>(x.Item1-1, x.Item2 -1, x.Item3))
                .ToArray();

            // 割引券なしで買った場合
            var tmpMin = aList.Min() + bList.Min();
            
            // 割引券全ケースを試す
            foreach (var (x,y,c) in xycList)
            {
                var ap = aList[x];
                var bp = bList[y];

                var sum = ap + bp - c;

                tmpMin = Math.Min(tmpMin, sum);
            }

            Console.WriteLine(tmpMin);

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