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

namespace ABC164B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var a = abcd[0];
            var b = abcd[1];
            var c = abcd[2];
            var d = abcd[3];


            var count = 0L;

            while (true)
            {
                if (count % 2 == 0)
                {
                    c -= b;

                    if (c<=0)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                    
                }
                else
                {
                    a -= d;
                    
                    if (a<=0)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                count++;
            }
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