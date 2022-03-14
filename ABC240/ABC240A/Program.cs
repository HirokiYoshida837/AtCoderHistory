using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC240A
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
            var a = ab[0];
            var b = ab[1];

            Console.WriteLine((Math.Abs(a - b) <= 1 || (b == 10 && a == 1)) ? "Yes" : "No");
        }
    }
}