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

namespace ABC232A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var a = char.ToString(s[0]);
            var b = char.ToString(s[^1]);

            var an = int.Parse(a);
            var bn = int.Parse(b);

            Console.WriteLine(an*bn);
        }
    }
}