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

namespace Hard_9
{
    /// <summary>
    /// [B - Template Matching](https://atcoder.jp/contests/abc054/tasks/abc054_b)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            var aMatrix = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();

            var bMatrix = Enumerable.Range(0, m)
                .Select(_ => ReadValue<string>())
                .ToArray();

            var bstr = String.Join(',', bMatrix);


            for (int i = 0; i < n - m + 1; i++)
            {
                var subA = aMatrix.Select(x => x.Substring(i, m))
                    .ToArray();

                for (int j = 0; j < n - m + 1; j++)
                {
                    var strings = subA.Skip(j).Take(m).ToArray();
                    var astr = String.Join(',', strings);

                    if (astr == bstr)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }

            Console.WriteLine("No");
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