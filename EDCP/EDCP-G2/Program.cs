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

namespace EDCP_G2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            (int x, int y)[] xyList = Enumerable.Range(0, m).Select(_ => ReadValue<int, int>()).ToArray();

            var dp = new int[n + 1];

            // x -> y
            // 若い順にトポロジカルソートする。

            // 向き先グラフ
            var dic = xyList.GroupBy(x => x.x)
                .ToDictionary(x => x.Key, x => x.Select(item => item.y).ToArray());

            for (int i = 1; i <= n; i++)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, new int[0]);
                }
            }
            
            // var (topologicalSortRes, isAcyclic) = TopologicalSort.Sort(n, xyList.ToList());
            var (topologicalSortRes, isAcyclic) = TopologicalSort.Sort(dic);

            //  「G は有向閉路を含みません」なので気にせず実施してOK。
            // Console.WriteLine(topologicalSortRes);

            // トポロジカルソート結果をdp
            for (var i = 0; i < topologicalSortRes.Count; i++)
            {
                var f = topologicalSortRes[i];
                var v = dp[f];

                if (dic.ContainsKey(f))
                {
                    foreach (var i1 in dic[f])
                    {
                        dp[i1] = Math.Max(dp[i1], v + 1);
                    }
                }
            }

            Console.WriteLine(dp.Max());
        }

        public class TopologicalSort
        {
            /// <summary>
            /// PriorityQueueを使用してトポロジカルソートを実行します。
            /// </summary>
            /// <param name="input">x : from, y: to</param>
            /// <returns></returns>
            public static (List<int> sortres, bool isAcyclic) Sort(int count, List<(int from, int to)> xyList)
            {
                // 向き先グラフ
                var dic = xyList.GroupBy(x => x.from)
                    .ToDictionary(x => x.Key, x => x.Select(item => item.to).ToArray());

                for (int i = 1; i <= count; i++)
                {
                    if (!dic.ContainsKey(i))
                    {
                        dic.Add(i, new int[0]);
                    }
                }

                return Sort(dic);
            }

            public static (List<int> sortres, bool isAcyclic) Sort(Dictionary<int, int[]> dic)
            {
                var count = dic.Count;
                // INの個数
                var counts = new int[count + 1];

                foreach (var (k, values) in dic)
                {
                    foreach (var value in values)
                    {
                        counts[value] += 1;
                    }
                }

                // foreach (var (_, y) in xyList)
                // {
                //     counts[y] += 1;
                // }

                var pq = new PriorityQueue<int>();
                // inが無いものから順番に処理。
                for (var i = 1; i < counts.Length; i++)
                {
                    if (counts[i] == 0)
                    {
                        pq.Enqueue(i, i);
                    }
                }

                var topologicalSortRes = new List<int>();
                while (pq.Count > 0)
                {
                    var (k, v) = pq.Dequeue();
                    topologicalSortRes.Add(v);

                    if (dic.ContainsKey(v))
                    {
                        foreach (var dest in dic[v])
                        {
                            counts[dest] -= 1;
                            if (counts[dest] <= 0)
                            {
                                pq.Enqueue(dest, dest);
                            }
                        }
                    }
                }

                // topologicalソートした結果の配列の長さがおかしければDAGではない。
                return (topologicalSortRes, topologicalSortRes.Count == count);
            }
        }

        /// <summary>
        /// PriorityQueueは .Net6で使えるが、AtCoder環境ではつかえないので、、、
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T>
        {
            /// <summary>
            /// 空の優先度付きキューを生成します。
            /// </summary>
            public PriorityQueue()
            {
                _keys = new List<long>();
                _elements = new List<T>();
            }

            List<long> _keys;
            List<T> _elements;

            /// <summary>
            /// 優先度付きキューに要素を追加します。
            /// 計算量は O(log(要素数)) です。
            /// </summary>
            public void Enqueue(long key, T elem)
            {
                var n = _elements.Count;
                _keys.Add(key);
                _elements.Add(elem);
                while (n != 0)
                {
                    var i = (n - 1) / 2;
                    if (_keys[n] < _keys[i])
                    {
                        (_keys[n], _keys[i]) = (_keys[i], _keys[n]);
                        (_elements[n], _elements[i]) = (_elements[i], _elements[n]);
                    }

                    n = i;
                }
            }

            /// <summary>
            /// 頂点要素を返し、削除します。
            /// 計算量は O(log(要素数)) です。
            /// </summary>
            public (long, T) Dequeue()
            {
                var t = Peek;
                Pop();
                return t;
            }

            void Pop()
            {
                var n = _elements.Count - 1;
                _elements[0] = _elements[n];
                _elements.RemoveAt(n);
                _keys[0] = _keys[n];
                _keys.RemoveAt(n);
                for (int i = 0, j; (j = 2 * i + 1) < n;)
                {
                    //左の子と右の子で右の子の方が優先度が高いなら右の子を処理したい
                    if ((j != n - 1) && _keys[j] > _keys[j + 1]) j++;
                    //親より子が優先度が高いなら親子を入れ替える
                    if (_keys[i] > _keys[j])
                    {
                        (_keys[i], _keys[j]) = (_keys[j], _keys[i]);
                        (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
                    }

                    i = j;
                }
            }


            /// <summary>
            /// 頂点要素を返します。
            /// 計算量は O(1) です。
            /// </summary>
            public (long key, T value) Peek => (_keys[0], _elements[0]);

            /// <summary>
            /// 優先度付きキューに格納されている要素の数を返します。
            /// 計算量は O(1) です。
            /// </summary>
            public int Count => _elements.Count;
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