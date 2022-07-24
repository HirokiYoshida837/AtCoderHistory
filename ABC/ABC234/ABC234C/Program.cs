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

namespace ABC234C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var k = long.Parse(Console.ReadLine());

            var s = Convert.ToString(k,2);
            var array = s.ToArray().Select(x=>x=='0'?'0':'2').ToArray();
            Console.WriteLine(new string(array));
        }
    }
}