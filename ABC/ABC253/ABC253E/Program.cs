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

namespace ABC253E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m, k) = ReadValue<int, int, int>();

            var dp = new ModInt[n + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new ModInt[3 * m];
            }

            var lastBit = new BIT(3 * m);
            for (int i = 1; i <= m; i++)
            {
                dp[1][i] = 1;
                lastBit.Add(i, 1);
            }

            // もらうDP。
            for (int i = 2; i <= n; i++)
            {
                var nextBit = new BIT(3 * m);
                for (int j = 1; j <= m; j++)
                {
                    var allSum = lastBit.Sum(m * 2);

                    var diff = Math.Max(0, k - 1);
                    var r = j + diff;
                    var l = Math.Max(0, j - k);

                    var lSum = lastBit.Sum(l);
                    var rSum = lastBit.Sum(r);

                    var d = rSum - lSum;

                    var v = allSum - d;

                    dp[i][j] = v;
                    nextBit.Add(j, v);
                }

                lastBit = nextBit;
            }


            var sum = new ModInt(0);
            foreach (var modInt in dp[n])
            {
                sum += modInt;
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// BIT(Binary Indexed Tree) 
        /// refs : https://www.slideshare.net/hcpc_hokudai/binary-indexed-tree
        /// https://algo-logic.info/binary-indexed-tree/
        /// </summary>
        public class BIT
        {
            // 配列の要素数 (数列の要素 + 1)
            private int n { get; }

            // データの格納先 (1-indexed)。初期値は0。
            private ModInt[] bit { get; }

            public BIT(int n)
            {
                this.n = n;
                this.bit = new ModInt[n + 1];
            }

            // index i に tを加算する (a_i += x)
            public void Add(int i, ModInt x)
            {
                // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
                // indexにLSBを加算しながら更新していく。
                for (int index = i; index < n; index += (index & -index))
                {
                    bit[index] += x;
                }
            }

            // 最初からi番目までの和
            public ModInt Sum(int i)
            {
                // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
                var sum = bit[0];
                // 0になるまで、LSBを減算しながら足していく。
                for (int index = i; index > 0; index -= (index & -index))
                {
                    sum += bit[index];
                }

                return sum;
            }

            // TODO 区間加算も実装しておく？
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
        public const int Mod = 998244353;
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
    }
}