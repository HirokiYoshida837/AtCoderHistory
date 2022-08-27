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

namespace ABC266D2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (int t, int x, int a)[] txaList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int, int>())
                .ToArray();

            // // tを座標圧縮
            // var tDic = txaList.Select((x, i) => (x.t, i)).ToDictionary(x => x.i, x => x.t);

            var dic = txaList.ToDictionary(x => x.t, x => x);


            var tN = txaList.Last().t;


            var dp = new long[tN + 1][];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new long[5] {-1, -1, -1, -1, -1};
            }

            dp[0][0] = 0;

            // くばるDP
            for (var i = 0; i < dp.Length - 1; i++)
            {
                // if (dic.ContainsKey(i))
                // {
                //     var valueTuple = dic[i];
                //
                //     if (dp[i][valueTuple.x] >= 0)
                //     {
                //         dp[i][valueTuple.x] += valueTuple.a;
                //     }
                // }


                for (int x = 0; x < 4; x++)
                {
                    if (dp[i][x] < 0)
                    {
                        continue;
                    }

                    if (x > 0)
                    {
                        // var cv = dp[i][x];
                        // // 辿り着いた先にすぬけがいるのであれば、スコア加算。
                        // if (dic.ContainsKey(i + 1))
                        // {
                        //     var valueTuple = dic[i + 1];
                        //     if (valueTuple.x == x - 1)
                        //     {
                        //         cv += valueTuple.a;
                        //     }
                        // }

                        // dp[i + 1][x - 1] = Math.Max(dp[i + 1][x - 1], cv);
                        dp[i + 1][x - 1] = Math.Max(dp[i + 1][x - 1], 0);
                    }

                    {
                        // var cv = dp[i][x];
                        // // 辿り着いた先にすぬけがいるのであれば、スコア加算。
                        // if (dic.ContainsKey(i + 1))
                        // {
                        //     var valueTuple = dic[i + 1];
                        //     if (valueTuple.x == x)
                        //     {
                        //         cv += valueTuple.a;
                        //     }
                        // }

                        // dp[i + 1][x] = Math.Max(dp[i + 1][x], cv);
                        dp[i + 1][x] = Math.Max(dp[i + 1][x], 0);
                    }


                    if (x < 4)
                    {
                        // var cv = dp[i][x];
                        // // 辿り着いた先にすぬけがいるのであれば、スコア加算。
                        // if (dic.ContainsKey(i + 1))
                        // {
                        //     var valueTuple = dic[i + 1];
                        //     if (valueTuple.x == x + 1)
                        //     {
                        //         cv += valueTuple.a;
                        //     }
                        // }

                        dp[i + 1][x + 1] = Math.Max(dp[i + 1][x + 1], 0);
                    }
                }
            }

            Console.WriteLine(dp.Last().Max());
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