using System;
using System.Collections.Generic;

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
        
        
        /**
         * 約数列挙
         */
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
        
        /// <summary>
        /// 素因数分解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeFactors(long n)
        {
            long i = 2;
            long tmp = n;

            while (i * i <= n)
            {
                if(tmp % i == 0){
                    tmp /= i;
                    yield return i;
                }else{
                    i++;
                }
            }
            if(tmp != 1) yield return tmp;//最後の素数も返す
        }
    }

}