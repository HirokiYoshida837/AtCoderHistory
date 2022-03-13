using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ABC242B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(long.Parse).ToList();
            var b = Console.ReadLine().Split().Select(long.Parse).ToList();


            var dict = new Dictionary<long, (long A,long B)>();

            for (long i = 0; i < 10 + 1; i++)
            {
                dict.Add(i,(-1,-1));
            }
            
            for (var i = 0; i < a.Count; i++)
            {
                dict[a[i]] = (i, dict[a[i]].B);
            }
            
            for (var i = 0; i < b.Count; i++)
            {
                dict[b[i]] = (dict[b[i]].A, i);
            }

            var keyValuePairs = dict.Where(x=>x.Value.A != -1 && x.Value.B != -1)
                .ToList();

            var ans1 = keyValuePairs.Count(x=>x.Value.A == x.Value.B);

            Console.WriteLine(ans1);


            var ans2 = keyValuePairs.Count(x => x.Value.A != x.Value.B);

            Console.WriteLine(ans2);
        }
    }
}