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

namespace ABC219D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            var (x, y) = ReadValue<int, int>();
            (int a, int b)[] abList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            if (abList.Select(x => x.a).Sum() < x || abList.Select(x => x.b).Sum() < y)
            {
                Console.WriteLine("-1");
                return;
            }

            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }


            var dp = new int[n + 1][,];
            for (var i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[x + 10, y + 10];

                for (int jx = 0; jx < x + 10; jx++)
                {
                    for (int jy = 0; jy < y + 10; jy++)
                    {
                        dp[i][jx, jy] = -1;
                    }
                }
            }

            dp[0][0, 0] = 0;
            dp[1][Math.Min(abList[0].a, x), Math.Min(abList[0].b, y)] = 1;
            dp[1][0, 0] = 0;

            // 配るDP
            for (int i = 1; i < n; i++)
            {
                var bentoI = abList[i];

                for (int jx = 0; jx < x + 10; jx++)
                {
                    for (int jy = 0; jy < y + 10; jy++)
                    {
                        if (dp[i][jx, jy] == -1) continue;

                        // 買う場合の遷移
                        {
                            var targetX = Math.Min(x, jx + bentoI.a);
                            var targetY = Math.Min(y, jy + bentoI.b);

                            if (dp[i + 1][targetX, targetY] == -1)
                            {
                                dp[i + 1][targetX, targetY] = Math.Max(dp[i + 1][targetX, targetY], n);
                            }

                            dp[i + 1][targetX, targetY] = Math.Min(dp[i + 1][targetX, targetY], dp[i][jx, jy] + 1);
                        }

                        // 買わない場合の遷移
                        {
                            var targetX = Math.Min(x, jx);
                            var targetY = Math.Min(y, jy);

                            if (dp[i + 1][targetX, targetY] == -1)
                            {
                                dp[i + 1][targetX, targetY] = Math.Max(dp[i + 1][targetX, targetY], n);
                            }

                            dp[i + 1][targetX, targetY] = Math.Min(dp[i + 1][targetX, targetY], dp[i][jx, jy]);
                        }
                    }
                }
            }

            var doubles = dp.Last();
            var min = int.MaxValue;

            for (int jx = 0; jx < x + 10; jx++)
            {
                for (int jy = 0; jy < y + 10; jy++)
                {
                    if (jx < x || jy < y)
                    {
                        continue;
                    }

                    var d = dp.Last()[jx, jy];
                    if (d <= 0) continue;
                    min = Math.Min(min, d);
                }
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