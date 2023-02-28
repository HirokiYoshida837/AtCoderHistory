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

namespace Easy_079
{
    // https://atcoder.jp/contests/agc041/tasks/agc041_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, a, b) = ReadValue<long, long, long>();


            var diff = Math.Abs(a - b);

            if (diff % 2 == 0)
            {
                Console.WriteLine(diff / 2);
            }
            else
            {
                // 偶数奇数を反転させるために、1卓で一回勝ってから戻ってくればよさそう
                // 1の方に行くケース
                var cf = ((a - 1) + 1 + (b - a - 1) / 2);


                // lastの方にいくケース
                var cl = ((n - b) + 1 + (b - a - 1) / 2);


                Console.WriteLine(Math.Min(cf, cl));
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