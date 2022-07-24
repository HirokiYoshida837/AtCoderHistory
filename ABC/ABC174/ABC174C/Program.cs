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

namespace ABC174C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var k = ReadValue<long>();
            
            if (k % 2 == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            
            // repunit/レピュニット数というらしい
            // s = (7 * 10^i - 7)/9

            var count = 0;
            var v = 0L;

            // ループにハマったらたどり着けないこと確定なので-1
            var visited = new HashSet<long>();
            
            while (true)
            {
                // mod k したものが 0 となるとき == kの倍数である
                v = f(v);
                var add = visited.Add(v);
                if (!add)
                {
                    Console.WriteLine(-1);
                    return;
                }

                count++;
                if (v == 0)
                {
                    break;
                }
            }

            Console.WriteLine(count);

            // 次の項目は、 10倍して + 7 したものになる。
            long f(long x)
            {
                return (((10 * x) % k) + 7) % k;
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