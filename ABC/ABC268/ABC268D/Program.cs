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
using Microsoft.VisualBasic;
using static System.Math;

namespace ABC268D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var sList = Enumerable.Range(0, n).Select(_ => ReadValue<String>()).ToArray();
            var tList = Enumerable.Range(0, m).Select(_ => ReadValue<String>()).ToArray();


            var tDic = tList.Distinct().ToHashSet();

            if (n == 1 && m == 1)
            {
                if (sList[0] == tList[0])
                {
                    Console.WriteLine(-1);
                    return;
                }
                else
                {
                    Console.WriteLine(sList[0]);
                    return;
                }
            }


            {
                var sum = sList.Select(x => x.Length).Sum();
                var mustUnderCount = n - 1;

                if (sum + mustUnderCount > 16)
                {
                    Console.WriteLine(-1);
                    return;
                }

                if (sum + mustUnderCount < 3)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }


            var li = new Dictionary<string, List<(String, List<int>)>>();

            foreach (var s in tList)
            {
                if (s.StartsWith('_'))
                {
                    continue;
                }

                if (!s.Contains('_'))
                {
                    continue;
                }

                // 16より大きいのは作れない
                if (s.Length >= 17)
                {
                    continue;
                }

                if (s.Length < 3)
                {
                    continue;
                }

                if (s.All(x => x == '_'))
                {
                    continue;
                }

                var ms = s.Split('_').Where(x => x != "").ToArray();

                if (ms.Length != n)
                {
                    continue;
                }


                var countList = new List<int>();
                var count = 0;
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '_')
                    {
                        count++;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            countList.Add(count);
                        }

                        count = 0;
                    }
                }


                var @join = Strings.Join(ms, ",");

                if (li.ContainsKey(@join))
                {
                    li[join].Add((s, countList));
                }
                else
                {
                    li.Add(join, new List<(string s, List<int> countList)>() {(s, countList)});
                }
            }


            var perm = new Permutation();
            foreach (var strings in perm.Enumerate(sList))
            {
                var @join = Strings.Join(strings, ",");
                if (!li.ContainsKey(@join))
                {
                    Console.WriteLine(join.Replace(',', '_'));
                    return;
                }

                // それっぽいものが含まれている場合は、詳細検査して、該当しないものを作れるか確認
                foreach (var s in li[@join])
                {
                    // 文字の長さ
                    var sum = strings.Select(x => x.Length).Sum();

                    // アンダースコアが使える回数
                    var uCount = 16 - sum;


                    var array = Enumerable.Range(0, uCount)
                        .Select(x => x + 1)
                        .Select(x => Enumerable.Repeat(x, s.Item2.Count))
                        .SelectMany(x => x)
                        .ToArray();

                    var customPermutations = new CustomPermutations(s.Item2.Count);

                    var splitteds = strings;

                    foreach (var x1 in customPermutations.NCR(array))
                    {
                        var lll = splitteds.Select(x => x.Length).Sum() + x1.Sum();
                        if (lll < 3 || 16 < lll)
                        {
                            continue;
                        }

                        if (x1.Contains(0))
                        {
                            continue;
                        }

                        var sb = new StringBuilder();

                        for (var i = 0; i < splitteds.Length - 1; i++)
                        {
                            sb.Append(splitteds[i]);
                            var s1 = new string(Enumerable.Repeat('_', x1[i]).ToArray());
                            sb.Append(s1);
                        }

                        sb.Append(splitteds.Last());

                        var build = sb.ToString();


                        if (!tDic.Contains(build))
                        {
                            Console.WriteLine(build);
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("-1");
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

        /// <summary>
        /// 順列の中からr個を取得。重複なし。(これCombinationだから名前間違ってるね)
        /// 
        /// <example>
        /// <code>
        /// var items = Enumerable.Range(1, 5).Select(x => x).ToArray();
        /// var perm = new PermutationS(3);
        /// foreach (var ints in permutations.NCR(items))
        /// {
        ///     var @join = String.Join(' ', ints);
        ///     Console.WriteLine(join);
        /// }
        ///
        /// // results
        /// 1 2 3
        /// 1 2 4
        /// 1 2 5
        /// 1 3 4
        /// 1 3 5
        /// 1 4 5
        /// 2 3 4
        /// 2 3 5
        /// 2 4 5
        /// 3 4 5
        /// </code>
        /// </example>
        /// </summary>
        public class CustomPermutations
        {
            private int r;

            public CustomPermutations(int r)
            {
                this.r = r;
            }

            // 順列の中から順にr個選ぶ。
            public IEnumerable<T[]> NCR<T>(T[] items)
            {
                if (items.Count() == 1)
                {
                    yield return new T[] {items.First()};
                    yield break;
                }

                var n = items.Count();

                for (int bit = 0; bit < 1 << n; bit++)
                {
                    var bitS = Convert.ToString(bit, 2).PadLeft(n, '0');
                    if (bitS.Count(x => x == '0') != r) continue;

                    var A = new List<T>();

                    for (var i = 0; i < bitS.Length; i++)
                    {
                        var c = bitS[i];
                        if (c == '0') A.Add(items[i]);
                    }

                    yield return A.ToArray();
                }

                yield break;
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