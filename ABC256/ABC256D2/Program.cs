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

namespace ABC256D2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            solve1();
        }

        public static void solve1()
        {
            var n = ReadValue<int>();
            var lrList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // snuke Prime を参考に、いもす法
            var events = new List<(int t, int v)>();

            var l = lrList.Select(x => x.Item1)
                .Select(x => (x, 1))
                .ToList();

            var r = lrList.Select(x => x.Item2)
                .Select(x => (x, -1))
                .ToList();

            events.AddRange(l);
            events.AddRange(r);

            // 安定ソートなのでこの書き方でもいける。
            // 成功する。（先にl側をaddしてるので、、10-20, 20-30 のようなときでも 20のときに0判定されない）
            // 各イベント毎で先に累積和取ったほうが安心。
            events = events.OrderBy(x => x.t).ToList();

            var memo = new List<int>();

            var current = 0L;
            foreach (var (t, v) in events)
            {
                if (current == 0)
                {
                    memo.Add(t);
                }

                current += v;

                if (current == 0)
                {
                    memo.Add(t);
                }
            }


            for (var i = 0; i < memo.Count; i += 2)
            {
                var lv = memo[i];
                var rv = memo[i + 1];

                Console.WriteLine($"{lv} {rv}");
            }
        }

        public static void solve2()
        {
            var n = ReadValue<int>();
            var lrList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // snuke Prime を参考に、いもす法
            var events = new List<(int t, int v)>();

            var l = lrList.Select(x => x.Item1)
                .Select(x => (x, 1))
                .ToList();

            var r = lrList.Select(x => x.Item2)
                .Select(x => (x, -1))
                .ToList();

            var eventsDic = new Dictionary<int, int>();

            foreach (var (t, v) in l)
            {
                eventsDic.TryAdd(t, 0);
            }

            foreach (var (t, v) in r)
            {
                eventsDic.TryAdd(t, 0);
            }

            foreach (var (t, v) in l)
            {
                eventsDic[t] += v;
            }

            foreach (var (t, v) in r)
            {
                eventsDic[t] += v;
            }

            var cum = new List<(int, int)> {(0, 0)};
            var memo = new List<int>();

            // 累積和とりながら、 0 -> 1の立ち上がりタイミングと、 1 -> 0 の立ち下がりタイミングを探す。
            foreach (var (t, v) in eventsDic.OrderBy(x => x.Key))
            {
                if (v == 0)
                {
                    continue;
                }

                if (cum.Last().Item2 == 0 && v > 0)
                {
                    memo.Add(t);
                }


                cum.Add((t, cum.Last().Item2 + v));

                if (cum.Last().Item2 == 0)
                {
                    memo.Add(t);
                }
            }

            for (var i = 0; i < memo.Count; i += 2)
            {
                var lv = memo[i];
                var rv = memo[i + 1];

                Console.WriteLine($"{lv} {rv}");
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