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

namespace ABC215D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int,int>();
            var aList = ReadList<int>().ToArray();
            
            var dic = Enumerable.Range(0, m + 1)
                .Select(x => x)
                .ToHashSet();

            dic.Remove(0);


            var divList = aList.Select(x=>getDivisor(x))
                .SelectMany(x=>x)
                // .OrderBy(x=>x)
                .ToHashSet();

            divList.Remove(1);
            
            foreach (var i in divList)
            {
                for (var item = i; item <=m; item+=i)
                {
                    dic.Remove(item);
                }
            }

            var array = dic.OrderBy(x => x).ToArray();
            Console.WriteLine(array.Length);
            foreach (var i in array)
            {
                Console.WriteLine(i);
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
        
        
        // 約数列挙
        public static List<int> getDivisor(int n)
        {
            var ret = new List<int>();

            for (int i = 1; i*i <=n; i++)
            {
                if (n % i != 0)
                {
                    continue;
                }

                ret.Add(i);

                if (n/i != i)
                {
                    ret.Add(n/i);
                }
            }

            return ret;
        }
        
        
    }

    public class Utils
    {
        // 再帰する
        // public static int GCD(int a, int b)
        // {
        //     if (b == 0) return a;
        //     return GCD(b, a % b);
        // }

        /// <summary>
        /// 最大公約数 (the Greatest Common Divisor) を計算します。(再帰なし)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static long GCD(long a, long b)
        {
            while (true)
            {
                if (b == 0) return a;
                a %= b;
                if (a == 0) return b;
                b %= a;
            }
        }

        /// <summary>
        /// 最小公倍数 (The Least Common Multiple) を計算します。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static long LCM(long a, long b)
        {
            // (a*b)/GCD だとオーバーフローするかもしれないので、先に割り算する
            return (a / GCD(a, b)) * b;
        }
    }
}