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

namespace ABC283C
{
    public static class Program
    {
        // https://atcoder.jp/contests/abc283/tasks/abc283_c
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            
            
            
            // ランレングス圧縮。
            var sp = new List<(char, int)>();
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

            // Console.WriteLine(sp);

            var ans = 0;
            foreach (var (c,x) in sp)
            {
                if (c != '0')
                {
                    ans += x;
                }
                else
                {
                    
                    if (x%2==0)
                    {
                        ans += x / 2;

                    }
                    else
                    {
                        ans += x / 2;
                        ans += 1;
                    }
                    
                }
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