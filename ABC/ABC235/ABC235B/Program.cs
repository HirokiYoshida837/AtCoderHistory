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

namespace ABC235B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var h = Console.ReadLine().Split().Select(int.Parse).ToList();

            var ans = 0;
            var current = 0;
            foreach (var item in h)
            {
                if (current < item)
                {
                    current = item;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(current);
        }
    }
}