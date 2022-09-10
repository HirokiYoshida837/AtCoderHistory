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

namespace Hard_020
{
    /// <summary>
    /// [C - ID](https://atcoder.jp/contests/abc113/tasks/abc113_c)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            var pyList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, long>())
                .ToArray();

            var ansMemo = pyList.ToDictionary(x => (x.Item1, x.Item2), _ => "");

            var dictionary = pyList.GroupBy(x => x.Item1)
                .ToDictionary(x => x.Key, x => x.Select(x => x.Item2).ToList());
            
            foreach (var (k, list) in dictionary)
            {

                var left = k.ToString().PadLeft(6, '0');
                foreach (var (v,index) in list.OrderBy(x=>x).Select((x,i)=>(x,i+1)))
                {
                    var right = index.ToString().PadLeft(6, '0');
                    ansMemo[(k, v)] = left+right;
                }
            }
            
            foreach (var (p,y) in pyList)
            {
                var s = ansMemo[(p, y)];
                Console.WriteLine(s);
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