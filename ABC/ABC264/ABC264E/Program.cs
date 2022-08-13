using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC264E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m, e) = ReadValue<int, int, int>();

            (int u, int v)[] uvList = Enumerable.Range(0, e)
                .Select(_ => ReadValue<int, int>())
                .Select(x => (x.Item1 - 1, x.Item2 - 1))
                .ToArray();

            var q = ReadValue<int>();
            var queryList = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int>())
                .Select(x => x - 1)
                .ToArray();


            // 発電所は全部同じ塊としてみなせばOK。
            uvList = uvList.Select(x =>
            {
                if (x.u >= n)
                {
                    x.u = n;
                }

                if (x.v >= n)
                {
                    x.v = n;
                }
                return x;
            }).ToArray();
            

            var revQuery = queryList.Reverse().ToList();
            var ansList = new List<int>();

            var queryHashset = queryList.ToHashSet();

            var uf = new UnionFind(n + 1);

            // queryに出てこなかった辺を探して、最初からUnionFindで繋いでおく
            var willNotCutted = uvList.Select((x, i) => (x, i))
                .Where(item => !queryHashset.Contains(item.i))
                .ToList();

            // 送電できるかどうかの情報を持っておく。
            var enableHashSet = new HashSet<int>();

            // var enable = new bool[n + m];
            // for (int i = n; i < n + m; i++)
            // {
            //     enable[i] = true;
            //     enableHashSet.Add(i);
            // }

            foreach (var (item1, item2) in willNotCutted)
            {
                uf.TryUnite(item1.u, item1.v);
                
                // if (enable[item1.u] == true)
                // {
                //     enableHashSet.Add(item1.u);
                // }
                //
                // if (enable[item1.v] == true)
                // {
                //     enableHashSet.Add(item1.v);
                // }
                //
                // if (enable[item1.u] == true && enable[item1.v] == false)
                // {
                //     enable[item1.u] = true;
                //     enable[item1.v] = true;
                //
                //     enableHashSet.Add(item1.u);
                //     enableHashSet.Add(item1.v);
                //
                //     continue;
                // }
                //
                // if (enable[item1.u] == false && enable[item1.v] == true)
                // {
                //     enable[item1.u] = true;
                //     enable[item1.v] = true;
                //
                //     enableHashSet.Add(item1.u);
                //     enableHashSet.Add(item1.v);
                //
                //     continue;
                // }
            }
            
            // var sumTmp = 0;
            // for (int j = n; j < n + m; j++)
            // {
            //     sumTmp += uf.GetSize(j);
            // }
            
            ansList.Add(uf.GetSize(n) - 1);

            

            foreach (var i in revQuery)
            {
                var valueTuple = uvList[i];

                var beforeU = uf.GetSize(valueTuple.u);
                var beforeUParent = uf.FindRoot(valueTuple.u);
                
                    
                var beforeV = uf.GetSize(valueTuple.v);
                var beforeVParent = uf.FindRoot(valueTuple.v);
                
                uf.TryUnite(valueTuple.u, valueTuple.v, out var parent);

                // var afterSize = uf.GetSize(parent);
                // if (enable[beforeUParent] == true && enable[beforeVParent] == false)
                // {
                //     enable[valueTuple.u] = true;
                //     enable[valueTuple.v] = true;
                //
                //     enableHashSet.Add(valueTuple.u);
                //     enableHashSet.Add(valueTuple.v);
                //
                //     enableHashSet.Add(beforeUParent);
                //     enableHashSet.Add(beforeVParent);
                //
                //     // uの方はもともとOKだったので、Vの個数を足す
                //     // ansList.Add(ansList.Last() + beforeV);
                //     
                // }
                // else if (enable[beforeUParent] == false && enable[beforeVParent] == true)
                // {
                //     enable[valueTuple.u] = true;
                //     enable[valueTuple.v] = true;
                //
                //     enableHashSet.Add(valueTuple.u);
                //     enableHashSet.Add(valueTuple.v);
                //     
                //     enableHashSet.Add(beforeUParent);
                //     enableHashSet.Add(beforeVParent);
                //
                //     // vの方はもともとOKだったので、uの個数を足す。uはダメだったので、発電所の数は考慮しなくて良いはず。
                //     // ansList.Add(ansList.Last() + beforeU);
                //
                // }
                // else
                // {
                //     ansList.Add(ansList.Last());
                // }
                
                


                // var sum = 0;
                // for (int j = n; j < n + m; j++)
                // {
                //     sum += uf.GetSize(j);
                // }
                
                ansList.Add(uf.GetSize(n) - 1);
                
                
                
            }

            ansList.Reverse();
            ansList.RemoveAt(0);
            
            foreach (var i in ansList)
            {
                Console.WriteLine(i);
            }
        }


        public class UnionFind
        {
            private int Size { get; set; }
            public int GroupCount { get; set; }

            private int[] Parent;
            private int[] Sizes;

            /// <summary>
            /// n要素のUnionFind-Treeを生成する
            /// </summary>
            /// <param name="count"></param>
            public UnionFind(int count)
            {
                Size = count;
                GroupCount = count;

                Parent = new int[count];
                Sizes = new int[count];

                for (int i = 0; i < count; i++)
                {
                    Parent[i] = i;
                    Sizes[i] = 1;
                }
            }

            public bool TryUnite(int x, int y)
            {
                return TryUnite(x, y, out var p);
            }

            /// <summary>
            /// xとyの属している木を合併する。<br/>
            /// xとyがすでに同じ木にある場合、falseを返す。
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="parent"> xとyの合併後のroot </param>
            /// <returns></returns>
            public bool TryUnite(int x, int y, out int parent)
            {
                //       ans += map.TryGetValue(cum[r] - k, out var val) ? val : 0;

                var xp = FindRoot(x);
                var yp = FindRoot(y);
                // rootが同じであれば、すでにUnite済なのでエラー。
                if (xp == yp)
                {
                    parent = xp;
                    return false;
                }

                if (Sizes[xp] < Sizes[yp])
                {
                    (yp, xp) = (xp, yp);
                }

                GroupCount--;

                Parent[yp] = xp;
                Sizes[xp] += Sizes[yp];

                parent = xp;
                return true;
            }

            /// <summary>
            /// xのrootを返す
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int FindRoot(int x)
            {
                // if (x == Parent[x]) return x;
                // return FindRoot(Parent[x]);

                // 再帰しないので速そう
                while (x != Parent[x])
                {
                    x = (Parent[x] = Parent[Parent[x]]);
                }

                return x;
            }

            /// <summary>
            /// rootになっているノードをすべて返す
            /// </summary>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IEnumerable<int> AllRepresents()
            {
                return Parent.Where((x, y) => x == y);
            }

            /// <summary>
            /// xが属している木のサイズを返す
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetSize(int x)
            {
                return Sizes[FindRoot(x)];
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