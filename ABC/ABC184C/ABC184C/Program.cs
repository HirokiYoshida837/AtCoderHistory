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

namespace ABC184C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (r1, c1) = ReadValue<int, int>();
            var (r2, c2) = ReadValue<int, int>();

            var r = r2 - r1;
            var c = c2 - c1;

            // 0
            if (r == 0 && c == 0) Console.WriteLine(0);
            // 1
            else if (r == c || r == -c) Console.WriteLine(1);
            else if (Abs(r) + Abs(c) <= 3) Console.WriteLine(1);
            // 2
            else if (((r ^ c ^ 1) & 1) == 1) Console.WriteLine(2);
            else if (r == c || r == -c) Console.WriteLine(2);
            else if (Abs(r + c) <= 3 || Abs(r - c) <= 3) Console.WriteLine(2);
            // 3
            else Console.WriteLine(3);

            //
            //
            // if (r1 == r2 && c1 == c2)
            // {
            //     Console.WriteLine(0);
            //     return;
            // }
            //
            // // a+b=c+d
            // if (r1 + c1 == r2 + c2)
            // {
            //     Console.WriteLine(1);
            //     return;
            // }
            //
            // // a−b=c−d
            // if (r1 - c1 == r2 - c2)
            // {
            //     Console.WriteLine(1);
            //     return;
            // }
            //
            // // ∣a−c∣+∣b−d∣≤3 範囲内なら1手で
            // if (Math.Abs(r1 - r2) + Math.Abs(c1 - c2) <= 3)
            // {
            //     Console.WriteLine(1);
            //     return;
            // }
            //
            // // 2手
            //
            // // 斜め移動二回
            // if (calc(r1, c1) == calc(r2, c2))
            // {
            //     Console.WriteLine(2);
            //     return;
            // }
            //
            // // マンハッタン距離が6以下なら2手
            // if (Math.Abs(r1 - r2) + Math.Abs(c1 - c2) <= 6)
            // {
            //     Console.WriteLine(2);
            //     return;
            // }
            //
            // //斜め + マンハッタン3
            // if (Math.Abs((r1 + c1) - (r2 + c2)) <= 3)
            // {
            //     Console.WriteLine(2);
            //     return;
            // }
            //
            // //斜め + マンハッタン3
            // if (Math.Abs((r1 - c1) - (r2 - c2)) <= 3)
            // {
            //     Console.WriteLine(2);
            //     return;
            // }
            //
            // Console.WriteLine(3);
        }


        public static int calc(int x, int y)
        {
            return x % 2 + (y + 1) % 2;
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