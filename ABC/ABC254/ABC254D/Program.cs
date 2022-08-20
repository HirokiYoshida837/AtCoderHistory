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

namespace ABC254D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();

            var set = new HashSet<(long, long)>();

            var ans = 0L;
            for (long i = 1; i <= n; i++)
            {
                // var center = i;
                // var right = Math.Min(i * i, n);
                //
                //
                // var l = new List<long>();
                //
                // for (long j = center; j <= right; j++)
                // {
                //     if (i * i % j == 0)
                //     {
                //         l.Add(j);
                //     }
                // }
                //
                // ans += (l.Count - 1) * 2 + 1;


                // var div1 = getDivisor(i).ToList();
                //
                // var divisorSet = new HashSet<long>();
                // for (var i1 = 0; i1 < div1.Count; i1++)
                // {
                //     for (var i2 = i1; i2 < div1.Count; i2++)
                //     {
                //         divisorSet.Add(div1[i1] * div1[i2]);
                //     }
                // }
                // var divisor = divisorSet.OrderBy(x => x).ToList();
                //
                // var center = divisor.Count / 2;
                //
                // var upperBound = BinarySearch.getUpperBound(divisor,n);
                // ans += (1 + ((upperBound - 1) - center) * 2);
            }

            Console.WriteLine(ans);
        }


        public static Dictionary<long, List<long>> memo = new Dictionary<long, List<long>>();

        /// <summary>
        /// 約数列挙(そのままリストで受け取る)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<long> getDivisor(long n)
        {
            var ret = new List<long>();

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            for (int i = 1; i * i <= n; i++)
            {
                if (n % i != 0)
                {
                    continue;
                }

                ret.Add(i);

                if (n / i != i)
                {
                    ret.Add(n / i);
                }
            }

            // メモ更新
            memo.Add(n, ret);

            return ret;
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