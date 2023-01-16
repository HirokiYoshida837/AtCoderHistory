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

namespace ABC284D
{
    public static class Program
    {

        public static List<long> preCalcPrimes;
        
        public static void Main(string[] args)
        {
            var t = ReadValue<int>();
            
            calcPrimes();

            for (int i = 0; i < t; i++)
            {
                var read = ReadValue<long>();

                // for (long v = 2; v < 3 * 1000000; v++)
                for (var index = 0; index<preCalcPrimes.Count; index++)
                {
                    var v = preCalcPrimes[index]; 
                    
                    if (read % v != 0)
                    {
                        continue;
                    }
                    else
                    {
                        if ((read / v) % v == 0)
                        {
                            Console.WriteLine($"{v} {read / v / v}");
                        }
                        else
                        {
                            var q = v;
                            var p = (long) Sqrt(read / q);
                
                            Console.WriteLine($"{p} {q}");
                        }
                
                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// 素因数分解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<long> PrimeFactors(long n)
        {
            int index = 0;
            long i = preCalcPrimes[index];
            long tmp = n;

            while (i * i <= n && index<preCalcPrimes.Count)
            {
                i = preCalcPrimes[index];
                
                if (tmp % i == 0)
                {
                    tmp /= i;
                    yield return i;
                }
                else
                {
                    index++;
                }
            }

            if (tmp != 1) yield return tmp; //最後の素数も返す
        }


        public static void calcPrimes()
        {
            // エラストテネスの篩で事前に計算しておく
            var primes = new bool[3 * 1000000];
            for (var i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            primes[0] = false;
            primes[1] = false;
            primes[2] = true;
            primes[3 * 1000000-1] = false;

            for (long p = 2; p < primes.Count(); p++)
            {
                if (primes[p])
                {
                    for (long i = p * p; i < primes.Count(); i += p)
                    {
                        primes[i] = false;
                    }
                }
            }

            

            preCalcPrimes = new List<long>();
            
            for (var i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    preCalcPrimes.Add(i);
                }
            }
            
            return;
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