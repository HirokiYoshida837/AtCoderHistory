﻿using System;
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

namespace Easy_013
{
    // https://atcoder.jp/contests/agc014/tasks/agc014_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b, c) = ReadValue<long, long, long>();


            static long calc(long l, long r)
            {
                return (l + r) / 2;
            }
            
            
            if (a % 2 == 1 || b % 2 == 1 || c % 2 == 1)
            {
                Console.WriteLine(0);
                return;
            }

            if (a == b && b == c)
            {
                Console.WriteLine(-1);
                return;
            }

            var count = 0;
            var (l, m, r) = (a, b, c);
            while (true)
            {
                count++;

                (l, m, r) = (calc(m, r), calc(l, r), calc(l, m));

                // Console.WriteLine($"{l} {m} {r}");


                if (l % 2 == 1 || m % 2 == 1 || r % 2 == 1)
                {
                    Console.WriteLine(count);
                    return;
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