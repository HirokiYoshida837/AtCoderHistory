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

namespace ABC183C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();

            var t = Enumerable.Range(0, n)
                .Select(_ => ReadList<int>().ToArray())
                .ToArray();
            
            
            // 全探索

            var permutation = new Permutation();

            var l = Enumerable.Range(2, n - 1)
                .ToArray();

            var ans = 0L;

            foreach (var ints in permutation.Enumerate(l))
            {
                var count = 0L;
                count += t[1 - 1][ints[0]-1];
                
                for (var i = 1; i < ints.Length; i++)
                {
                    var before = ints[i - 1];
                    var now = ints[i];
                    count += t[before-1][now-1];
                }

                count += t[ints[^1]-1][1-1];

                if (count == k)
                {
                    ans++;
                }
            }

            Console.WriteLine(ans);

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