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

namespace ABC225B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            (int a, int b)[] ab = Enumerable.Range(0, n-1)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var l = new HashSet<int>[n+1];
            
            foreach (var (a,b) in ab)
            {
                l[a] ??= new HashSet<int>();
                l[b] ??= new HashSet<int>();
                
                l[a].Add(b);
                l[b].Add(a);
            }

            // 0を消す
            l = l[1..];

            var first = l
                .Select(x => x.Count)
                .Count(x => x == n - 1);

            Console.WriteLine(first == 1 ? "Yes" : "No");
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }
    }
}