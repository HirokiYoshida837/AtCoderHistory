using System.Collections.Generic;
using System.Linq;

namespace ABCUtils.NextPermutation
{
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