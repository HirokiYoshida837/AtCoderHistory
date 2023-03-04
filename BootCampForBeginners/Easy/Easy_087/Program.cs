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

namespace Easy_087
{
    // https://atcoder.jp/contests/abc087/tasks/arc090_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            var a = Enumerable.Range(0, 2)
                .Select(_ => ReadList<int>().ToArray())
                .ToArray();


            var uCum = new List<int>() {0};
            for (var i = 0; i < a[0].Length; i++)
            {
                var item = a[0][i];
                uCum.Add(uCum.Last() + item);
            }

            var dCum = new List<int>() {0};
            for (var i = 0; i < a[1].Length; i++)
            {
                var item = a[1][i];
                dCum.Add(dCum.Last() + item);
            }


            var max = 0L;
            // 下にいつ降りるか？で全探索
            for (int i = 0; i < n; i++)
            {
                var uSum = uCum[i+1] - uCum.First();
                var dSum = dCum.Last() - dCum[i];


                var v = uSum + dSum;

                max = Math.Max(max, v);
            }

            Console.WriteLine(max);
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