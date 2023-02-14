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

namespace Easy_003
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, a, b) = ReadValue<int, int, int>();
            var s = ReadValue<string>();

            var aList = new List<int>();
            var bList = new List<int>();
            var allList = new List<int>();

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == 'a')
                {
                    if (allList.Count < a + b)
                    {
                        Console.WriteLine("Yes");
                        allList.Add(i);
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                }
                else if (c == 'b')
                {
                    if (allList.Count < a + b)
                    {
                        if (bList.Count + 1 <= b)
                        {
                            Console.WriteLine("Yes");
                            allList.Add(i);
                        }
                        else
                        {
                            Console.WriteLine("No");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }
                    bList.Add(i);
                }
                else
                {
                    Console.WriteLine("No");
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