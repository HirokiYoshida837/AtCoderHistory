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

namespace ABC269C2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();

            var bitS = Convert.ToString(n, 2).PadLeft(61, '0');

            var valueTuples = bitS.Reverse().Select((x, i) => (x, i)).Where(x => x.x == '1').Select(x => x.i).ToArray();

            var count = valueTuples.Length;

            var ansList = new List<long>() {0};


            for (int i = 1; i <= count; i++)
            {
                var permutations = new Permutations(i);

                foreach (var ints in permutations.NCR(valueTuples))
                {
                    var ans = 0L;
                    foreach (var i1 in ints)
                    {
                        var v = 1L << i1;
                        ans += v;
                    }

                    ansList.Add(ans);
                }
            }


            foreach (var l in ansList.Distinct().OrderBy(x => x))
            {
                Console.WriteLine(l);
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
        public class Permutations
        {
            private int r;

            public Permutations(int r)
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