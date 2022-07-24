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

namespace ABC256D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var lrList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .OrderBy(x=>x.Item1)
                .ToArray();
            
            var startList = lrList.Select(x => x.Item1).ToHashSet();
            // スタートと、Endを全部まとめ直す

            var compList = new Dictionary<int, int>();
            
            foreach (var i in startList)
            {
                compList.Add(i,-1);
            }
            
            foreach (var valueTuple in lrList)
            {
                compList[valueTuple.Item1] = Math.Max(compList[valueTuple.Item1], valueTuple.Item2);
            }

            var cl = compList
                .Select(x=> (x.Key, x.Value))
                .OrderBy(x=>x.Key)
                .ToList();

            // 座標圧縮
            var array = cl.Select(x=>new List<int>{x.Item1, x.Item2})
                .SelectMany(x=>x)
                .ToArray();
            var zipped = array.Distinct()
                .OrderBy(x=>x)
                .Select((x, i)=>(x,i))
                .ToDictionary(x=>x.x, x=>x.i);

            var revZipped = zipped.ToDictionary(x => x.Value, x => x.Key);
            
            // unionFindの右端
            var max = zipped.Count();

            var unionFindTree = new UnionFind(max);
            
            foreach (var (l,r) in cl)
            {
                // l,r を座標圧縮したあとのものに変更
                var zl = zipped[l];
                var zr = zipped[r];
                
                for (int i = zl; i <= zr; i++)
                {
                    unionFindTree.TryUnite(zl, i);
                }
            }


            var hashSet = startList.Select(x=>zipped[x])
                .Select(x=>unionFindTree.FindRoot(x))
                .Select(x=>(x, unionFindTree.GetSize(x)))
                .ToHashSet();

            foreach (var (zl, zlength) in hashSet)
            {
                var l = revZipped[zl];
                var r = revZipped[zl + zlength-1];

                Console.WriteLine($"{l} {r}");
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
    }
}