﻿using System;
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

namespace ABC213D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (int a, int b)[] abList = Enumerable.Range(0, n - 1)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var map = new Dictionary<int, List<int>>();
            var visited = new bool[n + 1];
            var history = new List<int>();

            // mapを作る
            foreach (var (a, b) in abList)
            {
                if (map.ContainsKey(a))
                {
                    map[a].Add(b);
                }
                else
                {
                    map[a] = new List<int>() {b};
                }

                if (map.ContainsKey(b))
                {
                    map[b].Add(a);
                }
                else
                {
                    map[b] = new List<int>() {a};
                }
            }

            dfs(1);

            var join = String.Join(" ", history);
            Console.WriteLine(join);


            void dfs(int current)
            {
                history.Add(current);
                visited[current] = true;
                var nextList = map[current].OrderBy(x => x);

                foreach (var i in nextList)
                {
                    if (!visited[i])
                    {
                        dfs(i);
                        history.Add(current);
                    }
                    else
                    {
                        continue;
                    }
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