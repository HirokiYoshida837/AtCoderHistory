using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC211D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            var abList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            if (m == 0)
            {
                Console.WriteLine(0);
                return;
            }
            
            // たどり着けないケースが一番計算量が多い。unionFindを使ってたどり着けるかどうかを先に判定しておく。
            var uf = new UnionFind(n+10);
            foreach (var (a,b) in abList)
            {
                uf.TryUnite(a, b);
            }
            
            var startGroup = uf.FindRoot(1);
            var goalGroup = uf.FindRoot(n);
            if (startGroup != goalGroup)
            {
                Console.WriteLine(0);
                return;
            }

            // 双方向のリストを作成。
            var graph = Enumerable.Range(0, n + 1)
                .ToDictionary(x => x, _ => new HashSet<int>());

            foreach (var (a, b) in abList)
            {
                graph[a].Add(b);
                graph[b].Add(a);
            }


            var dp = new Dictionary<int, ModInt>[m + 10];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new Dictionary<int, ModInt>();
            }
            
            dp[0].Add(1,1);

            // ナイーブな配るdpだとTLE。dicで場合の数を動的にすれば早くなりそう。
            for (int i = 0; i <= m; i++)
            {
                var dict = dp[i];
                foreach (var (k, v) in dict)
                {
                    var ints = graph[k];
                    foreach (var target in ints)
                    {
                        // 自分より若い手順ですでに到達済なのであれば、考える必要なし
                        if (dp[i].ContainsKey(target))
                        {
                            continue;
                        }

                        if (dp[i + 1].ContainsKey(target))
                        {
                            dp[i + 1][target] += v;
                        }
                        else
                        {
                            dp[i + 1].Add(target, v);
                        }

                        // 枝刈りしておけば更に高速化できるか？
                        if (graph[target].Contains(k))
                        {
                            graph[target].Remove(k);
                        }
                    }
                }

                // nに到達したのであればそこで終わり。
                if (dp[i + 1].ContainsKey(n))
                {
                    Console.WriteLine(dp[i + 1][n]);
                    return;
                }
            }

            Console.WriteLine(0);
        }

        public class UnionFind
        {
            private int Size { get; set; }
            private int GroupCount { get; set; }

            private int[] Parent;
            private int[] Sizes;

            /// <summary>
            /// n要素のUnionFind-Treeを生成する
            /// </summary>
            /// <param name="count"></param>
            public UnionFind(int count)
            {
                Size = count;
                GroupCount = count;

                Parent = new int[count];
                Sizes = new int[count];

                for (int i = 0; i < count; i++)
                {
                    Parent[i] = i;
                    Sizes[i] = 1;
                }
            }

            public bool TryUnite(int x, int y)
            {
                return TryUnite(x, y, out var p);
            }

            /// <summary>
            /// xとyの属している木を合併する。<br/>
            /// xとyがすでに同じ木にある場合、falseを返す。
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="parent"> xとyの合併後のroot </param>
            /// <returns></returns>
            public bool TryUnite(int x, int y, out int parent)
            {
                //       ans += map.TryGetValue(cum[r] - k, out var val) ? val : 0;

                var xp = FindRoot(x);
                var yp = FindRoot(y);
                // rootが同じであれば、すでにUnite済なのでエラー。
                if (xp == yp)
                {
                    parent = xp;
                    return false;
                }

                if (Sizes[xp] < Sizes[yp])
                {
                    (yp, xp) = (xp, yp);
                }

                GroupCount--;

                Parent[yp] = xp;
                Sizes[xp] += Sizes[yp];

                parent = xp;
                return true;
            }

            /// <summary>
            /// xのrootを返す
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int FindRoot(int x)
            {
                // if (x == Parent[x]) return x;
                // return FindRoot(Parent[x]);

                // 再帰しないので速そう
                while (x != Parent[x])
                {
                    x = (Parent[x] = Parent[Parent[x]]);
                }

                return x;
            }

            /// <summary>
            /// rootになっているノードをすべて返す
            /// </summary>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public IEnumerable<int> AllRepresents()
            {
                return Parent.Where((x, y) => x == y);
            }

            /// <summary>
            /// xが属している木のサイズを返す
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int GetSize(int x)
            {
                return Sizes[FindRoot(x)];
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

    /// <summary>
    /// ModInt (long)
    /// </summary>
    public struct ModInt
    {
        public const int Mod = 1000000007;
        const long POSITIVIZER = ((long) Mod) << 31;
        long Data;

        public ModInt(long data)
        {
            if ((Data = data % Mod) < 0) Data += Mod;
        }

        public static implicit operator long(ModInt modInt) => modInt.Data;
        public static implicit operator ModInt(long val) => new ModInt(val);
        public static ModInt operator +(ModInt a, int b) => new ModInt() {Data = (a.Data + b + POSITIVIZER) % Mod};
        public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);

        public static ModInt operator +(ModInt a, ModInt b)
        {
            long res = a.Data + b.Data;
            return new ModInt() {Data = res >= Mod ? res - Mod : res};
        }

        public static ModInt operator -(ModInt a, int b) => new ModInt() {Data = (a.Data - b + POSITIVIZER) % Mod};
        public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);

        public static ModInt operator -(ModInt a, ModInt b)
        {
            long res = a.Data - b.Data;
            return new ModInt() {Data = res < 0 ? res + Mod : res};
        }

        public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
        public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
        public static ModInt operator *(ModInt a, ModInt b) => new ModInt() {Data = a.Data * b.Data % Mod};
        public static ModInt operator /(ModInt a, ModInt b) => new ModInt() {Data = a.Data * GetInverse(b) % Mod};
        public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
        public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
        public override string ToString() => Data.ToString();
        public override bool Equals(object obj) => (ModInt) obj == this;
        public override int GetHashCode() => (int) Data;

        static long GetInverse(long a)
        {
            long div, p = Mod, x1 = 1, y1 = 0, x2 = 0, y2 = 1;
            while (true)
            {
                if (p == 1) return x2 + Mod;
                div = a / p;
                x1 -= x2 * div;
                y1 -= y2 * div;
                a %= p;
                if (a == 1) return x1 + Mod;
                div = p / a;
                x2 -= x1 * div;
                y2 -= y1 * div;
                p %= a;
            }
        }

        public ModInt Power(long m)
        {
            ModInt pow = this;
            ModInt res = 1;

            while (m > 0)
            {
                if ((m & 1) == 1)
                {
                    res *= pow;
                }

                pow *= pow;

                m >>= 1;
            }

            return res;
        }
    }
}