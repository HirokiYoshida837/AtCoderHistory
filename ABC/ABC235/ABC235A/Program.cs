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

namespace ABC235A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abc = Console.ReadLine();
            var bca = new string(new[] {abc[1], abc[2], abc[0]});
            var cab = new string(new[] {abc[2], abc[0], abc[1],});

            var sum = new[] {abc, bca, cab}.ToList()
                .Select(int.Parse)
                .ToList()
                .Sum();

            Console.WriteLine(sum);
        }
    }
}