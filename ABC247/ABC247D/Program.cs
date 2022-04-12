using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Math;

namespace ABC247D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var q = int.Parse(Console.ReadLine());

            var queries = Enumerable.Range(0, q)
                .Select(_ => Console.ReadLine().Split().Select(long.Parse).ToList())
                .ToList();

            var queue = new LinkedList<(long key, long value)>();


            foreach (var query in queries)
            {
                var type = query[0];

                if (type == 1)
                {
                    var (x, c) = (query[1], query[2]);
                    queue.AddLast((x, c));
                }
                else
                {
                    var c = query[1];

                    var sum = 0L;

                    while (c > 0)
                    {
                        var (vx, vc) = queue.First();
                        queue.RemoveFirst();

                        if (vc > c)
                        {
                            sum += vx * c;
                            queue.AddFirst((vx, vc - c));
                            c = 0;
                        }
                        else
                        {
                            sum += vx * vc;
                            c -= vc;
                        }
                    }

                    Console.WriteLine(sum);
                }
            }
        }
    }
}