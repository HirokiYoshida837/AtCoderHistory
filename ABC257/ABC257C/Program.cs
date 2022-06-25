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

namespace ABC257C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var s = ReadValue<string>();
            var wList = ReadList<long>().ToArray();

            var zeroSum = s.ToArray().Count(x => x == '0');
            var oneSum = s.ToArray().Count(x => x == '1');

            Dictionary<long, (long zero, long one)> dictionary = wList.Distinct()
                .OrderBy(x => x)
                .ToDictionary(x => x, _ => (0L, 0L));

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == '0')
                {
                    dictionary[wList[i]] = (dictionary[wList[i]].zero + 1, dictionary[wList[i]].one);
                }
                else
                {
                    dictionary[wList[i]] = (dictionary[wList[i]].zero, dictionary[wList[i]].one + 1);
                }
            }

            // 累積和を考える。
            var cumDic = new Dictionary<long, (long zero, long one)>();

            var cum = new List<(long key, long zero, long one)>();
            cum.Add((0, 0, 0));

            foreach (var kv in dictionary)
            {
                cum.Add((kv.Key, cum.Last().zero + kv.Value.zero, cum.Last().one + kv.Value.one));
            }

            cum.RemoveAt(0);
            foreach (var (k, z, o) in cum)
            {
                cumDic.Add(k, (z, o));
            }

            var nD = new Dictionary<long, (long zero, long one)>();
            foreach (var keyValuePair in cumDic)
            {
                nD.Add(keyValuePair.Key, (keyValuePair.Value.zero, oneSum - keyValuePair.Value.one));
            }

            var max = nD.Select(x => x.Value.zero + x.Value.one)
                .Max();

            max = Math.Max(max, zeroSum);
            max = Math.Max(max, oneSum);
            
            Console.WriteLine(max);
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