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

namespace ABC190C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            var abList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var k = ReadValue<int>();

            var cdList = Enumerable.Range(0, k)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var count = 0L;
            // bit全探索
            for (int bit = 0; bit < 1 << k; bit++)
            {
                var bits = Convert.ToString(bit, 2).PadLeft(k, '0');
                var dishList = new HashSet<int>();

                for (var i = 0; i < bits.Length; i++)
                {
                    var b = bits[i];
                    if (b == '0')
                    {
                        dishList.Add(cdList[i].Item1);
                    }
                    else
                    {
                        dishList.Add(cdList[i].Item2);
                    }
                }

                var check1 = check(dishList);
                count = Math.Max(count, check1);
            }

            Console.WriteLine(count);

            int check(HashSet<int> set)
            {
                var num = 0;
                foreach (var (a, b) in abList)
                {
                    if ((set.Contains(a) && set.Contains(b)))
                    {
                        num++;
                    }
                }

                return num;
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