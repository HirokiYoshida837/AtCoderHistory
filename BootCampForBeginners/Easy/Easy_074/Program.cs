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

namespace Easy_074
{
    // https://atcoder.jp/contests/abc095/tasks/arc096_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abcxy = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var a = abcxy[0];
            var b = abcxy[1];
            var c = abcxy[2];
            var x = abcxy[3];
            var y = abcxy[4];


            // abピザを買う枚数をmaxから減らしながら考えていく

            var maxReqAB = Math.Max(x, y) * 2;

            var minPrice = c * maxReqAB;

            // 2枚ずつ減らしていく。
            for (int i = maxReqAB; i >= 0; i -= 2)
            {
                var reqA = Math.Max(0, x - (i / 2));
                var reqB = Math.Max(0, y - (i / 2));

                minPrice = Math.Min(minPrice, ((reqA * a + reqB * b) + i * c));
            }

            Console.WriteLine(minPrice);
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