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
using Microsoft.VisualBasic.CompilerServices;
using static System.Math;

namespace ABC263D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, l, r) = ReadValue<int, long, long>();
            var aList = ReadList<long>().ToArray();

            // if (l > 0)
            // {
            // 累積和を取る
            var cusum = new List<long>() {0};
            foreach (var a in aList)
            {
                cusum.Add(cusum.Last() + a);
            }

            cusum.RemoveAt(0);
            var averageFromLeft = cusum.Select((x, i) => Convert.ToDouble(x) / Convert.ToDouble(i + 1)).ToArray();

            var max = Convert.ToDouble(float.MinValue);
            var maxIndex = -1;
            for (int i = 0; i < averageFromLeft.Count(); i++)
            {
                if (max <= averageFromLeft[i])
                {
                    max = averageFromLeft[i];
                    maxIndex = i;
                }
            }

            if (max > l)
            {
                for (int i = 0; i <= maxIndex; i++)
                {
                    aList[i] = l;
                }
            }
            // }
            // else
            // {
            //     // 累積和を取る
            //     var cusum = new List<long>() {0};
            //     foreach (var a in aList)
            //     {
            //         cusum.Add(cusum.Last() + a);
            //     }
            //     
            //     cusum.RemoveAt(0);
            //     var averageFromLeft = cusum.Select((x, i) => Convert.ToDouble(x) / Convert.ToDouble(i + 1)).ToArray();
            //     
            //     
            //     
            //     
            // }

            var aListRev = aList.Reverse().ToList();

            // if (r > 0)
            // {
            // 累積和を取る
            var cusum2 = new List<long>() {0};
            foreach (var a in aListRev)
            {
                cusum2.Add(cusum2.Last() + a);
            }

            cusum2.RemoveAt(0);
            var averageFromRight = cusum2.Select((x, i) => Convert.ToDouble(x) / Convert.ToDouble(i + 1)).ToArray();

            var max2 = Convert.ToDouble(float.MinValue);
            var maxIndex2 = -1;
            for (int i = 0; i < averageFromRight.Count(); i++)
            {
                if (max2 <= averageFromRight[i])
                {
                    max2 = averageFromRight[i];
                    maxIndex2 = i;
                }
            }


            if (max2 > r)
            {
                for (int i = 0; i <= maxIndex2; i++)
                {
                    aListRev[i] = r;
                }
            }
            // }


            var sum = aListRev.Sum();
            Console.WriteLine(sum);
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