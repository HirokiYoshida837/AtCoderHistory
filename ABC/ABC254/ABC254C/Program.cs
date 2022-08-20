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
using Microsoft.VisualBasic;
using static System.Math;

namespace ABC254C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, k) = ReadValue<int, int>();
            var aList = ReadList<long>().ToArray();

            if (k == 1)
            {
                Console.WriteLine("Yes");
                return;
            }

            var sorted = aList.OrderBy(x => x).ToArray();
            var memo = new long[aList.Length];

            for (int b = 0; b < k; b++)
            {
                var ind = new List<long>();
                for (int i = b; i <n; i+=k)
                {
                    ind.Add(aList[i]);
                }

                ind = ind.OrderBy(x => x).ToList();
                
                // Linqでやると全要素見ないといけないので遅い。毎回 n/k要素だけ見れば済むようにする。
                // var ind = aList.Where((x, i) => i % k == b).OrderBy(x => x).ToArray();

                for (var i = 0; i < ind.Count; i++)
                {
                    memo[i * k + b] = ind[i];
                }
            }

            if (String.Join(',', sorted) == String.Join(',', memo))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
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