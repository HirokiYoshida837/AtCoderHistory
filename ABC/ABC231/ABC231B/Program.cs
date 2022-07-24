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

namespace ABC231B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var s = Enumerable.Range(0, n)
                .Select(_ => Console.ReadLine())
                .ToList();


            var dic = new Dictionary<string, int>();
            
            foreach (var s1 in s)
            {
                if (dic.ContainsKey(s1))
                {
                    dic[s1] += 1;
                }
                else
                {
                    dic.Add(s1,1);
                }
            }


            var max = int.MinValue;
            var name = "";
            foreach (var keyValuePair in dic)
            {
                if (keyValuePair.Value > max)
                {
                    max = keyValuePair.Value;
                    name = keyValuePair.Key;
                }
            }

            Console.WriteLine(name);
            
        }
    }
}