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

namespace Hard_017
{
    /// <summary>
    /// [C - AB Substrings](https://atcoder.jp/contests/diverta2019/tasks/diverta2019_c)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var sList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();

            // 文字列中に含まれているものだけをカウント
            var containsCount = 0L;
            foreach (var s in sList)
            {
                for (var i = 1; i < s.Length; i++)
                {
                    var s1 = new string(new List<char>() {s[i - 1], s[i]}.ToArray());
                    if (s1 == "AB")
                    {
                        containsCount++;
                    }
                }
            }

            var sum = 0L;
            // 文字列の先頭と最後だけを残して辞書化
            var dictionary = sList.Select(x => new char[] {x[0], x.Last()})
                .Select(x => new string(x))
                .Where(x => x.StartsWith("B") || x.EndsWith("A"))
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());


            var endWithACount = 0L;
            var startWithBCount = 0L;
            var BACount = 0L;

            foreach (var (key, value) in dictionary)
            {
                if (key == "BA")
                {
                    BACount += value;
                }
                else
                {
                    if (key.EndsWith("A"))
                    {
                        endWithACount += value;
                    }
                    else
                    {
                        startWithBCount += value;
                    }
                }
            }

            // if (BACount > 0)
            // {
            //     sum += BACount - 1;
            //     if (endWithACount > 0)
            //     {
            //         sum += 1;
            //     }
            //
            //     if (startWithBCount > 0)
            //     {
            //         sum += 1;
            //     }
            // }
            // else
            // {
            //     sum += Math.Min(endWithACount, endWithACount);
            // }

            if (BACount == 0)
            {
                // BA,BA,BA が作れないので、そのままペアを作る。
                sum += Math.Min(endWithACount, startWithBCount);
            }
            else
            {
                // XA,BA,BA...BA,BX + XA,BA, XA,BA と並べるのが一番よい。
                // -> BAの前後に置く用のXA,BX と、XA,BXを作れる個数
                if (startWithBCount > 0 && endWithACount > 0)
                {
                    sum += BACount + 1;
                    sum += Math.Min(startWithBCount - 1, endWithACount - 1);
                }
                else 
                {
                    // XA,BXがないのであれば、 BA,BA しか作れない
                    if (startWithBCount == 0 && endWithACount == 0)
                    {
                        sum += BACount - 1;
                    }
                    else
                    {
                        // XA,BXのどちらかは0なので、XA, AB,AB, のようになる。
                        sum += BACount;
                    }
                }
            }
            //
            //
            // var min = Math.Min(Math.Min(BACount, endWithACount), startWithBCount);
            //
            // if (BACount == min)
            // {
            //     sum += 2 * min;
            //     sum += Math.Min(endWithACount - min, startWithBCount - min);
            // }
            // else
            // {
            //     if (endWithACount == min)
            //     {
            //         sum += 2 * min;
            //         var e = startWithBCount - min;
            //         var f = BACount - min;
            //
            //         if (f == 1)
            //         {
            //             sum += 1;
            //         }
            //         else
            //         {
            //             sum += f - 1;
            //             if (e > 0)
            //             {
            //                 sum += 1;
            //             }
            //         }
            //     }
            //     else
            //     {
            //         sum += 2 * min;
            //
            //         var e = endWithACount - min;
            //         var f = BACount - min;
            //
            //         if (f == 1)
            //         {
            //             sum += 1;
            //         }
            //         else
            //         {
            //             sum += f - 1;
            //             if (e > 0)
            //             {
            //                 sum += 1;
            //             }
            //         }
            //     }
            // }

            Console.WriteLine(containsCount + sum);
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