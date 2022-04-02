using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC245C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, k) = (nk[0], nk[1]);

            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var enableNum = new List<int>();
            enableNum.AddRange(new[]{a[0], b[0]});

            for (int i = 1; i < n; i++)
            {
                var next = new List<int>();
                
                foreach (var num in enableNum)
                {
                    if(Math.Abs(a[i] - num) <= k) next.Add(a[i]);
                    if(Math.Abs(b[i] - num) <= k) next.Add(b[i]);
                }

                next = next.Distinct().ToList();
                enableNum = next;
            }

            Console.WriteLine(enableNum.Count > 0 ? "Yes" : "No");
        }
    }
}