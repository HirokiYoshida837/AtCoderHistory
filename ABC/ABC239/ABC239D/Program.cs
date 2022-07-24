using System;
using System.Linq;

namespace ABC239D
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcd = Console.ReadLine().Split().Select(int.Parse).ToList();
            var a = abcd[0];
            var b = abcd[1];
            var c = abcd[2];
            var d = abcd[3];

            // エラストテネスの篩で事前に計算しておく
            var primes = new bool[210];
            for (var i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            for (int p = 2; p * p <= 200; p++)
            {
                if (primes[p])
                {
                    for (int i = p * p; i <= 200; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }


            for (int i = a; i <= b; i++)
            {
                var flag = true;
                for (int j = c; j <= d; j++)
                {
                    // i+j が一つでも素数であれば、 Aokiくんがかつ。 i+j が全部素数じゃないなら、Takahashiくんがかつ。
                    flag = flag && !primes[i + j];
                }
                
                // i+j が素数じゃないものしかなかった
                if(flag)
                {
                    Console.WriteLine("Takahashi");
                    return;
                }
            }

            Console.WriteLine("Aoki");
        }
    }
}