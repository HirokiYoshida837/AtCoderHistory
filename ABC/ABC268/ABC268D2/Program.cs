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

namespace ABC268D2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var sList = Enumerable.Range(0, n).Select(_ => ReadValue<String>()).ToArray();
            var tList = Enumerable.Range(0, m).Select(_ => ReadValue<String>()).ToArray();

            var tDic = tList.ToHashSet();

            if (n == 1)
            {
                if (sList[0].Length >= 3 && sList[0].Length <= 16)
                {
                    if (tDic.Contains(sList[0]))
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
                else
                {
                    Console.WriteLine(-1);
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


            var dic = new Dictionary<string, HashSet<String>>();

            foreach (var tItem in tList)
            {
                if (tItem.StartsWith('_'))
                {
                    continue;
                }

                if (!tItem.Contains('_'))
                {
                    continue;
                }

                if (tItem.EndsWith('_'))
                {
                    continue;
                }

                if (tItem.Length > 16)
                {
                    continue;
                }

                if (tItem.Length < 3)
                {
                    continue;
                }

                var spl = tItem.Split("_").Where(x => x != "").ToList();

                if (spl.Count != n)
                {
                    continue;
                }

                // アンダーバーの個数を数える
                var uCount = new List<int>();
                var count = 0;
                for (var i = 0; i < tItem.Length; i++)
                {
                    if (tItem[i] == '_')
                    {
                        count++;
                    }
                    else
                    {
                        if (count != 0)
                        {
                            uCount.Add(count);
                        }

                        count = 0;
                    }
                }

                var uCountJoin = Strings.Join(uCount.Select(x => x.ToString()).ToArray(), ",");

                var joinSpl = Strings.Join(spl.ToArray(), ",");
                if (dic.ContainsKey(joinSpl))
                {
                    dic[joinSpl].Add(uCountJoin);
                }
                else
                {
                    dic.Add(joinSpl, new HashSet<string>() {uCountJoin});
                }
            }

            var strRemain = 16 - sList.Select(x => x.Length).Sum();


            if (dic.Count == 0)
            {
                var @join = Strings.Join(sList.ToArray(), "_");
                Console.WriteLine(@join);
                return;
            }


            foreach (var strings in new Permutation().Enumerate(sList))
            {
                var key = Strings.Join(strings, ",");

                if (!dic.ContainsKey(key))
                {
                    // これそのまま出せば終わり。
                    Console.WriteLine(key.Replace(',', '_'));
                    return;
                }

                var list = Enumerable.Range(0, n - 1).Select(x => Enumerable.Range(1, strRemain - 1).ToList()).ToList();
                var selected = new List<int>();

                var s = DFS(0, strRemain);
                if (s != "")
                {
                    Console.WriteLine(s);
                    return;
                }


                string DFS(int depth, int remain)
                {
                    if (remain < 0)
                    {
                        return "";
                    }

                    if (depth == n - 1)
                    {
                        var @join = Strings.Join(selected.Select(x => x.ToString()).ToArray(), ",");

                        if (!dic[key].Contains(@join))
                        {
                            var enumerables = selected.Select(x => Enumerable.Repeat('_', x).ToArray())
                                .Select(x => new string(x))
                                .ToArray();

                            // ここで終了
                            var sb = new StringBuilder();
                            for (var i = 0; i < strings.Length - 1; i++)
                            {
                                sb.Append(strings[i]);
                                sb.Append(enumerables[i]);
                            }

                            sb.Append(strings.Last());

                            if (sb.Length < 3 || sb.Length > 16)
                            {
                                return "";
                            }

                            var format = sb.ToString();
                            if (tDic.Contains(format))
                            {
                                return "";
                            }
                            else
                            {
                                return format;
                                // Console.WriteLine(format);
                                // throw new Exception();
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }

                    foreach (var i in list[depth])
                    {
                        if (remain >= i)
                        {
                            selected.Add(i);
                            var dfs = DFS(depth + 1, remain - i);
                            if (dfs != "")
                            {
                                return dfs;
                            }
                            else
                            {
                                selected.RemoveAt(selected.Count - 1);
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }

                    return "";
                }
            }

            Console.WriteLine(-1);
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