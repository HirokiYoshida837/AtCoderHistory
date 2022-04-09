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

namespace ABC233B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var lr = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (l, r) = (lr[0], lr[1]);

            var s = Console.ReadLine();

            var sleft = s.Substring(0, l-1);
            var smid = s.Substring(l-1, r-l+1);
            var sright = s.Substring(r, s.Length-r);

            Console.WriteLine($"{sleft}{new string(smid.Reverse().ToArray())}{sright}");

        }
    }
}