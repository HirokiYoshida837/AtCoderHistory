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

namespace Hard_021
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().OrderBy(x => x).ToList();

            if (n == 2)
            {
                Console.WriteLine($"{aList.Max()} {aList.Min()}");
                return;
            }

            var amax = aList.Last();

            var target = amax / 2;
            var c = -1L;

            var binarySearch = aList.BinarySearch(target);
            if (binarySearch < 0)
            {
                binarySearch = ~binarySearch;

                var c1 = aList[binarySearch];

                if (binarySearch >= 1)
                {
                    var c2 = aList[binarySearch - 1];

                    if (Math.Abs(c1-target) <= Math.Abs(c2-target))
                    {
                        c = c1;
                    }
                    else
                    {
                        c = c2;
                    }
                }
                else
                {
                    c = c1;
                }
            }
            else
            {
                c = aList[binarySearch];
            }

            Console.WriteLine($"{amax} {c}");
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