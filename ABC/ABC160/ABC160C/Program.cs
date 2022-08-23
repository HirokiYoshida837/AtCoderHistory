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

namespace ABC160C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (k, n) = ReadValue<int,int>();
            var aList = ReadList<int>().ToArray();

            if (n == 2)
            {
                var m = aList[1] - aList[0];
                var l = n - m;

                Console.WriteLine(Math.Min(m,l));
                return;
            }
            
            
            // diffの最長を探す。
            var diffList = new List<long>();
            diffList.Add(k-aList.Last() + aList.First());
            for (int i = 1; i <n; i++)
            {
                diffList.Add(aList[i] - aList[i-1]);
            }

            var array = diffList.Select(x=>k-x).ToArray();
            Console.WriteLine(array.Min());
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