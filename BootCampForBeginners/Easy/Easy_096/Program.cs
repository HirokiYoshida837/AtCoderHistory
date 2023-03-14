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

namespace Easy_096
{
    // https://atcoder.jp/contests/code-festival-2017-qualc/tasks/code_festival_2017_qualc_b
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var a = ReadList<int>().ToArray();


            // DFSでBit全探索的な
            // var array = Enumerable.Range(0, n).Select(x => new List<int>() {-1, 0, 1}).ToList();

            var count = 0L;
            
            foreach (var enumerable in Generate(new []{-1,0,1},n))
            {
                var array = enumerable.ToArray();
                var s = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    s.Add(array[i] + a[i]);
                }
                
                if (s.Count(x=>x%2 == 0) > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);

            // void dfs(int index, Stack<int> stack)
            // {
            //     foreach (var item in array[index])
            //     {
            //         stack.Push(item);
            //
            //         if (stack.Count == n)
            //         {
            //             var items = new List<int>();
            //             var i = 0;
            //             foreach (var i1 in stack)
            //             {
            //                 items.Add(a[i] + i1);
            //                 i++;
            //             }
            //
            //             if (items.Count(x => x % 2 == 0) > 0)
            //             {
            //                 count++;
            //             }
            //         }
            //         else
            //         {
            //             dfs(index + 1, stack);
            //         }
            //
            //         stack.Pop();
            //     }
            // }
            //
            // dfs(0, new Stack<int>());

            // Console.WriteLine(count);


            // // -1, 0, 1 のBit全探索的な
            // var bits = Enumerable.Range(0, n).Select(x => -1).ToArray();
            //
            // var count = 0L;
            // while (true)
            // {
            //     var calc = new int[n];
            //
            //     for (int i = 0; i < n; i++)
            //     {
            //         calc[i] = a[i] + bits[i];
            //     }
            //
            //     if (calc.Count(x => x % 2 == 0) > 0)
            //     {
            //         count++;
            //     }
            //
            //
            //     if (bits.All(x => x == 1))
            //     {
            //         break;
            //     }
            //
            //     // bitsの更新処理
            //     bits = getNextInt(bits);
            // }
            // Console.WriteLine(count);


            // var array = a.Select(x => x % 2 == 0).ToArray();
            //
            // var ints = array.Select(x => x ? 2 : 1).ToArray();
            //
            // var counts = 1L;
            // foreach (var i in ints)
            // {
            //     counts *= i;
            // }
            //
            // var max = 1L;
            // for (int i = 0; i < n; i++)
            // {
            //     max *= 3;
            // }
            //
            // Console.WriteLine(max - counts);
        }


        // https://blog.masuqat.net/2014/08/22/repeated-combination-with-yield-and-recursion-in-csharp/
        static IEnumerable<IEnumerable<T>> Generate<T>(IEnumerable<T> elements, int n) =>
            Generate<T>(elements, n, Enumerable.Empty<T>());

        static IEnumerable<IEnumerable<T>> Generate<T>(IEnumerable<T> elements, int n, IEnumerable<T> elementBase)
        {
            if (elementBase.Count() >= n)
            {
                yield return elementBase;
                yield break;
            }

            foreach (var e in elements)
            {
                foreach (var item in Generate(elements, n, new List<T>(elementBase) {e}))
                {
                    yield return item;
                }
            }
        }


        public static int[] getNextInt(int[] before)
        {
            var after = new int[before.Count()];

            for (var i = 0; i < before.Length; i++)
            {
                after[i] = before[i];
            }

            after[0] += 1;

            for (var i = 0; i < before.Length; i++)
            {
                if (after[i] > 1 && i + 1 < before.Length)
                {
                    after[i] = -1;
                    after[i + 1] += 1;
                }
            }

            return after;
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