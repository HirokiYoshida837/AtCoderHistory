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

namespace Easy_038
{
    // https://atcoder.jp/contests/abc123/tasks/abc123_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var a = ReadValue<int>();
            var b = ReadValue<int>();
            var c = ReadValue<int>();
            var d = ReadValue<int>();
            var e = ReadValue<int>();


            var l = new List<int>() {a, b, c, d, e};

            if (l.Count(x => x % 10 != 0) == 0)
            {
                Console.WriteLine(l.Sum());
            }
            else
            {
                var first = l.Where(x => x % 10 != 0)
                    .OrderBy(x => x % 10)
                    .First();

                var replaced = false;

                for (var i = 0; i < l.Count; i++)
                {
                    var v = l[i];

                    if (v % 10 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (v == first && !replaced)
                        {
                            replaced = true;
                        }
                        else
                        {
                            var i1 = v / 10;
                            var i2 = 10 * (i1 + 1);
                            l[i] = i2;
                        }
                    }
                }


                Console.WriteLine(l.Sum());
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