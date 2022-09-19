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

namespace Hard_027
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, q) = ReadValue<int, int>();

            var abList = Enumerable.Range(0, n-1)
                .Select(_ => ReadValue<int, int>())
                .Select(x => (x.Item1 - 1, x.Item2 - 1))
                .ToArray();
            var pxList = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int, long>())
                .Select(x => (x.Item1 - 1, x.Item2))
                .ToArray();

            var pDic = pxList.GroupBy(x => x.Item1)
                .ToDictionary(x => x.Key, x => x.Select(x => x.Item2).Sum());

            var graph = Enumerable.Range(0, n)
                .ToDictionary(x => x, x => new HashSet<int>());

            foreach (var (u, v) in abList)
            {
                graph[u].Add(v);
                graph[v].Add(u);
            }

            // DFSしながら足していく
            var ansList = new long[n + 1];

            void DFS(int current, int parent)
            {
                if (parent != -1)
                {
                    ansList[current] += ansList[parent];
                }

                if (pDic.ContainsKey(current))
                {
                    ansList[current] += pDic[current];
                }


                foreach (var i in graph[current])
                {
                    if (i == parent) continue;
                    DFS(i, current);
                }
            }

            DFS(0, -1);

            var sb = new StringBuilder();
            foreach (var l in ansList.Take(n))
            {
                sb.Append(l);
                sb.Append(" ");
            }

            Console.WriteLine(sb.ToString());
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