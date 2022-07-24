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

namespace ABC249A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abcdefx = ReadList<int>().ToArray();

            var a = abcdefx[0];
            var b = abcdefx[1];
            var c = abcdefx[2];
            var d = abcdefx[3];
            var e = abcdefx[4];
            var f = abcdefx[5];
            var x = abcdefx[6];

            var takLen = 0;
            var aoLen = 0;

            for (int i = 0; i < x; i++)
            {
                if (i % (a+c) < a)
                {
                    takLen += b;
                }
                
                if (i % (d+f) < d)
                {
                    aoLen += e;
                }
            }

            if (takLen == aoLen)
            {
                Console.WriteLine("Draw");
                return;
            }

            if (takLen > aoLen)
            {
                Console.WriteLine("Takahashi");
            }
            else
            {
                Console.WriteLine("Aoki");
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