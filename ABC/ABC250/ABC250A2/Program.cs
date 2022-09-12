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

namespace ABC250A2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var (r, c) = ReadValue<int, int>();


            r -= 1;
            c -= 1;


            var matrix = new int[h][];
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[w];
            }


            var ans = 0;
            var m = new (int, int)[] {(-1, 0), (+1, 0), (0, -1), (0, +1)};
            
            foreach (var valueTuple in m)
            {
                try
                {
                    var v = matrix[r + valueTuple.Item1][c + valueTuple.Item2];
                    ans += 1;
                }
                catch (Exception e)
                {
                }
            }

            Console.WriteLine(ans);


            // if (h == 1)
            // {
            //     if (w == 1)
            //     {
            //         Console.WriteLine(0);
            //         return;
            //     }
            //
            //     if (w == 2)
            //     {
            //         Console.WriteLine(1);
            //         return;
            //     }
            //
            //     else
            //     {
            //         Console.WriteLine(2);
            //         return;
            //     }
            // }
            //
            // if (w == 1)
            // {
            //     if (h == 1)
            //     {
            //         Console.WriteLine(0);
            //         return;
            //     }
            //
            //     if (h == 2)
            //     {
            //         Console.WriteLine(1);
            //         return;
            //     }
            //
            //     else
            //     {
            //         Console.WriteLine(2);
            //         return;
            //     }
            // }
            //
            //
            // var ans = 0L;
            // if (r > 1 && r < h)
            // {
            //     ans += 2;
            // }
            // else
            // {
            //     ans += 1;
            // }
            //
            // if (c > 1 && c < w)
            // {
            //     ans += 2;
            // }
            // else
            // {
            //     ans += 1;
            // }
            //
            // Console.WriteLine(ans);
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