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

namespace ABC269D2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var xyList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var dictionary = xyList.Select((item, index) => (item, index)).ToDictionary(x => x.item, x => x.index);

            var dir = new (int dx, int dy)[]
            {
                (-1, -1), (-1, 0), (0, -1), (0, +1), (1, 0), (1, 1)
            };

            var uf = new UnionFind(n + 10);

            foreach (var kv in dictionary)
            {
                var (x, y) = kv.Key;

                foreach (var (dx, dy) in dir)
                {
                    var t = (x + dx, y + dy);
                    if (dictionary.ContainsKey(t))
                    {
                        var ti = dictionary[t];
                        uf.TryUnite(kv.Value, ti);
                    }
                }
            }


            var ansSet = new HashSet<int>();
            foreach (var kv in dictionary)
            {
                var findRoot = uf.FindRoot(kv.Value);
                ansSet.Add(findRoot);
            }

            Console.WriteLine(ansSet.Count);
        }

        public class UnionFind
        {
            private int Size { get; set; }
            private int GroupCount { get; set; }

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