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

namespace ABC262C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();

            var dic = new Dictionary<int, HashSet<int>>();
            var selfContains = new List<int>();

            for (var i = 0; i < aList.Length; i++)
            {
                if (dic.ContainsKey(aList[i]))
                {
                    dic[aList[i]].Add(i + 1);
                }
                else
                {
                    dic.Add(aList[i], new HashSet<int>() {i + 1});
                }

                if (aList[i] == i + 1)
                {
                    selfContains.Add(i + 1);
                }

                // if (dic.ContainsKey(i+1) && dic[i+1].Contains(aList[i]))
                // {
                //     Console.WriteLine($"{aList[i]}, {i+1}");
                // }
            }


            var count = 0L;
            foreach (var (key, set) in dic)
            {
                foreach (var item in set)
                {
                    if (item == key)
                    {
                        continue;
                    }

                    if (dic.ContainsKey(item) && dic[item].Contains(key))
                    {
                        // Console.WriteLine($"{item}, {key}");
                        count++;
                    }
                }
            }

            count /= 2;

            // 最大で10^5 * 10^5なのでlongにしないとバグる。
            var selfContainsCount = (long) selfContains.Count;
            var containsCount = ((selfContainsCount - 1) + 1) * (selfContainsCount - 1) / 2;
            count += containsCount;

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
    }
}