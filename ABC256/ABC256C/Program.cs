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

namespace ABC256C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var hws = ReadList<int>().ToArray();

            var h1 = hws[0];
            var h2 = hws[1];
            var h3 = hws[2];
            var w1 = hws[3];
            var w2 = hws[4];
            var w3 = hws[5];

            var count = 0L;

            // hの条件をみたすリストをそれぞれ準備しておく

            var h1List = new List<List<int>>();
            var h2List = new List<List<int>>();
            var h3List = new List<List<int>>();

            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        if (i + j + k == h1)
                        {
                            h1List.Add(new List<int>() {i, j, k});
                        }

                        if (i + j + k == h2)
                        {
                            h2List.Add(new List<int>() {i, j, k});
                        }

                        if (i + j + k == h3)
                        {
                            h3List.Add(new List<int>() {i, j, k});
                        }
                    }
                }
            }


            foreach (var h1s in h1List)
            {
                foreach (var h2s in h2List)
                {
                    foreach (var h3s in h3List)
                    {
                        if (h1s[0] + h2s[0] + h3s[0] == w1
                            && h1s[1] + h2s[1] + h3s[1] == w2
                            && h1s[2] + h2s[2] + h3s[2] == w3)
                        {
                            count++;
                        }


                        // var permh1 = new Permutation();
                        // var permh2 = new Permutation();
                        // var permh3 = new Permutation();
                        // foreach (var intsh1 in permh1.Enumerate(h1s))
                        // {
                        //     foreach (var intsh2 in permh2.Enumerate(h2s))
                        //     {
                        //         foreach (var intsh3 in permh3.Enumerate(h3s))
                        //         {
                        //             if (intsh1[0] + intsh2[0] + intsh3[0] == w1
                        //                 && intsh1[1] + intsh2[1] + intsh3[1] == w2
                        //                 && intsh1[2] + intsh2[2] + intsh3[2] == w3)
                        //             {
                        //                 count++;
                        //             }
                        //         }
                        //     }
                        // }
                    }
                }
            }

            Console.WriteLine(count);


            // for (int i = 0; i <= 2; i++)
            // {
            //     for (int j = 0; j <= 2; j++)
            //     {
            //         for (int k = 0; k <= 2; k++)
            //         {
            //         }
            //     }
            // }


            // for (long i = 111111111; i <= 999999999; i++)
            // {
            // var square = new int[3,3];
            //
            // var s = i.ToString();
            // for (int index = 0; index < 9; index++)
            // {
            //     var c = s[index] - '0';
            //     square[index % 3, index / 3] = c;
            // }
            //
            // // 判定処理
            //
            // if (
            //     (square[0, 0] + square[0, 1] + square[0, 2] == h1)
            //     && (square[1, 0] + square[1, 1] + square[1, 2] == h2)
            //     && (square[2, 0] + square[2, 1] + square[2, 2] == h3)
            // )
            // {
            //     if (
            //         (square[0, 0] + square[1, 0] + square[2, 0] == w1)
            //         && (square[0, 1] + square[1, 1] + square[2, 1] == w2)
            //         && (square[0, 2] + square[1, 2] + square[2, 2] == w3)
            //         )
            //     {
            //         count++;
            //     }
            //     
            // }
            // }
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

    /// <summary>
    /// 
    /// <see href="https://qiita.com/gushwell/items/8780fc2b71f2182f36ac">C#:全ての要素を使った順列を求める - Qiita</see>
    /// 
    /// <example>
    /// <code>
    /// var perm = new Permutation();
    /// foreach (var chars1 in perm.Enumerate(Enumerable.Range(0, s.Length)))
    /// {
    ///     var str = new string(chars1.Select(x => s[x]).ToArray());
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public class Permutation
    {
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items)
        {
            if (items.Count() == 1)
            {
                yield return new T[] {items.First()};
                yield break;
            }

            foreach (var item in items)
            {
                var leftside = new T[] {item};
                var unused = items.Except(leftside);
                foreach (var rightside in Enumerate(unused))
                {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}