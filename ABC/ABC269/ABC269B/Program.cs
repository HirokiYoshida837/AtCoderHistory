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

namespace ABC269B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = 10;

            var sList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();


            var a = -1;
            var b = -1;
            var c = -1;
            var d = -1;

            for (int i = 0; i < 10; i++)
            {
                if (sList[i].Contains('#'))
                {
                    var valueTuple = sList[i].Select((x, item) => (x, item)).First(x => x.x == '#').item;
                    a = i + 1;
                    c = valueTuple + 1;

                    break;
                }
            }


            for (var i = sList.Length - 1; i >= 0; i--)
            {
                if (sList[i].Contains('#'))
                {
                    var valueTuple = sList[i].Select((x, item) => (x, item)).Reverse().First(x => x.x == '#').item;
                    b = i + 1;
                    d = valueTuple + 1;
                    break;
                }
            }

            Console.WriteLine($"{a} {b}");
            Console.WriteLine($"{c} {d}");
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