using System;

namespace ABCUtils
{
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