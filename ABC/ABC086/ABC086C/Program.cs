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

namespace ABC086C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (int t, int x, int y)[] txyList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int, int>())
                .ToArray();


            var currentTime = 0;
            (int x, int y) pos = (0, 0);

            foreach (var (t, x, y) in txyList)
            {
                var diffT = t - currentTime;

                // posと (x,y) のマンハッタン距離を求める
                var absX = Math.Abs(x - pos.x);
                var absY = Math.Abs(y - pos.y);

                var manhattanD = absX + absY;

                // マンハッタン距離が長すぎるのであればNo。
                if (manhattanD > diffT)
                {
                    Console.WriteLine("No");
                    return;
                }

                // まず対象地点までたどり着いてから、反復横跳びし続けるのを考えればよい。
                var remain = manhattanD - diffT;

                if (remain % 2 == 0)
                {
                    // okなので更新
                    currentTime = t;
                    pos = (x, y);
                }
                else
                {
                    Console.WriteLine("No");
                    return;
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