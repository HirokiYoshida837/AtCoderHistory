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

namespace Typical90_018
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var t = ReadValue<double>();
            var (l, x, y) = ReadValue<double, double, double>();
            var q = ReadValue<int>();
            var eList = Enumerable.Range(0, q)
                .Select(_ => ReadValue<double>())
                .ToArray();

            var z = 0d;

            // 各問題に答える
            foreach (var currentT in eList)
            {
                var theta = 2 * Math.PI * (currentT / t);
                var cx = 0d;
                var cy = (l / 2.0) * (-1.0 * Math.Sin(theta));
                var cz = (l / 2.0) * (-1.0 * Math.Cos(theta) + 1d);

                
                var d2 = (cx - x) * (cx - x) + (cy - y) * (cy - y) + (cz - z) * (cz - z);
                var h = cz;
                
                var rad = Math.Acos(h / Math.Sqrt(d2));
                
                double degrees = (180d / Math.PI) * rad;
                
                Console.WriteLine(90 - degrees);
            }
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