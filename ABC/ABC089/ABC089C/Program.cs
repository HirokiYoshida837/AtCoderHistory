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

namespace ABC089C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            var sList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<string>())
                .ToArray();

            var dic = new Dictionary<char, long>();
            
            foreach (var s in sList)
            {
                if (!(s.StartsWith('M') || s.StartsWith('A') || s.StartsWith('R') || s.StartsWith('C') ||
                     s.StartsWith('H')))
                {
                    continue;
                }

                var tryAdd = dic.TryAdd(s[0], 1);
                if (!tryAdd)
                {
                    dic[s[0]] += 1;
                }
            }

            var count = 0L;


            var array = dic.Select(x=>x.Value).ToArray();
            
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i+1; j < array.Length; j++)
                {
                    for (var k = j+1; k < array.Length; k++)
                    {
                        var l = array[i] * array[j] * array[k];
                        count += l;
                    }
                }
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