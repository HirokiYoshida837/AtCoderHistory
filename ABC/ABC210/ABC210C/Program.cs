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

namespace ABC210C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var c = ReadList<int>().ToArray();

            // 出てくる数字の種類だけメモする。
            var dictionary = c.Distinct()
                .Select(x => new KeyValuePair<int, int>(x, 0))
                .ToDictionary(x => x.Key, x => x.Value);

            var ans = 0L;
            var count = 0L;
            var queue = new Queue<int>();
            // k個を先にqueに入れる
            for (int i = 0; i < k; i++)
            {
                var cv = c[i];
                queue.Enqueue(c[i]);
                // 入れながら入れた数をメモする。まだ入れたことがなかったらcountを増やす。
                if (dictionary[cv] == 0)
                {
                    count++;
                }

                dictionary[cv] += 1;

                ans = Math.Max(count, ans);
            }

            // kから順に尺取法？的に見ていく(一つ入れたら一つ出す）
            for (int i = k; i < n; i++)
            {
                var cv = c[i];

                var dequeue = queue.Dequeue();
                dictionary[dequeue] -= 1;
                if (dictionary[dequeue] == 0)
                {
                    count--;
                }

                queue.Enqueue(cv);
                if (dictionary[cv] == 0)
                {
                    count++;
                }

                dictionary[cv] += 1;

                ans = Math.Max(count, ans);
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