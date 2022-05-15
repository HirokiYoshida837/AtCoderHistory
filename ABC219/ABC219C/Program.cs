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

namespace ABC219C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = ReadValue<string>().ToCharArray().ToList();
            var n = ReadValue<int>();
            var sList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();

            // うまくcomparatorつくれなさそう、、、。別の値に変換する方針でいく。
            var to = new int[26];
            for (int i = 0; i < 26; i++)
            {
                to[x[i] - 'a'] = (char) (i);
            }

            var enumerable = sList.Select(item =>
            {
                var array = new string(item.Select(item2 => (char) ('a' + to[item2 - 'a'])).ToArray());
                return array;
            }).ToArray();
            
            var sorted = enumerable.OrderBy(item => item).ToList();

            foreach (var s in sorted)
            {
                var s1 = new string(s.Select(e => (char) x[e - 'a']).ToArray());
                Console.WriteLine(s1);
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