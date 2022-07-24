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

namespace ABC248A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine().ToList();
            
            var dic = Enumerable.Range('0',10).Select(x=>(char)x).ToHashSet();

            foreach (var c in s)
            {
                dic.Remove(c);
            }

            Console.WriteLine(dic.First());
        }
    }
}