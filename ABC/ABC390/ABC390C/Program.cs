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

namespace ABC390C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();

            var s = Enumerable.Range(0, h).Select(_ => ReadValue<string>().ToList()).ToList();

            if (h == 1 && w == 1)
            {
                if (s[0][0] == '#' || s[0][0] == '?')
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

                return;
            }

            // #と#に挟まれている `?` は # に変換する。
            // 変換途中で、 `.` が含まれていたら、それはもうどうやっても無理なのでエラーにする

            // 横方向チェック
            for (int i = 0; i < h; i++)
            {
                if (s[i].Count(x => x == '#') < 2)
                {
                    continue;
                }


                var l = s[i].ToList().FindIndex(x => x == '#');
                var r = s[i].ToList().FindLastIndex(x => x == '#');

                var chars = s[i].Select((x, i) => (x, i)).Skip(l).Take(r - l + 1).ToList();

                if (chars.Any(x => x.x == '.'))
                {
                    Console.WriteLine("No");
                    return;
                }

                foreach (var valueTuple in chars)
                {
                    s[i][valueTuple.i] = '#';
                }
            }

            // 縦方向チェック
            for (int i = 0; i < w; i++)
            {
                var arr = s.Select(x => x[i]).ToArray();

                if (arr.Count(x => x == '#') < 2)
                {
                    continue;
                }

                var l = arr.ToList().FindIndex(x => x == '#');
                var r = arr.ToList().FindLastIndex(x => x == '#');

                var chars = arr.Select((x, i) => (x, i)).Skip(l).Take(r - l + 1).ToList();

                if (chars.Any(x => x.x == '.'))
                {
                    Console.WriteLine("No");
                    return;
                }

                foreach (var valueTuple in chars)
                {
                    s[valueTuple.i][i] = '#';
                }
            }

            // 一番左端の `#` のindex、一番右端の `#` のindexを調べる
            var mostLeftSharp = s.Select(x => x.FindIndex(x => x == '#')).Where(x => x != -1).Min();
            var mostRightSharp = s.Select(x => x.FindLastIndex(x => x == '#')).Where(x => x != -1).Max();

            // 一番上端の `#` のindex、一番下端の `#` のindexを調べる
            var mostTopSharp = s.FindIndex(x => x.Contains('#'));
            var mostBottomSharp = s.FindLastIndex(x => x.Contains('#'));


            // 各行に対して、mlsとmrsの間を `#` で塗りつぶせるかを確認する。
            // 塗りつぶせるのであれば、`#`で塗ってしまう。
            for (int i = mostTopSharp; i <= mostBottomSharp; i++)
            {
                var arr = s[i];
                var chars = arr.Skip(mostLeftSharp).Take(mostRightSharp - mostLeftSharp + 1).ToList();

                if (chars.Any(x => x == '.'))
                {
                    Console.WriteLine("No");
                    return;
                }

                for (int j = mostLeftSharp; j <= mostRightSharp; j++)
                {
                    if (s[i][j] == '?')
                    {
                        s[i][j] = '#';
                    }
                }
            }

            // 同じことを縦向きでもやる。
            for (int j = mostLeftSharp; j <= mostRightSharp; j++)
            {
                var arr = s.Select(x => x[j]).ToArray();
                var chars = arr.Skip(mostTopSharp).Take(mostBottomSharp - mostTopSharp + 1).ToList();

                if (chars.Any(x => x == '.'))
                {
                    Console.WriteLine("No");
                    return;
                }

                for (int i = mostTopSharp; i <= mostBottomSharp; i++)
                {
                    if (s[i][j] == '?')
                    {
                        s[i][j] = '#';
                    }
                }
            }

            // `#` で塗った範囲が長方形になっているか調べたい。
            var ansArray = s.Skip(mostTopSharp).Take(mostBottomSharp - mostTopSharp + 1).ToList();
            ansArray = ansArray
                .Select(x => x.Skip(mostLeftSharp).Take(mostRightSharp - mostLeftSharp + 1).ToList()).ToList();

            // foreach (var charse in ansArray)
            // {
            //     var s1 = new string(charse.ToArray());
            //     Console.WriteLine(s1);
            // }

            if (ansArray.All(x => x.All(y => y == '#')))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }


            // // h == 1 なら、 #の最初と最後をしらべて、その間に `.` があったらアウト
            // if (h == 1)
            // {
            //     var left = s[0].Select((x, i) => (x, i)).First(x => x.Item1 == '#' || x.Item1 == '?');
            //     var right = s[0].Select((x, i) => (x, i)).Last(x => x.Item1 == '#' || x.Item1 == '?');
            //
            //     // var takeWhile1 = new List<char>();
            //     // for (int i = left.i; i <= right.i; i++)
            //     // {
            //     //     takeWhile1.Add(s[0][i]);
            //     // }
            //
            //     var take = s[0].Skip(left.i).Take(right.i - left.i + 1).ToList();
            //
            //
            //     if (take.Contains('.'))
            //     {
            //         Console.WriteLine("No");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Yes");
            //     }
            //
            //     return;
            // }
            //
            // // w == 1 なら、 #の最初と最後をしらべて、その間に `.` があったらアウト
            // if (w == 1)
            // {
            //     var sArray = s.Select(x => x[0]).ToList();
            //
            //     var left = sArray.Select((x, i) => (x, i)).First(x => x.Item1 == '#' || x.Item1 == '?');
            //     var right = sArray.Select((x, i) => (x, i)).Last(x => x.Item1 == '#' || x.Item1 == '?');
            //
            //     var take = sArray.Skip(left.i).Take(right.i - left.i + 1).ToList();
            //
            //
            //     if (take.Contains('.'))
            //     {
            //         Console.WriteLine("No");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Yes");
            //     }
            //
            //     return;
            // }
            //
            // // 全部 ? か 全部 # なら Yesをだす
            // if (s.All(x => x.All(y => y == '#' || y == '?')))
            // {
            //     Console.WriteLine("Yes");
            //     return;
            // }
            //
            // // 全部 . なら Noを出す
            // if (s.All(x => x.All(y => y == '.')))
            // {
            //     Console.WriteLine("Yes");
            //     return;
            // }
            //
            // // メインの処理
            //
            // // 一番左上、一番右下を特定する
            // (int, int) GetLeftUpper()
            // {
            //     var upper = s.FindIndex(x => x.Contains('#') || x.Contains('?'));
            //     var left = s[upper].ToList().FindIndex(x => x == '#' || x == '?');
            //
            //     return (upper, left);
            // }
            //
            // (int, int) GetRightDown()
            // {
            //     var down = s.FindLastIndex(x => x.Contains('#') || x.Contains('?'));
            //     var right = s[down].ToList().FindLastIndex(x => x == '#' || x == '?');
            //
            //     return (down, right);
            // }
            //
            // Console.WriteLine(GetLeftUpper());
            // Console.WriteLine(GetRightDown());
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2)),
                (T3)Convert.ChangeType(input[2], typeof(T3))
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
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}