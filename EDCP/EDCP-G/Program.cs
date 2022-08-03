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

namespace EDCP_G
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            (int x, int y)[] xyList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .Select(item => (item.Item1, item.Item2))
                .ToArray();

            // DAGを作って、DFS(メモ化再起) で解く。
            
            // 有向グラフ作成
            var to = Enumerable.Range(1, n)
                .ToDictionary(x => x, x => new HashSet<int>());

            foreach (var (x, y) in xyList)
            {
                to[x].Add(y);
            }

            // DFS、どの頂点からはじめようが、計算結果は使い回せるはず。
            // 訪問済をtrueに
            var visited = new bool[n + 10];
            var calculated = new bool[n + 10];

            // maxLength of path from v;
            var dp = new int[n + 10];
            for (var j = 0; j < dp.Length; j++)
            {
                dp[j] = -1;
            }

            int DFS(int v)
            {
                // doing DFS; 
                if (visited[v])
                {
                    if (!calculated[v])
                    {
                        return -1;
                    }

                    return dp[v];
                }

                visited[v] = true;
                // 初期化
                dp[v] = 1;

                // すべての辺を探索
                foreach (var u in to[v])
                {
                    var dfs = DFS(u);
                    if (dfs == -1)
                    {
                        // ループ検出
                        return -1;
                    }

                    dp[v] = Math.Max(dp[v], dfs + 1);
                }

                calculated[v] = true;
                return dp[v];
            }

            var ans = 0L;
            // それぞれの頂点からスタートするケースを全部考える。
            // 各値は使い回せるはず。
            for (int i = 1; i <= n; i++)
            {
                var dfs = DFS(i);
                if (dfs == -1)
                {
                    Console.WriteLine(-1);
                    return;
                }

                ans = Math.Max(ans, dfs);
            }

            // ans は頂点の数なので、辺の数にする
            Console.WriteLine(ans - 1);
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