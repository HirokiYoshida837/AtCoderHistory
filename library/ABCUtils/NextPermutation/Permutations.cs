using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCUtils.NextPermutation
{
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
}