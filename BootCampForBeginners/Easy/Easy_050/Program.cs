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

namespace Easy_050
{
    // https://atcoder.jp/contests/abc059/tasks/abc059_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var a = ReadValue<string>();
            var b = ReadValue<string>();

            if (a.Length > b.Length)
            {
                Console.WriteLine("GREATER");
            }
            else if (a.Length < b.Length)
            {
                Console.WriteLine("LESS");
            }
            else
            {
                if (a == b)
                {
                    Console.WriteLine("EQUAL");
                    return;
                }

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] - '0' > b[i] - '0')
                    {
                        Console.WriteLine("GREATER");
                        return;
                    }
                    else if (a[i] - '0' < b[i] - '0')
                    {
                        Console.WriteLine("LESS");
                        return;
                    }
                    else
                    {
                        continue;
                    }
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