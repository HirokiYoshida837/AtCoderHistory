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

namespace ABC262B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            (int u, int v)[] uvList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // 無向グラフなのでとりあえず行列で管理。
            var graph = new bool[n, n];

            foreach (var (u, v) in uvList)
            {
                graph[u - 1, v - 1] = true;
                graph[v - 1, u - 1] = true;
            }

            // BFSすれば巡回かどうかを確認できそうだけど面倒。
            var count = 0L;
            for (int a = 0; a < n; a++)
            {
                for (int b = a+1; b < n; b++)
                {
                    for (int c = b+1; c < n; c++)
                    {
                        // 三角形 abcが作れるかどうか = a-b , b-c, c-a が全部trueかどうか

                        var b1 = graph[a, b];
                        var b2 = graph[b, c];
                        var b3 = graph[c, a];

                        if (b1 && b2 && b3)
                        {
                            // Console.WriteLine($"{a}, {b}, {c}");
                            count++;
                        }
                    }
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