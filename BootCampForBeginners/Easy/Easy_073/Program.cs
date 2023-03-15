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

namespace Easy_073
{
    // https://atcoder.jp/contests/agc021/tasks/agc021_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<string>();

            if (n.Length < 2)
            {
                var item = int.Parse(n);
                Console.WriteLine(item);
                return;
            }

            if (n.All(x => x == '9'))
            {
                Console.WriteLine(9 * n.Length);
                return;
            }


            if (n[0] == '1')
            {
                if (n.Skip(1).All(x => x == '9'))
                {
                    Console.WriteLine((n.Length - 1) * 9 + (n[0] - '0'));
                    return;
                }
                else
                {
                    Console.WriteLine((n.Length - 1) * 9);
                    return;
                }
            }
            else
            {
                if (n.Skip(1).All(x => x == '9'))
                {
                    Console.WriteLine((n.Length - 1) * 9 + (n[0] - '0'));
                    return;
                }
                else
                {
                    var value = (n.Length - 1) * 9 + ((n[0] - '0') - 1);
                    Console.WriteLine(value);
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