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

namespace ABC254D3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();


            var tmp = new List<long>();
            for (int i = 1; i * i <= n; i++) tmp.Add(i * i);
            var square = tmp.ToArray();

            var dic = new Dictionary<long, long>();

            var ans = 0L;
            for (int i = 1; i <= n; i++)
            {
                // 素因数分解
                var primes = PrimeFactors(i).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

                // 素因数分解で、余っているやつを探す。
                var x = 1L;
                foreach (var p in primes)
                {
                    if (p.Value % 2 == 1)
                    {
                        x *= p.Key;
                    }
                }

                if (dic.ContainsKey(x))
                {
                    dic[x] += 1;
                }
                else
                {
                    dic.Add(x,1);
                }
            }

            var sum = 0L;
            foreach (var (k,v) in dic)
            {
                var l = v*v;
                sum += l;
            }

            Console.WriteLine(sum);
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

        /// <summary>
        /// 素因数分解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeFactors(long n)
        {
            long i = 2;
            long tmp = n;

            while (i * i <= n)
            {
                if (tmp % i == 0)
                {
                    tmp /= i;
                    yield return i;
                }
                else
                {
                    i++;
                }
            }

            if (tmp != 1) yield return tmp; //最後の素数も返す
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