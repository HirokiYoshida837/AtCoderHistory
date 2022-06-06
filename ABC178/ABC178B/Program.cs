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

namespace ABC178B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abcd = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var (a, b, c, d) = (abcd[0], abcd[1], abcd[2], abcd[3]);

            if (b <= 0)
            {
                if (d <= 0)
                {
                    Console.WriteLine(a * c);
                    return;
                }
                else if (c < 0 && 0 < d)
                {
                    Console.WriteLine(a * c);
                    return;
                }
                else
                {
                    Console.WriteLine(b * c);
                }
            }
            else if (a < 0 && 0 < b)
            {
                if (d <= 0)
                {
                    Console.WriteLine(a * c);
                }
                else if (c < 0 && 0 < d)
                {
                    Console.WriteLine(Math.Max(a * c, b * d));
                }
                else
                {
                    Console.WriteLine(b * d);
                }
            }
            else
            {
                if (d <= 0)
                {
                    Console.WriteLine(a * d);
                }
                else if (c < 0 && 0 < d)
                {
                    Console.WriteLine(b * d);
                }
                else
                {
                    Console.WriteLine(b * d);
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