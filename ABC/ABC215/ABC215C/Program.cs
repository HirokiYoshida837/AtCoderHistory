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

namespace ABC215C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (s, k) = ReadValue<string, int>();

            var perm = new Permutation();
            var dic = new List<string>();
            foreach (var chars1 in perm.Enumerate(Enumerable.Range(0, s.Length)))
            {
                var str = new string(chars1.Select(x => s[x]).ToArray());
                dic.Add(str);
            }

            dic = dic.Distinct().OrderBy(x => x).ToList();

            Console.WriteLine(dic[k - 1]);
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


    public class Permutation
    {
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items)
        {
            if (items.Count() == 1)
            {
                yield return new T[] {items.First()};
                yield break;
            }

            foreach (var item in items)
            {
                var leftside = new T[] {item};
                var unused = items.Except(leftside);
                foreach (var rightside in Enumerate(unused))
                {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}