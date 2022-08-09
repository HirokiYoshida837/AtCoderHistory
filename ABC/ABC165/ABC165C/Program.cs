using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Math;

namespace ABC165C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m, q) = ReadValue<int, int, int>();

            (int a, int b, int c, int d)[] readList = Enumerable.Range(0, q)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray())
                .Select(x => (x[0], x[1], x[2], x[3]))
                .ToArray();

            // 全ケースシミュレーションしろって言ってるように見える。
            var dic = new List<string>();

            // DFSでデータ準備する。(bit全探索だと、重複数字を処理できないので。)
            void recursive(int current, List<int> history)
            {
                if (history.Count() == n)
                {
                    var join = String.Join(' ', history);
                    dic.Add(join);
                    return;
                }

                // 重複項目アリ
                for (int i = current; i <= m; i++)
                {
                    history.Add(i);
                    if (history.Count() <= n)
                    {
                        recursive(i, history);
                    }

                    history.RemoveAt(history.Count() - 1);
                }
            }
            recursive(1, new List<int>());

            var max = 0L;

            foreach (var As in dic)
            {
                var A = As.Split().Select(int.Parse).ToArray();
                var score = 0L;
                foreach (var (a, b, c, d) in readList)
                {
                    if (A[b - 1] - A[a - 1] == c)
                    {
                        score += d;
                    }
                }

                max = Math.Max(max, score);
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


        public static (T1, T2, T3, T4) ReadValue<T1, T2, T3, T4>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2)),
                (T3) Convert.ChangeType(input[2], typeof(T3)),
                (T4) Convert.ChangeType(input[3], typeof(T4))
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