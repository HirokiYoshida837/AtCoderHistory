﻿using System;
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

namespace EDCP_H
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var aMatrix = Enumerable.Range(0, h)
                .Select(_ => ReadValue<string>().ToList())
                .Select(x =>
                {
                    x.Insert(0, '#');
                    return x.ToArray();
                })
                .ToList();

            aMatrix.Insert(0, new char[w + 1]);
            for (int i = 0; i < w + 1; i++)
            {
                aMatrix[0][i] = '#';
            }

            aMatrix[0][1] = '.';

            var dp = new ModInt[h + 1][];
            for (int i = 0; i < h + 1; i++)
            {
                dp[i] = new ModInt[w + 1];
            }

            dp[0][0] = 0;
            dp[0][1] = 1;

            for (int i = 1; i < h + 1; i++)
            {
                for (int j = 1; j < w + 1; j++)
                {
                    if (aMatrix[i][j] == '#')
                    {
                        continue;
                    }

                    var count = new ModInt();
                    if (aMatrix[i][j - 1] != '#')
                    {
                        count += dp[i][j - 1];
                    }

                    if (aMatrix[i - 1][j] != '#')
                    {
                        count += dp[i - 1][j];
                    }

                    dp[i][j] += count;
                }
            }

            Console.WriteLine(dp.Last().Last());
        }

        /// <summary>
        /// ModInt (long)
        /// </summary>
        public struct ModInt
        {
            public const int Mod = 1000000007;
            const long POSITIVIZER = ((long)Mod) << 31;
            long Data;

            public ModInt(long data)
            {
                if ((Data = data % Mod) < 0) Data += Mod;
            }

            public static implicit operator long(ModInt modInt) => modInt.Data;
            public static implicit operator ModInt(long val) => new ModInt(val);

            public static ModInt operator +(ModInt a, int b) =>
                new ModInt() { Data = (a.Data + b + POSITIVIZER) % Mod };

            public static ModInt operator +(ModInt a, long b) => new ModInt(a.Data + b);

            public static ModInt operator +(ModInt a, ModInt b)
            {
                long res = a.Data + b.Data;
                return new ModInt() { Data = res >= Mod ? res - Mod : res };
            }

            public static ModInt operator -(ModInt a, int b) =>
                new ModInt() { Data = (a.Data - b + POSITIVIZER) % Mod };

            public static ModInt operator -(ModInt a, long b) => new ModInt(a.Data - b);

            public static ModInt operator -(ModInt a, ModInt b)
            {
                long res = a.Data - b.Data;
                return new ModInt() { Data = res < 0 ? res + Mod : res };
            }

            public static ModInt operator *(ModInt a, int b) => new ModInt(a.Data * b);
            public static ModInt operator *(ModInt a, long b) => a * new ModInt(b);
            public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % Mod };
            public static ModInt operator /(ModInt a, ModInt b) => new ModInt() { Data = a.Data * GetInverse(b) % Mod };
            public static bool operator ==(ModInt a, ModInt b) => a.Data == b.Data;
            public static bool operator !=(ModInt a, ModInt b) => a.Data != b.Data;
            public override string ToString() => Data.ToString();
            public override bool Equals(object obj) => (ModInt)obj == this;
            public override int GetHashCode() => (int)Data;

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
            return (T)Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2)),
                (T3)Convert.ChangeType(input[2], typeof(T3))
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
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}