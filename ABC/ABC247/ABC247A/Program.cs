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

namespace ABC247A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();
            Console.Write("0");

            for (var i = 0; i < s.Length-1; i++)
            {
                var c = s[i];
                Console.Write(c);
            }

            Console.WriteLine();

            
        }
    }
}