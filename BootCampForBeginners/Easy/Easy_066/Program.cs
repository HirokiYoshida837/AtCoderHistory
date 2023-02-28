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

namespace Easy_066
{
    // https://atcoder.jp/contests/agc003/tasks/agc003_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var str = ReadValue<string>();

            var n = 0;
            var w = 0;
            var s = 0;
            var e = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var c = str[i];

                if (c == 'N')
                {
                    n++;
                }
                else if (c == 'W')
                {
                    w++;
                }
                else if (c == 'S')
                {
                    s++;
                }
                else
                {
                    e++;
                }
            }

            if (n > 0)
            {
                if (s > 0)
                {
                    if (e >0 && w >0 || e ==0 && w == 0)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }
            else
            {
                if (s==0)
                {
                    if (e >0 && w >0 || e ==0 && w == 0)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
            }

            Console.WriteLine("No");
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