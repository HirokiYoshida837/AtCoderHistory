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

namespace ABC169D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<long>();
            var longs = PrimeFactors(n)
                .GroupBy(x => x)
                .Select(x => (x.Key, x.Select(x => x).ToList()))
                .ToList();

            var dic = new Dictionary<long, List<long>>();
            
            foreach (var (key, list) in longs)
            {
                var listCount = list.Count;

                var l = new List<long>();

                var tmp = 1L;

                var count = 1;
                while (true)
                {
                    if (listCount>=count)
                    {
                        listCount -= count;
                        tmp *= key;
                        l.Add(tmp);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                dic.Add(key, l);
            }

            var sum = dic.Select(x=>x.Value.Count).Sum();
            Console.WriteLine(sum);
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
        

        /// <summary>
        /// 約数列挙
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<long> getDivisor(long n)
        {
            var ret = new List<long>();

            for (long i = 1; i*i <=n; i++)
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