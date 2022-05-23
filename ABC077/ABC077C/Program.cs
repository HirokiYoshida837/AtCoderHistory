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

namespace ABC077C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();
            var aList = ReadList<long>().OrderBy(x => x).ToList();
            var bList = ReadList<long>().OrderBy(x => x).ToList();
            var cList = ReadList<long>().OrderBy(x => x).ToList();


            var ans = 0L;

            foreach (var b in bList)
            {
                var binarySearchA = aList.BinarySearch(b, new LowerBound<long>());
                if (binarySearchA < 0) binarySearchA = ~binarySearchA;
                var binarySearchC = cList.BinarySearch(b, new UpperBound<long>());
                if (binarySearchC < 0) binarySearchC = ~binarySearchC;

                ans += binarySearchA * (n - binarySearchC);
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


        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 <= x.CompareTo(y) ? 1 : -1;
            }
        }

        public class UpperBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 < x.CompareTo(y) ? 1 : -1;
            }
        }
    }
}