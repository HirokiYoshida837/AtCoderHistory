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

namespace Hard_023
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<String>();

            var dreams = new string[] {"dream", "dreamer", "erase", "eraser"};

            // var left = new List<char>();
            // var current = s.ToList();
            //
            // bool isOK(List<char> l)
            // {
            //     if (l.Count < 5)
            //     {
            //         return false;
            //     }
            //
            //     return true;
            // }
            //
            //
            // while (true)
            // {
            //     {
            //         // dream
            //         var index = 0;
            //         if (isOK(current))
            //         {
            //             var array = current.Take(dreams[index].Length).ToArray();
            //             if (array[0] == dreams[index][0] && array[1] == dreams[index][1] &&
            //                 array[2] == dreams[index][3] &&
            //                 array[4] == dreams[index][4])
            //             {
            //                 left.AddRange(current.Take(array.Length));
            //                 current.RemoveRange(0, array.Length);
            //             }
            //         }
            //     }
            //     {
            //         // dreamer
            //         var index = 1;
            //         if (isOK(current))
            //         {
            //             var array = current.Take(dreams[index].Length).ToArray();
            //             if (array[0] == dreams[index][0] && array[1] == dreams[index][1] &&
            //                 array[2] == dreams[index][3] &&
            //                 array[4] == dreams[index][4] && array[5] == dreams[index][5])
            //             {
            //                 left.AddRange(current.Take(array.Length));
            //                 current.RemoveRange(0, array.Length);
            //             }
            //         }
            //     }
            //     {
            //         // erase
            //         var index = 2;
            //         if (isOK(current))
            //         {
            //             var array = current.Take(dreams[index].Length).ToArray();
            //             if (array[0] == dreams[index][0] && array[1] == dreams[index][1] &&
            //                 array[2] == dreams[index][3] &&
            //                 array[4] == dreams[index][4])
            //             {
            //                 left.AddRange(current.Take(array.Length));
            //                 current.RemoveRange(0, array.Length);
            //             }
            //         }
            //     }
            //     {
            //         // eraser
            //         var index = 3;
            //
            //         if (isOK(current))
            //         {
            //             var array = current.Take(dreams[index].Length).ToArray();
            //             if (array[0] == dreams[index][0] && array[1] == dreams[index][1] &&
            //                 array[2] == dreams[index][3] &&
            //                 array[4] == dreams[index][4] && array[5] == dreams[index][5])
            //             {
            //                 left.AddRange(current.Take(array.Length));
            //                 current.RemoveRange(0, array.Length);
            //             }
            //         }
            //     }
            // }


            // DFSする。 -> TLEとMLEしちゃった。
            void DFS(string current)
            {
                if (current.Length == 0)
                {
                    // GOTO面倒だから例外投げるとかいう最悪コード。
                    throw new Exception();
                }

                if (current.Length < 5)
                {
                    return;
                }

                foreach (var dream in dreams)
                {
                    if (current.StartsWith(dream))
                    {
                        var substring = new string(current.Skip(dream.Length).ToArray());
                        DFS(substring);
                    }
                }
            }

            try
            {
                DFS(s);
            }
            catch (Exception e)
            {
                Console.WriteLine("YES");
                return;
            }


            Console.WriteLine("NO");
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