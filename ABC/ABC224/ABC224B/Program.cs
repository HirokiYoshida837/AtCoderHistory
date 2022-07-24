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

namespace ABC224B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var a = Enumerable.Range(0, h)
                .Select(_ => ReadList<int>().ToArray())
                .ToArray();

            var ans = true;

            for (int i1 = 0; i1 < h - 1; i1++)
            {
                for (int j1 = 0; j1 < w - 1; j1++)
                {
                    for (int i2 = i1 + 1; i2 < h; i2++)
                    {
                        for (int j2 = j1 + 1; j2 < w; j2++)
                        {
                            if (!(a[i1][j1] + a[i2][j2] <= a[i2][j1] + a[i1][j2]))
                            {
                                // Console.WriteLine($"{i1} {j1} {i2} {j2}");
                                // Console.WriteLine($"{a[i1][j1]} {a[i2][j2]} {a[i2][j1]} {a[i1][j2]}");
                                ans = false;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(ans ? "Yes" : "No");
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