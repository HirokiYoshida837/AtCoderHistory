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

namespace ABC268C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var pList = ReadList<int>().ToList();

            var ans = new int[n];

            for (int i = 0; i < n; i++)
            {
                var a = n - i + pList[i];
                var b = n - i + pList[i] + 1;
                var c = n - i + pList[i] + 2;

                ans[a % n]++;
                ans[b % n]++;
                ans[c % n]++;
            }

            Console.WriteLine(ans.Max());

            //
            // pList.Add(pList[0]);
            // pList.Add(pList[1]);
            //
            // var count = 0L;
            // var max = 0L;
            // for (var i = 0; i < pList.Count-1; i++)
            // {
            //     if (Math.Abs(pList[i+1] - pList[i]) <= 2)
            //     {
            //         count++;
            //         max = Math.Max(max, count);
            //     }
            //     else
            //     {
            //         count = 0;
            //     }
            // }


            // var modified = pList.Select(x => x != 0 ? x : n).ToList();
            //
            // var countM = 0L;
            // var maxM = 0L;
            // for (var i = 0; i < modified.Count-1; i++)
            // {
            //     if (Math.Abs(modified[i+1] - modified[i]) <= 2)
            //     {
            //         countM++;
            //         maxM = Math.Max(maxM, countM);
            //     }
            //     else
            //     {
            //         countM = 0;
            //     }
            // }
            //
            //
            // Console.WriteLine(Math.Max(max, maxM));


            // var modified = new List<int>();
            // foreach (var i in pList)
            // {
            //     modified.Add(i);
            // }
            //
            // foreach (var i in pList)
            // {
            //     modified.Add(i);
            // }
            //
            // var enumerable = modified.Select(x => x + n).ToList();
            //
            // Console.WriteLine(enumerable);


            // pList.Add(pList[0]);
            // pList.Add(pList[1]);
            //
            // // for (int i = 1; i <= n; i++)
            // // {
            // //     var hl = i - 1;
            // //     var hm = i;
            // //     var hr = i + 1;
            // //
            // //     var pl = pList[hl] % n;
            // //     var pm = pList[hm] % n;
            // //     var pr = pList[hr] % n;
            // //
            // //
            // //     Console.WriteLine((pl, pm, pr));
            // // }
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