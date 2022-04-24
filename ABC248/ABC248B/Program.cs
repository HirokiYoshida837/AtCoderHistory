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

namespace ABC248B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abk = Console.ReadLine().Split().Select(long.Parse).ToList();
            var (a, b, k) = (abk[0], abk[1], abk[2]);

            if (a >= b)
            {
                Console.WriteLine(0);
                return;
            }

            var count = 0L;
            while (true)
            {
                count++;
                a *= k;
                if (a >= b)
                {
                    break;
                }
            }

            Console.WriteLine(count);
            
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