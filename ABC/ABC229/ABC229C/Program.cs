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

namespace ABC229C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, w) = ReadValue<int, long>();
            List<(long a, long b)> abs = Enumerable.Range(0, n)
                .Select(_ => ReadValue<long, long>())
                .ToList();

            abs = abs.OrderByDescending(x => x.a).ToList();


            var count = 0L;
            var ans = 0L;
            foreach (var (a, b) in abs)
            {
                var nokori = w - count;

                if (b > nokori)
                {
                    count += nokori;
                    ans += nokori * a;
                    break;
                }
                else
                {
                    count += b;
                    ans += a * b;
                }
                
            }

            Console.WriteLine(ans);


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