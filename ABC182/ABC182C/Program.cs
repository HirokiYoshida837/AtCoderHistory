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

namespace ABC182C
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var s = "001";
            var i1 = int.Parse(s);


            var n = ReadValue<string>();
            var k = n.Length;

            var min = long.MaxValue;
            var ans = false;

            for (int bit = 1; bit < 1 << k; bit++)
            {
                var tmp = Convert.ToString(bit, 2);

                var bitS = tmp.PadLeft(k, '0');

                var list = new List<char>();
                
                for (var i = 0; i < bitS.Length; i++)
                {
                    if (bitS[i] == '1')
                    {
                        list.Add(n[i]);
                    }
                }

                var tryParse = long.TryParse(list.ToArray(), out var outNum);
                if (tryParse && outNum%3 == 0)
                {
                    ans = true;
                    min = Math.Min(min, k - list.Count);
                }
            }

            if (ans)
            {
                Console.WriteLine(min);
            }
            else
            {
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