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

namespace Typical90_007
{
    /// <summary>
    /// [007 - CP Classes（★3）](https://atcoder.jp/contests/typical90/tasks/typical90_g)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().Distinct().OrderBy(x => x).ToList();

            var aSet = aList.ToHashSet();

            aList.Insert(0, long.MinValue / 2);
            aList.Add(long.MaxValue / 2);

            var q = ReadValue<int>();
            var queries = Enumerable.Range(0, q)
                .Select(_ => ReadValue<long>())
                .ToList();


            foreach (var b in queries)
            {
                if (aSet.Contains(b))
                {
                    Console.WriteLine(0);
                    continue;
                }

                var lowerBound = BinarySearch.getLowerBound(aList, b);
                var upperBound = BinarySearch.getUpperBound(aList, b);

                var l = aList[lowerBound];
                var u = aList[upperBound - 1];

                Console.WriteLine(Math.Min(Math.Abs(l - b), Math.Abs(u - b)));
            }
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