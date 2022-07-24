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

namespace ABC249D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();

            // 使える数のリストと個数をメモ
            var hashSet = aList.ToHashSet();
            var memo = hashSet.ToDictionary(item => item, _ => 0L);
            foreach (var a in aList)
            {
                memo[a] += 1;
            }

            // それぞれの約数を列挙しておく
            var dic = new Dictionary<int, List<int>>();
            foreach (var item in hashSet)
            {
                var divisor = getDivisor(item);
                dic.Add(item, divisor);
            }

            var count = 0L;
            for (int k = 0; k < n; k++)
            {
                var ak = aList[k];

                var divisors = dic[ak];
                foreach (var divisor in divisors)
                {
                    if (memo.ContainsKey(divisor) && memo.ContainsKey(ak / divisor))
                    {
                        count += (memo[divisor] * memo[ak / divisor]);
                    }
                }
            }

            Console.WriteLine(count);
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


        /**
         * 約数列挙
         */
        public static List<int> getDivisor(int n)
        {
            var ret = new List<int>();

            for (int i = 1; i * i <= n; i++)
            {
                if (n % i != 0)
                {
                    continue;
                }

                ret.Add(i);

                if (n / i != i)
                {
                    ret.Add(n / i);
                }
            }

            return ret;
        }
    }
}