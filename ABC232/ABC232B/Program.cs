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

namespace ABC232B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine().ToCharArray();
            var t = Console.ReadLine().ToCharArray();

            var diff = new List<int>();
            
            for (var i = 0; i < s.Length; i++)
            {
                var sc = s[i];
                var tc = t[i];

                var d = tc - sc;

                if (d<0)
                {
                    d += 26;
                }
                
                diff.Add(d);
            }

            var hashSet = diff.ToHashSet();
            Console.WriteLine(hashSet.Count == 1 ? "Yes" : "No");
        }
    }
}