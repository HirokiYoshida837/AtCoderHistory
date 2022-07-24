using System;
using System.Linq;

namespace ABC246C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nkx = Console.ReadLine().Split().Select(long.Parse).ToList();
            var (n, k, x) = (nkx[0], nkx[1], nkx[2]);

            var a = Console.ReadLine().Split().Select(long.Parse).ToArray();


            var count = k;
            for (var i = 0; i < a.Length; i++)
            {
                if (count == 0)
                {
                    continue;
                }

                var num = Math.Min(count, a[i] / x);
                count -= num;

                a[i] -= num * x;
            }

            a = a.OrderByDescending(x => x).ToArray();
            
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0)
                {
                    continue;
                }
                
                if (count == 0)
                {
                    break;
                }

                a[i] -= Math.Min(x, a[i]);
                count--;
            }

            Console.WriteLine(a.Sum());
        }
    }
}