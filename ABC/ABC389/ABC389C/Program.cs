using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC389C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var q = ReadValue<int>();

            var queries = Enumerable.Range(0, q)
                .Select(_ => ReadValue<string>())
                .Select(x =>
                {
                    if (x.StartsWith("2"))
                    {
                        return (2, -1L);
                    }
                    else
                    {
                        var sp = x.Split();
                        return (int.Parse(sp[0]), long.Parse(sp[1]));
                    }
                })
                .ToArray();

            var cum = new List<long> { 0 };
            var queue = new Queue<long>();

            var dequeuedSum = 0L;
            var dequeuedCount = 0;

            foreach (var (qt, v) in queries)
            {
                if (qt == 1)
                {
                    cum.Add(cum.Last() + v);
                    queue.Enqueue(v);
                }
                else if (qt == 2)
                {
                    var dequeue = queue.Dequeue();
                    dequeuedSum += dequeue;
                    dequeuedCount++;
                }
                else
                {
                    var pos = cum[(int)(v - 1) + dequeuedCount];
                    var ans = pos - dequeuedSum;
                    Console.WriteLine(ans);
                }

                // Console.WriteLine(String.Join(", ", cum));
            }
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2)),
                (T3)Convert.ChangeType(input[2], typeof(T3))
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
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}