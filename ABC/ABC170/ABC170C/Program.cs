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

namespace ABC170C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (x, n) = ReadValue<int, int>();

            if (n == 0)
            {
                Console.WriteLine(x);
                return;
            }

            var pList = ReadList<int>().OrderBy(x => x).ToHashSet();

            var list = Enumerable.Range(-200, 400).Select(x => x)
                .Where(x => !pList.Contains(x))
                .Select(item => (item, Abs(item - x)))
                // 安定ソートなのでこれでいける。
                .OrderBy(x => x.Item2)
                .ToList();


            Console.WriteLine(list.First().item);

            // binarySearch使わなくても解ける

            // var binarySearchL = list.BinarySearch(x, new BinarySearchUtils.LowerBound<int>());
            // if (binarySearchL < 0) binarySearchL = ~binarySearchL;
            //
            // var binarySearchR = list.BinarySearch(x, new BinarySearchUtils.LowerBound<int>());
            // if (binarySearchR < 0) binarySearchR = ~binarySearchR;
            //
            // var l = list[binarySearchL-1];
            // var r = list[binarySearchR];
            //
            // if (Math.Abs(l-x) <= Math.Abs(r-x))
            // {
            //     Console.WriteLine(l);
            // }
            // else
            // {
            //     Console.WriteLine(r);
            // }
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


    /// <summary>
    /// C# Array.BinarySearch()に渡す
    ///
    ///    foreach (var b in bList)
    ///    {
    ///         var binarySearchA = aList.BinarySearch(b, new LowerBound<long>());
    ///         if (binarySearchA < 0) binarySearchA = ~binarySearchA;
    ///         var binarySearchC = cList.BinarySearch(b, new UpperBound<long>());
    ///         if (binarySearchC < 0) binarySearchC = ~binarySearchC;
    ///
    ///         ans += binarySearchA * (n - binarySearchC);
    ///    }
    /// 
    /// 
    /// </summary>
    public class BinarySearchUtils
    {
        /// <summary>
        /// ソート済Arrayを二部探索して、LowerBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getLowerBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 <= x.CompareTo(y) ? 1 : -1;
            }
        }

        /// <summary>
        /// ソート済Arrayを二部探索して、UpperBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getUpperBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class UpperBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 < x.CompareTo(y) ? 1 : -1;
            }
        }
    }
}