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

namespace ABC167C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m, x) = ReadValue<int, int, int>();

            var read = Enumerable.Range(0, n)
                .Select(_ =>
                {
                    var aList = ReadList<int>().ToList();

                    var c = aList.First();
                    aList.RemoveAt(0);

                    return (c, aList);
                }).ToList();


            var cList = read.Select(x => x.c).ToList();
            var aMatrix = read.Select(x => x.aList).ToList();


            var costMin = long.MaxValue;
            // bit全探索か

            for (int bit = 1; bit < 1 << n; bit++)
            {
                var bitS = Convert.ToString(bit, 2).PadLeft(n, '0');

                var rikaido = new long[m];
                var cost = 0L;

                for (var i = 0; i < bitS.Length; i++)
                {
                    var c = bitS[i];
                    if (c == '1')
                    {
                        cost += cList[i];
                        for (var i1 = 0; i1 < aMatrix[i].Count; i1++)
                        {
                            rikaido[i1] += aMatrix[i][i1];
                        }
                    }
                }

                if (rikaido.All(val=>val>=x))
                {
                    costMin = Math.Min(costMin,cost);
                }
            }


            if (costMin == long.MaxValue)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(costMin);
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