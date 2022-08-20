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

namespace Typical90_F
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var s = ReadValue<string>().ToCharArray().ToList();

            var lastIndex = 0;
            var list = new List<char>();

            // 合計でk個取る
            for (int i = 0; i < k; i++)
            {
                var min = 'z' + 1;
                var minIndex = int.MaxValue / 2;
                
                // 先頭からn-(k-すでに取った数の分) の文字だけで考える。
                for (int j = lastIndex; j <= n - (k - i); j++)
                {
                    if (min > s[j])
                    {
                        min = s[j];
                        minIndex = j;
                    }
                }

                list.Add((char) min);
                lastIndex = minIndex + 1;
            }

            var s2 = new string(list.ToArray());
            Console.WriteLine(s2);
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