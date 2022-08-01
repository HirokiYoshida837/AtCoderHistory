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

namespace EDCP_F
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>();
            var t = ReadValue<string>();

            s = s.Insert(0, "-");
            t = t.Insert(0, "-");

            var dp = new long[s.Length, t.Length];

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 1; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1]+1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            var ans = new List<char>();
            // var maxLength = dp[s.Length, t.Length];


            var ix = s.Length-1;
            var jx = t.Length-1;

            // 経路復元
            while (true)
            {
                if (ix <= 0 || jx <= 0 || dp[ix, jx] == 0)
                {
                    break;
                }

                if (s[ix] == t[jx])
                {
                    // 左上に移動。
                    ans.Add(s[ix]);
                    ix--;
                    jx--;
                }
                else
                {
                    // 左側を確認
                    if (dp[ix - 1, jx] == dp[ix, jx])
                    {
                        ix--;
                        jx = jx;
                    }
                    else
                    {
                        // 上側に移動
                        ix = ix;
                        jx--;
                    }
                }
            }

            var array = ans.ToArray().Reverse().ToArray();

            Console.WriteLine(array);
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