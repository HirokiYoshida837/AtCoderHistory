using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ABCUtils.UnionFindTree
{
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