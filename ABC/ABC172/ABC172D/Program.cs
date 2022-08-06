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

namespace ABC172D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m, k) = ReadValue<int, int, long>();
            var aList = ReadList<long>().ToArray();
            var bList = ReadList<long>().ToArray();


            var aCusum = new List<long>() {0};
            var bCusum = new List<long>() {0};

            foreach (var a in aList)
            {
                aCusum.Add(a + aCusum.Last());
            }

            foreach (var b in bList)
            {
                bCusum.Add(b + bCusum.Last());
            }

            var binarySearchA = aCusum.BinarySearch(k);
            if (binarySearchA < 0)
            {
                binarySearchA = ~binarySearchA;
                binarySearchA -= 1;
            }


            var maxCount = 0L;

            for (int i = binarySearchA; i >= 0; i--)
            {
                var remain = k - aCusum[i];

                var binarySearchB = bCusum.BinarySearch(remain);
                if (binarySearchB < 0)
                {
                    binarySearchB = ~binarySearchB;
                    binarySearchB -= 1;
                }

                maxCount = Math.Max(maxCount, i + binarySearchB);
            }

            Console.WriteLine(maxCount);
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