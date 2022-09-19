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

namespace ABC269E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            int Solve(bool vertical)
            {
                var lower = 1;
                var upper = n + 1;

                while (upper - lower > 1)
                {
                    var mid = (upper + lower) / 2;
                    var count = vertical ? Query(lower, mid-1, 1, n) : Query(1, n, lower, mid-1);
                    if ((mid - lower) > count)
                    {
                        upper = mid;
                    }
                    else
                    {
                        lower = mid;
                    }
                }

                return lower;
            }

            int Query(int a, int b, int c, int d)
            {
                Console.WriteLine($"? {a} {b} {c} {d}");

                var read = ReadValue<int>();

                if (read == -1)
                {
                    throw new Exception();
                }

                return read;
            }

            var ansX = Solve(true);
            var ansY = Solve(false);

            Console.WriteLine($"! {ansX} {ansY}");
            Console.WriteLine();
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