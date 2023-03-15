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

namespace Easy_086
{
    // https://atcoder.jp/contests/abc106/tasks/abc106_c
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            var k = ReadValue<long>();

            if (s.Length == 1)
            {
                Console.WriteLine(s);
                return;
            }

            if (k == 1)
            {
                Console.WriteLine(s[0]);
                return;
            }
            
            // k文字目まで1だったら
            
            
            
            
            // ランレングス圧縮
            var sp = new List<(char, long)>();
            {
                var last = s[0];
                var count = 1;
                for (var i = 1; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == last)
                    {
                        count++;
                    }
                    else
                    {
                        sp.Add((last, count));
                        last = c;
                        count = 1;
                    }
                }

                if (count > 0)
                {
                    sp.Add((last, count));
                }
            }

            if (sp[0].Item1 == '1' && sp[0].Item2 >= k)
            {
                Console.WriteLine(1);
                return;
            }


            if (s.ToCharArray().All(x=>x=='1'))
            {
                Console.WriteLine(1);
                return;
            }

            var first = s.First(x=>x!='1');
            Console.WriteLine(first);
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