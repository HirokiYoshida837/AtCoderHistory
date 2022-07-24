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

namespace ABC257D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var xypList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int, int>())
                .ToArray();

            var xyList = xypList.Select(x => (x.Item1, x.Item2))
                .ToArray();

            var pList = xypList.Select(x => x.Item3).ToArray();


            var all = new List<int>();

            var valueTuples = xyList.Select(x=>fun(x)).ToArray();
            var max = valueTuples.Max();
            var min = valueTuples.Min();
            
            

        }

        public static long manhattanD((int x1, int y1) p1, (int x2, int y2) p2)
        {
            var list = new List<int>();
            var x = 1;

            return chebyshevD(fun(p1), fun(p2));
        }

        public static long chebyshevD((int x1, int y1) p1, (int x2, int y2) p2)
        {
            // 各座標の差（の絶対値）の最大値を2点間の距離とする
            return Math.Max(Math.Abs(p2.x2 - p1.x1), Math.Abs(p2.y2 - p1.y1));
        }

        public static (int x, int y) fun((int x, int y) p1)
        {
            var (x, y) = p1;
            return (x - y, x + y);
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