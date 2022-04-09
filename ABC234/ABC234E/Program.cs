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

namespace ABC234E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = long.Parse(Console.ReadLine());

            var alls = generateArithmeticNumAll();

            var ans = alls
                .OrderBy(x => x)
                .First(v => v >= x);

            Console.WriteLine(ans);
        }


        public static HashSet<long> generateArithmeticNumAll()
        {
            var list = new HashSet<long>();

            for (int i = 1; i < 10; i++)
            {
                list.Add(i);
            }

            for (long start = 1; start < 10; start++)
            {
                for (int dif = -9; dif < 10; dif++)
                {
                    var b = start + dif;
                    var t = start;
                    while (0 <= b && b < 10 && t<=999999999999999999)
                    {
                        t = t * 10 + b;
                        list.Add(t);
                        b += dif;
                    }
                }
            }

            return list;
        }

    }
}