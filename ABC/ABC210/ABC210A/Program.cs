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

namespace ABC210A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var naxy = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = naxy[0];
            var a = naxy[1];
            var x = naxy[2];
            var y = naxy[3];

            var count = 0L;
            var ans = 0L;
            while (count < n)
            {
                if (count < a)
                {
                    ans += x;
                }
                else
                {
                    ans += y;
                }

                count++;
            }

            Console.WriteLine(ans);
        }

    }
}