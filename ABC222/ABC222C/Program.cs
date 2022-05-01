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

namespace ABC222C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var a = Enumerable.Range(0, 2 * n)
                .Select(_ => ReadValue<string>().ToCharArray())
                .ToArray();

            // 各プレイヤー毎の勝ち数を保持しておく。(priorityQueue使ってkeyとvalue持っておいてもよさそう)
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < 2 * n; i++)
            {
                dictionary.Add(i, 0);
            }

            for (int i = 0; i < m; i++)
            {
                // 勝ち順でソートして順位を持っておく。
                var players = dictionary.OrderByDescending(x => x.Value).ToArray();

                for (int j = 0; j < n; j++)
                {
                    // そのままじゃんけんしてシミュレーション
                    var p1Key = players[j * 2].Key;
                    var p2Key = players[j * 2 + 1].Key;
                    var l = a[p1Key][i];
                    var r = a[p2Key][i];

                    var win = Janken(l, r);
                    if (win == 1)
                    {
                        dictionary[p1Key] = dictionary[p1Key] + 1;
                    }
                    else if (win == 2)
                    {
                        dictionary[p2Key] = dictionary[p2Key] + 1;
                    }
                }
            }

            var keyValuePairs = dictionary.OrderByDescending(x => x.Value).ToList();
            foreach (var keyValuePair in keyValuePairs)
            {
                Console.WriteLine(keyValuePair.Key+1);
            }
        }

        public static int Janken(char c1, char c2)
        {
            if (c1 == c2)
            {
                return -1;
            }

            if (c1 == 'G')
            {
                if (c2 == 'C')
                {
                    return 1;
                }
                else if (c2 == 'P')
                {
                    return 2;
                }
            }

            if (c1 == 'C')
            {
                if (c2 == 'P')
                {
                    return 1;
                }
                else if (c2 == 'G')
                {
                    return 2;
                }
            }

            if (c1 == 'P')
            {
                if (c2 == 'G')
                {
                    return 1;
                }
                else if (c2 == 'C')
                {
                    return 2;
                }
            }

            return -1;
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