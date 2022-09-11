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

namespace Hard_028
{
    /// <summary>
    /// [C - Candles](https://atcoder.jp/contests/abc107/tasks/arc101_a)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var xList = ReadList<long>().ToList();

            if (n == 1)
            {
                Console.WriteLine(Math.Abs(xList.First()));
                return;
            }


            var xmin = xList[0];
            var xmax = xList.Last();


            if (xmin >= 0) // 全部右側
            {
                var enumerable = xList.Take(k).ToArray();
                var ans = enumerable.Last();

                Console.WriteLine(ans);
            }
            else if (xmax <= 0) // 全部左側
            {
                var enumerable = xList.TakeLast(k).ToArray();
                var ans = enumerable.First();
                Console.WriteLine(Math.Abs(ans));
            }
            else
            {
                if (n==k)
                {
                    var l = xmin;
                    var r = xmax;

                    var v1 = Math.Abs(l) * 2 + Math.Abs(r);
                    var v2 = Math.Abs(r) * 2 + Math.Abs(l);

                    Console.WriteLine(Math.Min(v1,v2));
                    return;
                }
                
                // 0を中心にk個取るのを試す
                var binarySearch = xList.BinarySearch(0);


                if (binarySearch < 0)
                {
                    // 0を含んでない場合
                    if (binarySearch < 0) binarySearch = ~binarySearch;

                    var left = Math.Max(0, (binarySearch - 1) - k + 1);

                    var list = new List<long>();

                    try
                    {
                        for (int i = left; i + k < xList.Count; i++)
                        {
                            if (xList[i] > xList[binarySearch])
                            {
                                break;
                            }

                            var l = xList[i];
                            var r = xList[i + k - 1];

                            // 両方符号が同じの場合
                            if ((l < 0 && r < 0) || (l > 0 && r > 0))
                            {
                                list.Add(Math.Max(Math.Abs(l), Math.Abs(r)));
                            }
                            else
                            {
                                var v1 = Math.Abs(l * 2) + Math.Abs(r);
                                var v2 = Math.Abs(r * 2) + Math.Abs(l);
                                list.Add(v1);
                                list.Add(v2);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        // 例外握り
                    }

                    Console.WriteLine(list.Min());
                }
                else
                {
                    // 0を含んでいる場合

                    var left = Math.Max(0, (binarySearch - k) + 1);

                    var list = new List<long>();

                    try
                    {
                        for (int i = left; i + k < xList.Count; i++)
                        {
                            if (xList[i] > 0)
                            {
                                break;
                            }

                            var l = xList[i];
                            var r = xList[i + k - 1];

                            var v1 = Math.Abs(l * 2) + Math.Abs(r);
                            var v2 = Math.Abs(r * 2) + Math.Abs(l);
                            list.Add(v1);
                            list.Add(v2);
                        }
                    }
                    catch (Exception e)
                    {
                    }

                    Console.WriteLine(list.Min());
                }
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