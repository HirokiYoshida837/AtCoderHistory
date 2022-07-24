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

namespace ABC223C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (double a, double b)[] ab = Enumerable.Range(0, n)
                .Select(_ => ReadValue<double, double>())
                .ToArray();

            // 全部が燃えるのにかかる時間を計算
            var timeSum = 0d;
            foreach (var (a, b) in ab)
            {
                var t = a / b;
                timeSum += t;
            }

            // 左端からうごくのは、Totalの半分の時間。
            timeSum /= 2;

            // 左側からシミュレーションしていく
            var l = 0d;
            foreach (var (a, b) in ab)
            {
                if (timeSum >= (a / b))
                {
                    timeSum -= (a / b);
                    l += a;
                }
                else
                {
                    l += b * timeSum;
                    break;
                }
            }

            Console.WriteLine(l);
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