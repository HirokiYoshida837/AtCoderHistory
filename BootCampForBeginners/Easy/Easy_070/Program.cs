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

namespace Easy_070
{
    // https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_c
    public static class Program
    {
        public static void Main(string[] args)
        {
            // 1 個 100 円のおにぎり
            // 1 個 101 円のサンドイッチ
            // 1 個 102 円のクッキー
            // 1 個 103 円のケーキ
            // 1 個 104 円の飴
            // 1 個 105 円のパソコン

            var x = ReadValue<int>();

            if (x % 100 == 0 || x % 101 == 0 || x % 102 == 0 || x % 103 == 0 || x % 105 == 0)
            {
                Console.WriteLine(1);
                return;
            }

            if (x < 100)
            {
                Console.WriteLine(0);
                return;
            }


            // 何個買うか
            var n = x / 100;
            var mod = x % 100;


            // 0,1,2,3,4,5 を n個組み合わせて mod の数を作れるかどうか

            for (int a = 0; a <= n; a++)
            {
                for (int b = 0; a + b <= n; b++)
                {
                    if (a * 5 + b * 4 > mod)
                    {
                        break;
                    }

                    for (int c = 0; a + b + c <= n; c++)
                    {
                        if (a * 5 + b * 4 + c * 3 > mod)
                        {
                            break;
                        }

                        for (int d = 0; a + b + c + d <= n; d++)
                        {
                            if (a * 5 + b * 4 + c * 3 + d * 2 > mod)
                            {
                                break;
                            }

                            for (int e = 0; a + b + c + d + e <= n; e++)
                            {
                                if (a * 5 + b * 4 + c * 3 + d * 2 + e * 1 > mod)
                                {
                                    break;
                                }

                                var f = n - (a + b + c + d + e);

                                var num = (a * 5) + (b * 4) + (c * 3) + (d * 2) + (e * 1) + (f * 0);

                                if (num == mod)
                                {
                                    Console.WriteLine("1");
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("0");
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