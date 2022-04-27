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

namespace ABC227B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var s = ReadList<int>();

            var list = new List<int>(s);

            var calc = new Func<int, int, int>((int a, int b) => 4 * a * b + 3 * a + 3 * b);

            for (int a = 1; a < 335; a++)
            {
                for (int b = 1; b < 335; b++)
                {
                    var i = calc(a, b);

                    list = list.Where(x => x != i).ToList();
                }
            }

            Console.WriteLine(list.Count);
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