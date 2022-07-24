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

namespace ABC217D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // solve1();

            solve2();
        }

        /// <summary>
        /// 平衡二分木で解く方法
        /// </summary>
        public static void solve1()
        {
            var (l, q) = ReadValue<int, int>();

            (int c, int x)[] queries = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // 平衡二分木のnodeの左側と右側とみるようなかたち。
            var cut = new SortedSet<int>() {0, l};
            foreach (var (c, x) in queries)
            {
                if (c == 1)
                {
                    cut.Add(x);
                }
                else
                {
                    var right = cut.GetViewBetween(x, l);
                    var left = cut.GetViewBetween(0, x);

                    var btw = right.Min - left.Max;

                    Console.WriteLine(btw);
                }
            }
        }

        /// <summary>
        /// union-findで解く方法
        /// </summary>
        public static void solve2()
        {
            var (l, q) = ReadValue<int, int>();

            (int c, int x)[] queries = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // 切断箇所だけを抜き出し
            var list = queries.Where(item => item.c == 1)
                .Select(item => item.x)
                .OrderBy(x => x)
                .ToList();
            list.Insert(0, 0);

            // 座標圧縮
            var zipped = list.Select((x, i) => new KeyValuePair<int, int>(x, i)).ToDictionary(x => x.Key, x => x.Value);

            // 各区間の長さを調べておく
            var lens = new List<int>();
            lens.Add(0);
            foreach (var i in list)
            {
                lens.Add(i-lens[^1]);
            }
            
            lens.Add(l - lens[^1]);
            lens.RemoveRange(0,2);

            var unionFind = new UnionFind(list.Count);
            var ansList = new List<int>();
            foreach (var (c, x) in queries.Reverse())
            {
                if (c == 1)
                {
                    var z = zipped[x];
                    var left = z - 1;
                    var right = z;

                    unionFind.TryUnite(left, right, out var p);

                    // 長さ更新
                    var lLen = lens[left];
                    var rLen = lens[right];
                    lens[left] = lLen + rLen;
                    lens[right] = lLen + rLen;
                }
                else
                {
                    var binarySearch = list.BinarySearch(x);
                    if (binarySearch < 0) binarySearch = ~binarySearch;

                    var zp = binarySearch;
                    var z = zp - 1;

                    var len = lens[z];
                    ansList.Add(len);
                }
            }

            ansList.Reverse();
            foreach (var i in ansList)
            {
                Console.WriteLine(i);
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
        
        
        /// <summary>
        /// 属しているものを全部返す
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<int> GetGroups(int p)
        {
            return Parent.Where(x => x == p);
        }
    }
}