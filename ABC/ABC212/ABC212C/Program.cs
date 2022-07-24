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

namespace ABC212C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var aList = ReadList<int>().OrderBy(x => x).ToList();
            var bList = ReadList<int>().OrderBy(x => x).ToList();
            var bHashSet = new HashSet<int>(bList);
            
            var ans = int.MaxValue;
            // 二分探索する方法。こっちのほうが早い。
            // foreach (var a in aList)
            // {
            //     var binarySearch = bList.BinarySearch(a);
            //     if (binarySearch < 0)
            //     {
            //         binarySearch = ~binarySearch;
            //     }
            //
            //     if (binarySearch < m)
            //     {
            //         ans = Math.Min(ans, Math.Abs(a - bList[binarySearch]));
            //     }
            //
            //     if (binarySearch != 0)
            //     {
            //         ans = Math.Min(ans, Math.Abs(a - bList[binarySearch - 1]));
            //     }
            // }

            // sortedset使ってみた方法
            var aSet = new SortedSet<int>(aList);
            var bSet = new SortedSet<int>(bList);
            foreach (var a in aSet)
            {
                var right = bSet.GetViewBetween(a, int.MaxValue).Min;
                var left = bSet.GetViewBetween(0, a).Max;

                if (bHashSet.Contains(right))
                {
                    ans = Math.Min(ans, Math.Abs(right - a));
                }


                if (bHashSet.Contains(left))
                {
                    ans = Math.Min(ans, Math.Abs(left - a));
                }
            }

            Console.WriteLine(ans);
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