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

namespace ABC232C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var abList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .Select(x => (x.Item1 - 1, x.Item2-1))
                .ToArray();
            var cdList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .Select(x => (x.Item1 - 1, x.Item2-1))
                .ToArray();

            
            var graphB = new bool[n,n];

            foreach (var (c,d) in cdList)
            {
                graphB[c, d] = true;
                graphB[d, c] = true;
            }

            var sbCD = new StringBuilder();
            foreach (var b in graphB)
            {
                sbCD.Append(b);
            }

            var sCD = sbCD.ToString(); 

            foreach (var ints in new Permutation().Enumerate(Enumerable.Range(0, n)))
            {
                var graphA = new bool[n,n];

                foreach (var (a,b) in abList)
                {
                    graphA[ints[a], ints[b]] = true;
                    graphA[ints[b], ints[a]] = true;
                }
                
                var sbAB = new StringBuilder();
                foreach (var b in graphA)
                {
                    sbAB.Append(b);
                }

                var sAB = sbAB.ToString();

                if (sCD == sAB)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }

        public static void solve1()
        {
            // 繋がってる辺の数が同じかで判定するのは嘘解法らしい。

            var (n, m) = ReadValue<int, int>();
            var abList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();
            var cdList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();


            var graphA = Enumerable.Range(0, n + 1)
                .Select(_ => new List<int>())
                .ToArray();

            var graphB = Enumerable.Range(0, n + 1)
                .Select(_ => new List<int>())
                .ToArray();

            foreach (var (a, b) in abList)
            {
                graphA[a].Add(b);
                graphA[b].Add(a);
            }

            foreach (var (c, d) in cdList)
            {
                graphB[c].Add(d);
                graphB[d].Add(c);
            }

            var gA = graphA.Select(x => x.Count)
                .OrderByDescending(x => x)
                .Select(x => x.ToString())
                .Aggregate((a, b) => a + ", " + b);

            var gB = graphB.Select(x => x.Count)
                .OrderByDescending(x => x)
                .Select(x => x.ToString())
                .Aggregate((a, b) => a + ", " + b);


            Console.WriteLine(gA == gB ? "Yes" : "No");
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