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
using Microsoft.VisualBasic.CompilerServices;
using static System.Math;

namespace ABC263D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, l, r) = ReadValue<int, long, long>();
            var aList = ReadList<long>().ToArray();

            // 累積和を取る
            var cusum = new List<long>() {0};
            foreach (var a in aList)
            {
                cusum.Add(cusum.Last() + a);
            }

            // lでの累積和を計算する
            var cusumL = Enumerable.Range(0, cusum.Count).Select(x => x * l).ToList();
            var diffCum = Enumerable.Range(0, cusumL.Count).Select(x => cusum[x] - cusumL[x]).ToList();

            // 左からN個までの範囲だけをLで置き換えられるときの、減らせるスコア数の最大値。(=どこのマスまで選ぶか、を発展させて考える。)
            var dp = new long[diffCum.Count];

            dp[0] = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], diffCum[i]);
            }

            var min = long.MaxValue - 100;
            // rでの置き換え数を増やしながら探してみる。
            for (int RC = 0; RC <= n; RC++)
            {
                // rで置き換える前の残った範囲の合計。
                var valueSum = cusum[(cusum.Count - 1) - RC];

                // rで置き換えていない範囲に対して、ある範囲をLで置き換えたときに減らせる最大スコアをdpから取得。
                valueSum -= dp[(cusum.Count - 1) - RC];

                // 最終スコアは、左側 + Rの個数*r 
                var score = valueSum + RC * r;

                // 毎回更新。
                min = Math.Min(min, score);
            }

            Console.WriteLine(min);
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