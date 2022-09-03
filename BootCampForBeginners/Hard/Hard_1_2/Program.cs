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

namespace Hard_1_2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // ダブリングで解く
            var s = ReadValue<string>();

            // 2^i回移動した先をdpテーブルで持つ
            var dp = new int[33][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[s.Length];
            }

            // 2^0
            for (var i = 0; i < s.Length; i++)
            {
                // Lの場合は左移動
                if (s[i] == 'L')
                {
                    dp[0][i] = i - 1;
                }
                else
                {
                    dp[0][i] = i + 1;
                }
            }

            for (var i = 1; i < dp.Length; i++)
            {
                for (var x = 0; x < dp[i].Length; x++)
                {
                    dp[i][x] = dp[i - 1][dp[i - 1][x]];
                }
            }


            // 偶数回の移動なので2^32後とかにしておく。
            var dictionary = dp[32].Select((x,i)=>(x,i)).GroupBy(x=>x.x)
                .ToDictionary(x=>x.Key, x=>x.Count());


            for (int i = 0; i < s.Length; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i,0);
                }
            }


            var join1 = String.Join(' ', dictionary.OrderBy(x=>x.Key).Select(x=>x.Value));
            Console.WriteLine(join1);
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