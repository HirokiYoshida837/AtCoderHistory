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

namespace ABC221C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<string>().ToCharArray().Select(char.ToString).Select(int.Parse).ToArray();

            var ans = 0L;

            // bit全探索
            for (int bit = 1; bit < 1 << n.Length-1; bit++)
            {
                var bitS = Convert.ToString(bit, 2).PadLeft(n.Length, '0');
                var l = new List<int>();
                var r = new List<int>();
                for (var i = 0; i < bitS.ToCharArray().Length; i++)
                {
                    var c = bitS[i];
                    if (c == '1')
                    {
                        l.Add(n[i]);
                    }
                    else
                    {
                        r.Add(n[i]);
                    }
                }

                var lc = long.Parse(new string(l.OrderByDescending(x => x).Select(x => (char) (x + '0')).ToArray()));
                var rc = long.Parse(new string(r.OrderByDescending(x => x).Select(x => (char) (x + '0')).ToArray()));

                ans = Math.Max(ans, lc * rc);
            }

            Console.WriteLine(ans);
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