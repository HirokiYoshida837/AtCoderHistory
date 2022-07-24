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

namespace ABC148C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b) = ReadValue<long, long>();

            // (a*b)/GCD だとオーバーフローするかもしれないので、さきに割り算する
            var ans = (a / GCD(a, b)) * b;

            Console.WriteLine(ans);
        }

        // 再帰しない
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

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }
    }
}