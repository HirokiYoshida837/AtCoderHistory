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

namespace Typical90_008
{
    /// <summary>
    /// [008 - AtCounter（★4）](https://atcoder.jp/contests/typical90/tasks/typical90_h)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var s = ReadValue<string>();

            var atcoder = "atcoder";

            var dictionary = atcoder.Select((x,i)=>(x,i+1))
                .ToDictionary(x=>x.x, x=>x.Item2);

            var dp = new ModInt[n + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new ModInt[atcoder.Length + 1];
            }

            dp[0][0] = 1;
            

            // もらうDP
            for (int i = 1; i < dp.Length; i++)
            {
                var c = s[i - 1];

                if (!dictionary.ContainsKey(c))
                {
                    for (var j = 0; j < dp[i].Length; j++)
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                }
                else
                {
                    var target = dictionary[c];
                    
                    for (var j = 0; j < dp[i].Length; j++)
                    {
                        // 基本的には前の値を引き継ぎ
                        dp[i][j] = dp[i - 1][j];

                        if (j == target)
                        {
                            dp[i][j] += dp[i - 1][j - 1];
                        }
                    }
                }
            }

            var modInt = dp.Last()[7];

            Console.WriteLine(modInt);
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