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

namespace ABC049C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            var available = new string[] {"dream", "dreamer", "erase", "eraser"};

            // available = available.Select(x => x.Reverse().ToArray())
            //     .Select(x => new string(x))
            //     .ToArray();
            //
            // s = new string(s.Reverse().ToArray());


            while (true)
            {
                if (s.Length == 0)
                {
                    break;
                }

                var trimmed = false;
                foreach (var item in available)
                {
                    if (s.EndsWith(item))
                    {
                        s = s.Remove(s.Length - item.Length, item.Length);
                        trimmed = true;
                        break;
                    }
                }

                if (!trimmed)
                {
                    // ダメだった場合はreturn 
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
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