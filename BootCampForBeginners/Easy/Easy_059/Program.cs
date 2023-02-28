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

namespace Easy_059
{
    // https://atcoder.jp/contests/abc104/tasks/abc104_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            bool check1()
            {
                return s[0] == 'A';
            }

            bool check2()
            {
                var count = 0;
                for (var i = 2; i < s.Length - 1; i++)
                {
                    if (s[i] == 'C')
                    {
                        count++;
                    }
                }

                return count == 1;
            }

            bool check3()
            {
                var count = s.Count(x => x >= 'a' && x <= 'z');

                if (count != s.Length - 2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (check1() && check2() && check3())
            {
                Console.WriteLine("AC");
            }
            else
            {
                Console.WriteLine("WA");
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