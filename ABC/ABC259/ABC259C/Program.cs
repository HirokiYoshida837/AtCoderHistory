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

namespace ABC259C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            var t = ReadValue<string>();

            if (s == t)
            {
                Console.WriteLine("Yes");
                return;
            }

            if (s.Length > t.Length)
            {
                Console.WriteLine("No");
                return;
            }
            

            // ランレングス圧縮

            var sp = new List<(char, int)>();
            {
                var last = s[0];
                var count = 1;
                for (var i = 1; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == last)
                    {
                        count++;
                    }
                    else
                    {
                        sp.Add((last, count));
                        last = c;
                        count = 1;
                    }
                }

                if (count > 0)
                {
                    sp.Add((last, count));
                }
            }

            var tp = new List<(char, int)>();
            {
                var last = t[0];
                var count = 1;
                for (var i = 1; i < t.Length; i++)
                {
                    var c = t[i];
                    if (c == last)
                    {
                        count++;
                    }
                    else
                    {
                        tp.Add((last, count));
                        last = c;
                        count = 1;
                    }
                }

                if (count > 0)
                {
                    tp.Add((last, count));
                }
            }


            // 圧縮結果がちがうのなら無理
            if (tp.Count != sp.Count)
            {
                Console.WriteLine("No");
                return;
            }

            // 圧縮結果がちがうのなら無理
            for (var i = 0; i < sp.Count; i++)
            {
                if (sp[i].Item1 != tp[i].Item1)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            
            // S側しか増やせないので、各要素についてtが多いのであれば無理
            for (var i = 0; i < sp.Count; i++)
            {
                if (sp[i].Item2 > tp[i].Item2)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            // 1の要素は増やせないので不一致なら無理
            for (var i = 0; i < sp.Count; i++)
            {
                if (sp[i].Item2 == 1)
                {
                    if (tp[i].Item2 != 1)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }

                if (tp[i].Item2 == 1)
                {
                    if (sp[i].Item2 != 1)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }


            Console.WriteLine("Yes");
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