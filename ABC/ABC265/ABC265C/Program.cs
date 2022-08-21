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

namespace ABC265C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();

            var grid = Enumerable.Range(0, h)
                .Select(_ => ReadValue<string>().ToCharArray())
                .ToArray();

            var visited = new HashSet<(int, int)>();
            visited.Add((0, 0));
            var last = (0, 0);
            var current = (0, 0);

            try
            {
                while (true)
                {
                    visited.Add(current);
                    var nextAdd = (0, 0);
                    if (grid[current.Item1][current.Item2] == 'U')
                    {
                        nextAdd = (-1, 0);
                    }
                    else if (grid[current.Item1][current.Item2] == 'D')
                    {
                        nextAdd = (+1, 0);
                    }
                    else if (grid[current.Item1][current.Item2] == 'L')
                    {
                        nextAdd = (0, -1);
                    }
                    else
                    {
                        nextAdd = (0, +1);
                    }

                    var next = (current.Item1 + nextAdd.Item1, current.Item2 + nextAdd.Item2);
                    // ループしたら抜ける
                    if (visited.Contains(next))
                    {
                        break;
                    }
                    
                    // 移動できるかどうか確認する
                    var v = grid[next.Item1][next.Item2]; 

                    last = next;
                    current = next;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{last.Item1+1} {last.Item2+1}");
                return;
            }

            Console.WriteLine(-1);
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