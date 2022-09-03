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

namespace Hard_1
{
    public static class Program
    {
        /// <summary>
        /// ABC136-D
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();

            var dic = new Dictionary<string, int>();

            var init = String.Join(',', Enumerable.Range(0, s.Length).Select(_ => 1));
            dic.Add(init, 0);

            var current = Enumerable.Range(0, s.Length).Select(_ => 1).ToArray();
            var currentS = init;
            for (int i = 1; i <= 2000; i++)
            {
                // 処理
                var next = new int[current.Length];
                for (var i2 = 0; i2 < current.Length; i2++)
                {
                    if (s[i2] == 'R')
                    {
                        next[i2 + 1] += current[i2];
                    }
                    else
                    {
                        next[i2 - 1] += current[i2];
                    }
                }

                var nextS = String.Join(',', next);

                if (dic.ContainsKey(nextS))
                {
                    break;
                }
                
                dic.Add(nextS, i);
                
                current = next;
                currentS = nextS;
            }

            // ループ開始時
            var i1 = dic[currentS];
            // ループ終わり
            var loopEnd = dic.Count;


            if (i1 % 2 == 0)
            {
                Console.WriteLine(currentS.Replace(',', ' '));
            }
            else
            {
                var keyValuePair = dic.Where(x=>x.Value == loopEnd-1).First();
                Console.WriteLine(keyValuePair.Key.Replace(',', ' '));
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