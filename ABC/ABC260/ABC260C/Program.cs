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

namespace ABC260C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, x, y) = ReadValue<int, int, int>();
            
            var ansList = new List<(string color, int level, long num)>();

            void DFS((string color, int level, long num) value)
            {

                if (value.level <= 1)
                {
                    ansList.Add(value);
                    return;
                }


                if (value.color == "red")
                {
                    DFS(("red", value.level-1, value.num));
                    DFS(("blue", value.level, value.num*x));
                }
                else
                {
                    DFS(("red", value.level-1, value.num));
                    DFS(("blue", value.level-1, value.num*y));
                }
            }
            
            
            DFS(("red", n, 1));

            var sum = ansList.Where(x=>x.color=="blue")
                .Sum(x=>x.num);

            Console.WriteLine(sum);
        }
        
        public struct Jewel
        {
            public string color;
            public int level;
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