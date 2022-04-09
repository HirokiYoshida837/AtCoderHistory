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

namespace ABC233A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var xy = Console.ReadLine().Split().Select(int.Parse).ToList();
            var x = xy[0];
            var y = xy[1];

            var diff = y - x;

            if (diff <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (diff % 10 == 0)
            {
                Console.WriteLine(diff/10);
                return;
            }
            else
            {
                Console.WriteLine(diff/10 + 1);
                return;
            }
        }
    }
}