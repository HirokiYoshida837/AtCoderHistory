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

namespace ABC249C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();

            var sList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();

            // bit全探索
            var ans = 0;

            for (int bit = 0; bit < 1<<n; bit++)
            {
                var tmp = Convert.ToString(bit, 2);
                var bitS = tmp.PadLeft(n, '0');

                var list = new List<string>();

                for (var i = 0; i < bitS.Length; i++)
                {
                    if (bitS[i] == '1')
                    {
                        list.Add(sList[i]);
                    }
                }

                var dic = Enumerable.Range('a', 'z' - 'a' + 1)
                    .ToDictionary(x => (char) x, _ => 0);

                foreach (var c in list.SelectMany(s => s))
                {
                    dic[c] += 1;
                }

                var count = dic.Count(x => x.Value == k);
                ans = Max(ans, count);
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