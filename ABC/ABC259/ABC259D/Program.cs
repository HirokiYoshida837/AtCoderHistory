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

namespace ABC259D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var st = Console.ReadLine().Split().Select(long.Parse).ToArray();
            (long x, long y) s = (st[0], st[1]);
            (long x, long y) t = (st[2], st[3]);

            var xyrList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long, long>())
                .Distinct()
                .ToArray();

            var startList = new HashSet<int>();
            for (var i = 0; i < xyrList.Length; i++)
            {
                var (x, y, r) = xyrList[i];
                var distDouble = calcDistDouble((x, y), (s.x, s.y));

                if (r * r == distDouble)
                {
                    startList.Add(i);
                }
            }

            var goalList = new HashSet<int>();
            for (var i = 0; i < xyrList.Length; i++)
            {
                var (x, y, r) = xyrList[i];
                var distDouble = calcDistDouble((x, y), (t.x, t.y));

                if (r * r == distDouble)
                {
                    goalList.Add(i);
                }
            }


            // 各円について事前に計算する
            var dic = Enumerable.Range(0, n)
                .Select(x => x)
                .ToDictionary(x => x, _ => new List<int>());


            for (var i = 0; i < xyrList.Length; i++)
            {
                (long x, long y, long r) from = xyrList[i];

                for (var j = i + 1; j < xyrList.Length; j++)
                {
                    (long x, long y, long r) to = xyrList[j];

                    // 座標が同じだった場合は円周は重ならないので計算しなくて良い
                    if (from.x == to.x && from.y == to.y)
                    {
                        continue;
                    }

                    var rSum = from.r + to.r;
                    var rSumDouble = rSum * rSum;

                    var distDouble = calcDistDouble((@from.x, @from.y), (@to.x, @to.y));

                    if (distDouble <= rSumDouble)
                    {
                        dic[i].Add(j);
                        dic[j].Add(i);
                    }
                }
            }


            // BFSしていく
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            foreach (var no in startList)
            {
                queue.Enqueue(no);
                visited.Add(no);
            }


            while (queue.Count > 0)
            {
                var from = queue.Dequeue();

                // 到達した
                if (goalList.Contains(from))
                {
                    Console.WriteLine("Yes");
                    return;
                }

                var ints = dic[from];
                foreach (var i in ints)
                {
                    if (!visited.Contains(i))
                    {
                        queue.Enqueue(i);
                        visited.Add(i);
                    }
                }
            }

            Console.WriteLine("No");
        }

        public static long calcDistDouble((long x, long y) a, (long x, long y) b)
        {
            var sq = (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);

            return sq;

            // var sqrt = Math.Sqrt(aX);
            // return sqrt;
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