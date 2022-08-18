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

namespace ABC221D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (long a, long b)[] abList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long>())
                .ToArray();

            var aList = abList.Select(x => x.a).Select(x => (x, +1)).OrderBy(x => x.x).ToList();
            var bList = abList.Select(x => x.a + x.b - 1).Select(x => (x: x + 1, -1)).OrderBy(x => x.x).ToList();

            var events = new List<(long t, int num)>();

            events.AddRange(aList);
            events.AddRange(bList);
            events = events.OrderBy(x => x.t).ToList();

            var daily = events.GroupBy(x => x.t).Select(x => (x.Key, x.Select(y => y.num).Sum())).ToList();

            daily.Insert(0, (0, 0));
            var dic = Enumerable.Range(0, n+1).ToDictionary(x => x, _ => 0L);

            var playerCount = 0;
            var last = 0L;
            foreach (var valueTuple in daily.Skip(1))
            {
                dic[playerCount] += valueTuple.Key - last;
                playerCount += valueTuple.Item2;
                last = valueTuple.Key;
            }

            var join = String.Join(' ', dic.OrderBy(x=>x.Key).Skip(1).Select(x=>x.Value));
            Console.WriteLine(join);
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