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

namespace ABC269D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            (int x, int y)[] xyList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var direction = new (int dx, int dy)[]
            {
                (-1, -1),
                (-1, 0),
                (0, -1),
                (0, +1),
                (1, 0),
                (1, 1)
            };

            var ind = 0;
            var dictionary = new Dictionary<(int, int), int>();
            // 必要になる分だけ座標計算する
            foreach (var (x, y) in xyList)
            {
                if (!dictionary.ContainsKey((x, y)))
                {
                    dictionary.Add((x, y), ind);
                    ind++;
                }

                foreach (var (dx, dy) in direction)
                {
                    if (!dictionary.ContainsKey((x + dx, y + dy)))
                    {
                        dictionary.Add((x + dx, y + dy), ind);
                        ind++;
                    }
                }
            }


            // var dictionary = l.Select((x, i) => (x, i)).ToDictionary(x => x.x, x => x.i);


            var uf = new UnionFind(dictionary.Count + 10);
            var painted = new HashSet<int>();


            foreach (var current in xyList)
            {
                var currentIndex = dictionary[current];
                painted.Add(currentIndex);

                foreach (var (dx, dy) in direction)
                {
                    var target = dictionary[(current.x + dx, current.y + dy)];

                    if (painted.Contains(target))
                    {
                        var tryUnite = uf.TryUnite(currentIndex, target);

                        // if (tryUnite.Item1)
                        // {
                        //     parentMemo.Add(tryUnite.Item2);
                        // }
                    }
                }
            }


            var ansList = new HashSet<int>();
            foreach (var current in xyList)
            {
                var i = dictionary[current];

                var findRoot = uf.FindRoot(i);
                ansList.Add(findRoot);
            }

            Console.WriteLine(ansList.Count);
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

            // public bool TryUnite(int x, int y)
            // {
            //     return TryUnite(x, y, out var p);
            // }

            /// <summary>
            /// xとyの属している木を合併する。<br/>
            /// xとyがすでに同じ木にある場合、falseを返す。
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="parent"> xとyの合併後のroot </param>
            /// <returns></returns>
            public (bool, int) TryUnite(int x, int y)
            {
                //       ans += map.TryGetValue(cum[r] - k, out var val) ? val : 0;

                var xp = FindRoot(x);
                var yp = FindRoot(y);
                // rootが同じであれば、すでにUnite済なのでエラー。
                if (xp == yp)
                {
                    return (false, xp);
                }

                if (Sizes[xp] < Sizes[yp])
                {
                    (yp, xp) = (xp, yp);
                }

                GroupCount--;

                Parent[yp] = xp;
                Sizes[xp] += Sizes[yp];

                return (true, xp);
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