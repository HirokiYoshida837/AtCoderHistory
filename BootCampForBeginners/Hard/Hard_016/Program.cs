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

namespace Hard_016
{
    /// <summary>
    /// [D - Line++](https://atcoder.jp/contests/abc160/tasks/abc160_d)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, x, y) = ReadValue<int, int, int>();

            // 両方向のグラフ
            var graph = Enumerable.Range(0, n).ToDictionary(x => x, _ => new List<int>());
            for (int i = 0; i < n - 1; i++)
            {
                graph[i].Add(i + 1);
                graph[i + 1].Add(i);
            }

            graph[x - 1].Add(y - 1);
            graph[y - 1].Add(x - 1);

            var ansMemo = Enumerable.Range(1, n - 1)
                .ToDictionary(x => x, _ => 0);

            // 幅優先探索を全部実施 
            for (int start = 0; start < n; start++)
            {
                var current = start;
                var currentStep = 1;

                // startから開始してgoalまでの手番を数える
                var visitHistory = new Dictionary<int, int>();

                var next = new List<int>();

                if (!graph.ContainsKey(current))
                {
                    continue;
                }

                next.AddRange(graph[current]);

                while (next.Count > 0)
                {
                    var nextTurnList = new List<int>();
                    foreach (var i in next)
                    {
                        if (!visitHistory.ContainsKey(i))
                        {
                            visitHistory.Add(i, currentStep);
                            if (graph.ContainsKey(i) && graph[i].Count > 0)
                            {
                                nextTurnList.AddRange(graph[i]);
                            }
                        }
                    }

                    currentStep++;
                    next = nextTurnList;
                }


                foreach (var keyValuePair in visitHistory)
                {
                    if (keyValuePair.Key > start)
                    {
                        ansMemo[keyValuePair.Value] += 1;
                    }
                }
            }


            foreach (var keyValuePair in ansMemo.OrderBy(x => x.Key))
            {
                Console.WriteLine(keyValuePair.Value);
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