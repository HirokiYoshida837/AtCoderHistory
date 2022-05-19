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

namespace ABC212B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var xs = Console.ReadLine();
            var x1 = xs[0] - '0';
            var x2 = xs[1] - '0';
            var x3 = xs[2] - '0';
            var x4 = xs[3] - '0';

            if (x1 == x2 && x2 == x3 && x3 == x4)
            {
                Console.WriteLine("Weak");
                return;
            }

            x1 += 3;
            x2 += 2;
            x3 += 1;
            x1 += 0;

            if (x1 >= 10) x1 %= 10;
            if (x2 >= 10) x2 %= 10;
            if (x3 >= 10) x3 %= 10;
            if (x4 >= 10) x4 %= 10;

            if (x1 == x2 && x2 == x3 && x3 == x4)
            {
                Console.WriteLine("Weak");
                return;
            }

            Console.WriteLine("Strong");
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