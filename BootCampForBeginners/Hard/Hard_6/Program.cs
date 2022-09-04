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

namespace Hard_6
{
    /// <summary>
    /// [C - Dubious Document 2](https://atcoder.jp/contests/abc076/tasks/abc076_c)
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            var t = ReadValue<string>();


            if (s.Contains(t))
            {
                var replace = s.Replace('?', 'a');
                Console.WriteLine(replace);
                return;
            }

            var dic = new Dictionary<int, string>();
            
            // tの文字数で取れるところを全パターン試す
            for (var i = 0; i < s.Length - t.Length + 1; i++)
            {
                dic.Add(i, s.Substring(i, t.Length));
            }
            
            
            
            
            
            // tの先頭の文字を含む場所と、?がt文字以上並んでいる箇所を探す
            // for (var i = 0; i < s.Length - t.Length + 1; i++)
            // {
            //     if (s[i] == t[0])
            //     {
            //         dic.Add(i, s.Substring(i, t.Length));
            //     }
            //     else if (s[i] == '?')
            //     {
            //         var sub = s.Substring(i, t.Length);
            //         if (sub.All(x => x == '?'))
            //         {
            //             dic.Add(i, sub);
            //         }
            //     }
            // }

            // for (var i = 0; i < t.Length; i++)
            // {
            //     for (var j = i; j < s.Length - (t.Length - i) + 1; j++)
            //     {
            //         if (s[j] == t[i])
            //         {
            //             dic.Add(j - i, s.Substring(j - i, t.Length));
            //         }
            //         else if (s[j] == '?')
            //         {
            //             var sub = s.Substring(j - i, t.Length);
            //             if (sub.All(x => x == '?'))
            //             {
            //                 dic.Add(j - i, sub);
            //             }
            //         }
            //     }
            // }


            // 後ろから

            var reptarget = (-1, "");

            foreach (var (key, value) in dic.OrderByDescending(x => x.Key))
            {
                if (value.All(x => x == '?'))
                {
                    reptarget = (key, value);
                    break;
                }


                var flag = true;
                for (var i = 0; i < value.Length; i++)
                {
                    if (value[i] == '?')
                    {
                        continue;
                    }

                    if (value[i] != t[i])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    reptarget = (key, value);
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (reptarget == (-1, ""))
            {
                Console.WriteLine("UNRESTORABLE");
                return;
            }


            var repS = s.ToCharArray();

            for (var i = 0; i < t.Length; i++)
            {
                repS[reptarget.Item1 + i] = t[i];
            }

            var replace1 = new string(repS).Replace('?', 'a');
            Console.WriteLine(replace1);
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