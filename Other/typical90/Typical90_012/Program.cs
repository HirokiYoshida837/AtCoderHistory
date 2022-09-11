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

namespace Typical90_012
{
    /// <summary>
    /// [012 - Red Painting（★4）](https://atcoder.jp/contests/typical90/tasks/typical90_l)
    /// https://twitter.com/e869120/status/1381376542836596737
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var q = ReadValue<int>();

            (int type, int ra, int ca, int rb, int cb)[] queries = Enumerable.Range(0, q)
                .Select(_ =>
                {
                    var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

                    if (array[0] == 1)
                    {
                        return (1, array[1] - 1, array[2] - 1, -1, -1);
                    }
                    else
                    {
                        return (2, array[1] - 1, array[2] - 1, array[3] - 1, array[4] - 1);
                    }
                }).ToArray();


            var painted = new HashSet<(int, int)>();
            var uf = new UnionFind(h * w + 10);

            int calcPos(int r, int c)
            {
                return w * r + c;
            }


            foreach (var valueTuple in queries)
            {
                if (valueTuple.type == 1)
                {
                    if (!painted.Contains((valueTuple.ra, valueTuple.ca)))
                    {
                        painted.Add((valueTuple.ra, valueTuple.ca));

                        // 上下左右と unionFindでuniteする
                        var cur = calcPos(valueTuple.ra, valueTuple.ca);

                        if (painted.Contains((valueTuple.ra - 1, valueTuple.ca)))
                        {
                            var pos = calcPos(valueTuple.ra - 1, valueTuple.ca);
                            uf.TryUnite(pos, cur);
                        }

                        if (painted.Contains((valueTuple.ra + 1, valueTuple.ca)))
                        {
                            var pos = calcPos(valueTuple.ra + 1, valueTuple.ca);
                            uf.TryUnite(pos, cur);
                        }

                        if (painted.Contains((valueTuple.ra, valueTuple.ca - 1)))
                        {
                            var pos = calcPos(valueTuple.ra, valueTuple.ca - 1);
                            uf.TryUnite(pos, cur);
                        }

                        if (painted.Contains((valueTuple.ra, valueTuple.ca + 1)))
                        {
                            var pos = calcPos(valueTuple.ra, valueTuple.ca + 1);
                            uf.TryUnite(pos, cur);
                        }
                    }
                }
                else
                {
                    var a = (valueTuple.ra, valueTuple.ca);
                    var b = (valueTuple.rb, valueTuple.cb);

                    if (painted.Contains(a) && painted.Contains(b))
                    {
                        var findRootA = uf.FindRoot(calcPos(a.ra, a.ca));
                        var findRootB = uf.FindRoot(calcPos(b.rb, b.cb));

                        if (findRootA == findRootB)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
            }
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