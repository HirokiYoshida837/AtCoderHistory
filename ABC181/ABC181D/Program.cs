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

namespace ABC181D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            if (s.Length == 1)
            {
                Console.WriteLine(int.Parse(s) % 8 == 0 ? "Yes" : "No");
                return;
            }

            if (s.Length == 2)
            {
                var s1 = int.Parse($"{s[0]}{s[1]}");
                var s2 = int.Parse($"{s[1]}{s[0]}");

                if (s1 %8 == 0 || s2 %8 == 0)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
                
                return;
                
            }

            // 8の倍数は下3ケタで判定できるはず。

            var eightDic = new HashSet<int>();
            for (int i = 1; i < 1000; i++)
            {
                if (i % 8 == 0) eightDic.Add(i);
            }

            var sDic = new Dictionary<int, int>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i] - '0';
                if (!sDic.TryAdd(c, 1))
                {
                    sDic[c] += 1;
                }
            }

            // sDicを使って、組み立てられるかを全部確認する

            foreach (var eightDicItem in eightDic)
            {
                var padLeft = eightDicItem.ToString().PadLeft(3, '0');

                var c = new Dictionary<int, int>();
                for (var i = 0; i < padLeft.Length; i++)
                {
                    if (!c.TryAdd(padLeft[i]-'0', 1))
                    {
                        c[padLeft[i]-'0'] += 1;
                    }
                }

                var constructable = true;
                foreach (var keyValuePair in c)
                {
                    if (sDic.ContainsKey(keyValuePair.Key))
                    {
                        constructable &= sDic[keyValuePair.Key] >= keyValuePair.Value;
                    }
                    else
                    {
                        constructable = false;
                    }
                }

                if (constructable)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
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