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

namespace Hard_014
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();

            var set = new HashSet<(long, long)>();

            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    set.Add((i, n / i));
                }
            }

            var list = set.Select(x=>(x.Item1.ToString().Length, x.Item2.ToString().Length))
                .Select(x=>Math.Max(x.Item1, x.Item2))
                .ToList();

            Console.WriteLine(list.Min());
        }

        /// <summary>
        /// 約数列挙(そのままリストで受け取る)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<int> getDivisor(int n)
        {
            var ret = new List<int>();

            for (int i = 1; i * i <= n; i++)
            {
                if (n % i != 0)
                {
                    continue;
                }

                ret.Add(i);

                if (n / i != i)
                {
                    ret.Add(n / i);
                }
            }

            return ret;
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