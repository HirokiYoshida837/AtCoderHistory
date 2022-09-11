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

namespace Typical90_010
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            var cpList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();


            var q = ReadValue<int>();
            var queries = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int, int>())
                .ToArray();


            var kumi1 = new long[n + 10];
            var kumi2 = new long[n + 10];

            for (var i = 0; i < cpList.Length; i++)
            {
                var cp = cpList[i];

                if (cp.Item1 == 1)
                {
                    kumi1[i + 1] = cp.Item2;
                }
                else
                {
                    kumi2[i + 1] = cp.Item2;
                }
            }


            // Console.WriteLine(kumi1);

            var cum1 = new long[n + 10];
            var cum2 = new long[n + 10];

            for (int i = 1; i < kumi1.Length; i++)
            {
                cum1[i] = cum1[i - 1] + kumi1[i];
                cum2[i] = cum2[i - 1] + kumi2[i];
            }

            // Console.WriteLine(cum1);

            foreach (var (l, r) in queries)
            {
                var left1 = cum1[l - 1];
                var right1 = cum1[r];

                

                var left2 = cum2[l - 1];
                var right2 = cum2[r];

                Console.WriteLine($"{right1 - left1} {right2 - left2}");
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