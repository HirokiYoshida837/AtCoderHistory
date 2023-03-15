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

namespace Easy_044
{
    // https://atcoder.jp/contests/abc124/tasks/abc124_c
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            var l = s.Length;

            var typeA = new char[l];
            var typeB = new char[l];

            for (int i = 0; i < l; i++)
            {
                if (i % 2 == 0)
                {
                    typeA[i] = '0';
                    typeB[i] = '1';
                }
                else
                {
                    typeA[i] = '1';
                    typeB[i] = '0';
                }
            }


            // Aの場合
            var countA = 0L;

            for (int i = 0; i < l; i++)
            {
                if (s[i] != typeA[i])
                {
                    countA++;
                }
            }

            // Bの場合
            var countB = 0L;

            for (int i = 0; i < l; i++)
            {
                if (s[i] != typeB[i])
                {
                    countB++;
                }
            }

            Console.WriteLine(Min(countA, countB));
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