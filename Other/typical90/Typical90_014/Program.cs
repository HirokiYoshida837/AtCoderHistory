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

namespace Typical90_014
{
    /// <summary>
    /// [014 - We Used to Sing a Song Together（★3）](https://atcoder.jp/contests/typical90/tasks/typical90_n)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().ToList();
            var bList = ReadList<long>().ToList();

            if (n == 1)
            {
                Console.WriteLine(Math.Abs(aList[0] - bList[0]));
                return;
            }

            // ソートしても問題なさそう
            aList = aList.OrderBy(x => x).ToList();
            bList = bList.OrderBy(x => x).ToList();


            var diff = new List<long>();

            for (int i = 0; i < n; i++)
            {
                var a = aList[i];
                var b = bList[i];
                diff.Add(Math.Abs(a-b));
            }


            Console.WriteLine(diff.Sum());




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