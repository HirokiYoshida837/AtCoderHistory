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

namespace ABC183D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, w) = ReadValue<int, long>();

            (long s, long t, long p)[] stp = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long, long>())
                .ToArray();

            var list = stp.Select(x=>new List<(long,long)>(){(x.s, x.p), (x.t, -x.p)})
                .SelectMany(x=>x)
                .GroupBy(x=>x.Item1)
                .OrderBy(x=>x.Key)
                .Select(x=>x.Select(x=>x.Item2).Sum())
                .ToList();

            var sum = 0L;
            foreach (var l in list)
            {
                sum += l;
                if (sum > w)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
            
            
            //
            //
            //
            // List<(long ev, long val)> sEvent = stp.Select(x => (x.s, x.p))
            //     // .OrderBy(x => x.s)
            //     .ToList();
            //
            // List<(long ev, long val)> tEvent = stp.Select(x => (x.t, -x.p))
            //     // .OrderBy(x => x.t)
            //     .ToList();
            //
            // sEvent.AddRange(tEvent);
            // var dic = sEvent.OrderBy(x => x.ev)
            //     .GroupBy(x => x.ev)
            //     .ToList();
            //
            //
            // var currentTime = 0L;
            // var water = 0L;
            // foreach (var item in dic)
            // {
            //     var sum = item.Select(x => x.val).Sum();
            //
            //     water += sum;
            //     if (water > w)
            //     {
            //         Console.WriteLine("No");
            //         return;
            //     }
            //
            //     currentTime = item.Key;
            // }
            //
            // Console.WriteLine("Yes");
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