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

namespace Easy_006
{
    // https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<long, long>();

            if (h == 1 || w == 1)
            {
                Console.WriteLine(1);
                return;
            }

            
            if (h % 2 == 0)
            {
                if (w % 2 == 0)
                {
                    Console.WriteLine(h * w / 2);
                }
                else
                {
                    Console.WriteLine(w * h / 2);
                }
            }
            else
            {
                if (w % 2 == 0)
                {
                    Console.WriteLine(h * w / 2);
                }
                else
                {
                    var ans = (w * h) / 2;
                    Console.WriteLine(ans + 1);
                }
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