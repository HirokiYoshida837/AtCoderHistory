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

namespace ABC229A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            if ((s1 == ".#" && s2 == "#.") || (s2 == ".#" && s1 == "#."))
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
        }
    }
}