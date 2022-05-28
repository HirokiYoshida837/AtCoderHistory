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

namespace ABC253D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, a, b) = ReadValue<long, long, long>();

            var sumAll = (1 + n) * n / 2;

            // aの倍数 = 初項 a、公差 aの数列 (個数は n/a)
            var lenA = n / a;
            var sumA = (lenA * (2 * a + (lenA - 1) * a)) / 2;


            // bの倍数 = 初項 b、公差 bの数列
            var lenB = n / b;
            var sumB = (lenB * (2 * b + (lenB - 1) * b)) / 2;
            
            
            // aとbの最小公倍数
            var lcm = LCM(a, b);
            var lenLCM = n / lcm;
            var sumLCM = (lenLCM * (2 * lcm + (lenLCM - 1) * lcm)) / 2;
            

            Console.WriteLine(sumAll - (sumA + sumB) + sumLCM);
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