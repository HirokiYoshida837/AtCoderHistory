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

namespace ABC265E3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            var abcdef = Console.ReadLine().Split().Select(long.Parse).ToArray();

            (long a, long b) ab = (abcdef[0], abcdef[1]);
            (long c, long d) cd = (abcdef[2], abcdef[3]);
            (long e, long f) ef = (abcdef[4], abcdef[5]);

            var a = new List<(long, long)>() {ab, cd, ef};

            var xyList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<long, long>())
                .ToHashSet();

            // var dp = new ModInt[n+1,n+1,n+1];

            var dp = new ModInt[n + 1][,];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new ModInt[n + 1 + 1, n + 1 + 1];
            }

            dp[0][0, 0] = new ModInt(1);


            // 配るDP。
            for (int count = 0; count < n; count++)
            {
                for (int i = 0; i <= count; i++)
                {
                    for (int j = 0; j <= count; j++)
                    {
                        var k = count - (i + j);

                        // 辿ってきた道のりから計算
                        var currentX = ab.a * i + cd.c * j + ef.e * k;
                        var currentY = ab.b * i + cd.d * j + ef.f * k;

                        // abを選ぶケース
                        {
                            var next = (currentX + ab.a, currentY + ab.b);
                            if (!xyList.Contains(next))
                            {
                                dp[count + 1][i + 1, j] += dp[count][i, j];
                            }
                        }
                        // cdを選ぶケース
                        {
                            var next = (currentX + cd.c, currentY + cd.d);
                            if (!xyList.Contains(next))
                            {
                                dp[count + 1][i, j + 1] += dp[count][i, j];
                            }
                        }
                        // efを選ぶケース
                        {
                            var next = (currentX + ef.e, currentY + ef.f);
                            if (!xyList.Contains(next))
                            {
                                dp[count + 1][i, j] += dp[count][i, j];
                            }
                        }
                    }
                }
            }

            var sum = new ModInt(0);
            foreach (var modInt in dp[n])
            {
                sum += modInt;
            }

            Console.WriteLine(sum);
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