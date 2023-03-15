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

namespace Easy_082
{
    // https://atcoder.jp/contests/agc019/tasks/agc019_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var qhsd = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var (q, h, s, d) = (qhsd[0], qhsd[1], qhsd[2], qhsd[3]);
            var n = ReadValue<long>();

            var perfQ = q * 4;
            var perfH = h * 2;
            var perfS = s;
            var perfD = d / 2;

            var l = new[] {("Q", perfQ), ("H", perfH), ("S", perfS), ("D", perfD)};

            var best = l.OrderBy(x => x.Item2).First();

            if (best.Item1 == "Q")
            {
                Console.WriteLine(n * 4 * q);
                return;
            }
            else if (best.Item1 == "H")
            {
                Console.WriteLine(n * 2 * h);
                return;
            }
            else if (best.Item1 == "S")
            {
                Console.WriteLine(n * s);
                return;
            }
            else
            {
                var mod = n % 2;

                if (mod == 0)
                {
                    Console.WriteLine(d * n / 2);
                    return;
                }
                else
                {
                    var cost = (n / 2) * d;
                    var kv = l.OrderBy(x => x.Item2).First(x=>x.Item1!="D");

                    var kvItem2 = cost + kv.Item2;
                    Console.WriteLine(kvItem2);
                    return;
                }
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