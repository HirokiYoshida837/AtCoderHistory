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

namespace ABC175C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (x, k, d) = ReadValue<long, long, long>();

            if (x < 0) x *= -1;


            // たどり着けない場合
            if (x / d >= k)
            {
                Console.WriteLine(x - d * k);
                return;
            }

            // 残り回数
            var rem = k - x / d;

            if (rem % 2 == 0)
            {
                // 残り回数が偶数だったら、反復横跳びするしかない。行き過ぎた分の差分はModで求められる
                Console.WriteLine(x % d);
            }
            else
            {
                // 残り回数が奇数だったら、1手戻ったところが答え
                Console.WriteLine(d - x % d);
                return;
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