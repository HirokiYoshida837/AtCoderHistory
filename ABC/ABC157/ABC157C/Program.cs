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

namespace ABC157C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var scList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            if (n == 1)
            {
                for (int i = 0; i <= 9; i++)
                {
                    var str = i.ToString().Select(x => x - '0').ToArray();

                    var all = scList.Select(x => str[x.Item1 - 1] == x.Item2).All(x => x);
                    if (all)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }

                Console.WriteLine(-1);
            }
            else if (n == 2)
            {
                for (int i = 10; i <= 99; i++)
                {
                    var str = i.ToString().Select(x => x - '0').ToArray();

                    var all = scList.Select(x => str[x.Item1 - 1] == x.Item2).All(x => x);
                    if (all)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }

                Console.WriteLine(-1);
            }
            else
            {
                for (int i = 100; i <= 999; i++)
                {
                    var str = i.ToString().Select(x => x - '0').ToArray();

                    var all = scList.Select(x => str[x.Item1 - 1] == x.Item2).All(x => x);
                    if (all)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }

                Console.WriteLine(-1);
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