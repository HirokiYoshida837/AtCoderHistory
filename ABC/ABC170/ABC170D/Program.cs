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

namespace ABC170D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToList();

            aList = aList.OrderBy(x => x).ToList();

            var dictionary = aList.GroupBy(x => x).ToDictionary(x => x.Key, x => x);

            var used = new HashSet<long>();

            var count = 0L;

            foreach (var a in aList)
            {
                var flag = true;
                if (dictionary[a].Count() > 1)
                {
                    if (used.Contains(a))
                    {
                        continue;
                    }

                    flag = false;
                }


                foreach (var divisor in GetDivisors(a))
                {
                    if (used.Contains(divisor))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    count++;
                }

                used.Add(a);
            }

            Console.WriteLine(count);
        }

        public static IEnumerable<long> GetDivisors(long num)
        {
            if (num < 1) yield break;

            for (long i = 1; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    yield return i;
                    if (i * i != num) yield return (num / i);
                }
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