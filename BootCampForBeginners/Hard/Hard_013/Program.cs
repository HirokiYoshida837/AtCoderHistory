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

namespace Hard_013
{
    /// <summary>
    /// [D - Lucky PIN](https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_d)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var s = ReadValue<string>();

            var dic = s.Select((x, i) => (x, i))
                .GroupBy(x => x.x)
                .ToDictionary(x => x.Key, x => x.Select(x => x.i).OrderBy(x => x).ToList());

            var nextMemo = dic.Keys.ToDictionary(x => x, _ => Enumerable.Repeat(-1, s.Length).ToArray());

            foreach (var (k, _) in nextMemo)
            {
                if (dic.ContainsKey(k) && dic[k].Count > 0)
                {
                    var last = 0;
                    foreach (var i in dic[k])
                    {
                        while (i >= last)
                        {
                            nextMemo[k][last] = i;
                            last++;
                        }
                    }
                }
            }


            bool Check(string str)
            {
                var c0 = str[0];
                var c1 = str[1];
                var c2 = str[2];

                try
                {
                    if (nextMemo.ContainsKey(c0) && nextMemo.ContainsKey(c1) && nextMemo.ContainsKey(c2))
                    {
                        var x0 = nextMemo[c0][0];
                        var x1 = nextMemo[c1][x0 + 1];
                        var x2 = nextMemo[c2][x1 + 1];

                        if (x2 > x1 && x1 > x0 && x0 >= 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                return false;
            }


            var sum = 0L;

            for (int i = 0; i < 1000; i++)
            {
                var str = i.ToString().PadLeft(3, '0');


                if (Check(str))
                {
                    sum++;
                }
            }

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