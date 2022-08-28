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

namespace ABC266E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            if (n == 1)
            {
                Console.WriteLine("3.5");
                return;
            }

            var list = new List<double>();
            list.Add(3.5);

            for (int i = 2; i <= n; i++)
            {
                var lastE = list.Last();

                var sum = 0d;
                // 1 ～ 6まで
                for (int v = 1; v <= 6; v++)
                {
                    if (v < lastE)
                    {
                        sum += lastE;
                    }
                    else
                    {
                        sum += v;
                    }
                }

                var e = sum / 6;
                list.Add(e);
            }

            Console.WriteLine(list.Last());
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