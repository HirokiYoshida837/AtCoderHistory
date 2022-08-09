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

namespace ABC165C2
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

            // 1～M までの数字から、 N個を取得する。重複アリでもOK、昇順
            for (int bit = 0; bit < 1 << m + n; bit++)
            {
                var bitS = Convert.ToString(bit, 2).PadLeft(m + n, '0');

                if (bitS.Count(x => x == '0') != n)
                {
                    continue;
                }

                var seq = new List<int>();
                for (var i = 0; i < bitS.Length; i++)
                {
                    if (bitS[i] == '0')
                    {
                        seq.Add((i + 1) - seq.Count);
                    }
                }

                // Console.WriteLine(String.Join(' ', seq));
                dic.Add(String.Join(' ', seq));
            }


            var max = 0L;
            foreach (var As in dic)
            {
                var A = As.Split().Select(int.Parse).ToArray();

                if (A.Count(x => x > m) > 0)
                {
                    continue;
                }

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