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

namespace ABC250B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, a, b) = ReadValue<int, int, int>();

            var vMatrix = new int[n, n];

            var v = 1;

            for (int i = 0; i < n; i++)
            {
                vMatrix[0, i] = v;

                v *= -1;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    vMatrix[i, j] = vMatrix[i - 1, j] * -1;
                }
            }


            var ansMatrix = new List<char>();


            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < a; k++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        var rv = vMatrix[i, j];
                        var c = rv == 1 ? '.' : '#';
                        ansMatrix.AddRange(Enumerable.Repeat(c, b));
                    }
                }
            }

            var chunkSize = n * b;
            
            
            var chunks = ansMatrix.Select((v, i) => new { v, i })
                .GroupBy(x => x.i / chunkSize)
                .Select(g => g.Select(x => x.v));
            
            
            foreach (var enumerable in chunks)
            {
                var array = enumerable.ToArray();
                var s = new string(array);
                Console.WriteLine(s);
            }


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