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

namespace Hard_2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, long>();
            var aList = ReadList<int>().ToArray();

            // 各単体でのSUM
            var bit = new BIT(2010);
            var sum = new ModInt(0);
            for (var j = 0; j < aList.Length; j++)
            {
                sum += j - bit.Sum(aList[j]);
                bit.Add(aList[j], 1);
            }

            if (k == 1)
            {
                Console.WriteLine(sum);
                return;
            }

            // 自分より小さい数がいくつあるかを数える
            var dic = aList.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            var cum = new ModInt[2010];
            cum[0] = 0;
            for (int i = 1; i < 2010; i++)
            {
                if (dic.ContainsKey(i))
                {
                    cum[i] = cum[i - 1] + dic[i];
                }
                else
                {
                    cum[i] = cum[i - 1];
                }
            }

            var memo = new Dictionary<int, ModInt>();
            foreach (var dicKey in dic.Keys)
            {
                var v = cum[dicKey - 1];
                memo.Add(dicKey, v);
            }

            var mSum = new ModInt(0);
            var kModInt = new ModInt(k);
            
            foreach (var a in aList)
            {
                var v = memo[a];
                var i = v * ((kModInt - 1) * kModInt);
                mSum += (i / 2);
            }


            var modInt = mSum + sum * k;
            Console.WriteLine(modInt);
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
    /// BIT(Binary Indexed Tree) 
    /// refs : https://www.slideshare.net/hcpc_hokudai/binary-indexed-tree
    /// https://algo-logic.info/binary-indexed-tree/
    /// </summary>
    public class BIT
    {
        // 配列の要素数 (数列の要素 + 1)
        private int n { get; }

        // データの格納先 (1-indexed)。初期値は0。
        private long[] bit { get; }

        public BIT(int n)
        {
            this.n = n;
            this.bit = new long[n + 1];
        }

        // index i に tを加算する (a_i += x)
        public void Add(int i, long x)
        {
            // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
            // indexにLSBを加算しながら更新していく。
            for (int index = i; index < n; index += (index & -index))
            {
                bit[index] += x;
            }
        }

        // 最初からi番目までの和
        public long Sum(int i)
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