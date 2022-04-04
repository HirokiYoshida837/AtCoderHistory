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

namespace ABC235C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nq = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, q) = (nq[0], nq[1]);

            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<(int x, int q)> xq = Enumerable.Range(1, q)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList())
                .Select(x=>(x[0], x[1]))
                .ToList();

            var dic = new Dictionary<int, List<int>>();

            for (var i = 0; i < a.Count; i++)
            {
                if (!dic.ContainsKey(a[i]))
                {
                    dic[a[i]] = new List<int> {i};
                }
                else
                {
                    dic[a[i]].Add(i);
                }
            }

            foreach (var (x, k) in xq)
            {
                if (!dic.ContainsKey(x))
                {
                    Console.WriteLine(-1);
                    continue;
                }

                var list = dic[x];
                if (k - 1 >= list.Count)
                {
                    Console.WriteLine(-1);
                    continue;
                }
                Console.WriteLine(list[k - 1] + 1);
            }
        }
    }
}