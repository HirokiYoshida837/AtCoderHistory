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

namespace ABC220B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var k = ReadValue<int>();
            var (a, b) = ReadValue<string, string>();

            if (k == 2 || k == 8)
            {
                Console.WriteLine(Convert.ToInt64(a,k) * Convert.ToInt64(b,k));
                return;
            }
            else if (k == 10)
            {
                Console.WriteLine(long.Parse(a) * long.Parse(b));
                return;
            }
            else
            {
                var a10 = toBase10(a, k);
                var b10 = toBase10(b, k);

                Console.WriteLine(a10 * b10);
            }
        }

        public static long toBase10(string a, int k)
        {
            var num = 0L;
            
            foreach (var c1 in a.ToCharArray())
            {
                num *= k;
                num += c1 - '0';
            }

            return num;
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