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

namespace ABC231C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nq = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, q) = (nq[0], nq[1]);

            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            var xList = Enumerable.Range(0, q)
                .Select(_ => Console.ReadLine())
                .Select(int.Parse)
                .ToList();

            // a.Add(int.MaxValue);
            a = a.OrderBy(x => x).ToList();

            foreach (var x in xList)
            {
                int idx = getLowerBound(a, x);

                Console.WriteLine(n-idx);
            }
        }
        
        /// <summary>
        /// 指定した値以上の先頭のインデクスを返す
        /// </summary>
        /// <typeparam name="T">比較する値の型</typeparam>
        /// <param name="arr">対象の配列（※ソート済みであること）</param>
        /// <param name="start">開始インデクス [inclusive]</param>
        /// <param name="end">終了インデクス [exclusive]</param>
        /// <param name="value">検索する値</param>
        /// <param name="comparer">比較関数(インターフェイス)</param>
        /// <returns>指定した値以上の先頭のインデクス</returns>
        public static int getLowerBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
        {
            int low = start;
            int high = end;
            int mid;
            while (low < high)
            {
                mid = ((high - low) >> 1) + low;
                if (comparer.Compare(arr[mid], value) < 0)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
        
        //引数省略のオーバーロード
        public static int getLowerBound<T>(IReadOnlyList<T> arr, T value) where T : IComparable
        {
            return getLowerBound(arr, 0, arr.Count, value, Comparer<T>.Default);
        }
    }
}