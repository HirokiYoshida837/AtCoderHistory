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

namespace Easy_022
{
    // https://atcoder.jp/contests/agc027/tasks/agc027_a
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, x) = ReadValue<int, long>();
            var aList = ReadList<long>().ToArray();

            // greedyにやってみたらいけそうな気がするが
            if (aList.All(item=>item>x))
            {
                Console.WriteLine(0);
                return;
            }

            if (aList.Sum() == x)
            {
                Console.WriteLine(n);
                return;
            }

            var rem = x;
            var count = 0;

            var nokoru = true;
            
            foreach (var a in aList.OrderBy(x => x))
            {
                if (a <= rem)
                {
                    rem -= a;
                    count++;
                }
                else
                {
                    nokoru = false;
                    break;
                }
            }

            // 配りきれなかった場合は、最後の人に押し付けるので -1 になる。
            if (nokoru)
            {
                count--;
            }

            Console.WriteLine(count);
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