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

namespace Hard_029
{
    /// <summary>
    /// [B - Colorful Creatures](https://atcoder.jp/contests/agc011/tasks/agc011_b)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().OrderBy(x => x).ToList();


            var cum = new List<long>() {0};
            foreach (var l in aList)
            {
                cum.Add(cum.Last() + l);
            }
            cum.RemoveAt(0);

            // ダブリングで解く。
            // 2^i回移動した先をdpテーブルで持つ

            var dp = new int[33][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n];
            }

            // 2^0
            for (var i = 0; i < aList.Count; i++)
            {
                var a = aList[i];
                var c = cum[i];

                // 自分より2倍大きいところまで移動できる。LowerBoundで取るので 2*c + 1 で二分探索。
                var lb = BinarySearch.getLowerBound(aList, c * 2 + 1);
                dp[0][i] = lb - 1;
            }
            
            
            for (var i = 1; i < dp.Length; i++)
            {
                for (var x = 0; x < dp[i].Length; x++)
                {
                    dp[i][x] = dp[i - 1][dp[i - 1][x]];
                }
            }

            var count = dp.Last().Count(x=>x==n-1);
            Console.WriteLine(count);
        }

        public class BinarySearch
        {
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

            /// <summary>
            /// 指定した値より大きい先頭のインデクスを返す (二分探索)
            /// 2017/08/04 Fantom
            /// http://fantom1x.blog130.fc2.com//blog-entry-256.html
            /// </summary>
            /// <typeparam name="T">比較する値の型</typeparam>
            /// <param name="arr">対象の配列（※ソート済みであること）</param>
            /// <param name="start">開始インデクス [inclusive]</param>
            /// <param name="end">終了インデクス [exclusive]</param>
            /// <param name="value">検索する値</param>
            /// <param name="comparer">比較関数(インターフェイス)</param>
            /// <returns>指定した値より大きい先頭のインデクス</returns>
            public static int getUpperBound<T>(IReadOnlyList<T> arr, int start, int end, T value, IComparer<T> comparer)
            {
                int low = start;
                int high = end;
                int mid;
                while (low < high)
                {
                    mid = ((high - low) >> 1) + low;
                    if (comparer.Compare(arr[mid], value) <= 0)
                        low = mid + 1;
                    else
                        high = mid;
                }

                return low;
            }

            public static int getUpperBound<T>(IReadOnlyList<T> arr, T value)
            {
                return getUpperBound(arr, 0, arr.Count, value, Comparer<T>.Default);
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