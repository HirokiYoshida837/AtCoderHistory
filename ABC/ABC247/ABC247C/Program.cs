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

namespace ABC247C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dic = new Dictionary<int, List<int>>();
            
            dic.Add(1, new List<int>(){1});

            for (int i = 2; i <=16; i++)
            {
                var l = new List<int>();
                l.AddRange(dic[i-1]);
                l.Add(i);
                l.AddRange(dic[i-1]);
                
                dic.Add(i, l);
            }

            var list = dic[n];

            var joined = string.Join(" ",list.Select(x=>x.ToString()).ToList());

            Console.WriteLine(joined);
        }
    }
}