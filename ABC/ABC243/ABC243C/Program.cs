using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ABC242C
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var xy = new List<(int X, int Y)>();

            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split().Select(int.Parse).ToList();
                xy.Add((list[0], list[1]));
            }

            var s = Console.ReadLine().ToCharArray();


            var min = new Dictionary<int, int>();
            var max = new Dictionary<int, int>();


            for (int i = 0; i < n; i++)
            {
                var x = xy[i].X;
                var y = xy[i].Y;

                var c = s[i];

                if (c == 'R')
                {
                    if (!min.ContainsKey(y))
                    {
                        min.Add(y, int.MaxValue);
                    }

                    if (min[y] > x)
                    {
                        min[y] = x;
                    }
                }
                else
                {
                    if (!max.ContainsKey(y))
                    {
                        max.Add(y, int.MinValue);
                    }

                    if (max[y] < x)
                    {
                        max[y] = x;
                    }
                }
            }

            var ok = false;
            
            foreach (var y in min.Keys)
            {

                if (!max.ContainsKey(y))
                {
                    continue;
                }

                if (min[y] < max[y])
                {
                    ok = true;
                }
            }

            Console.WriteLine(ok ? "Yes" : "No");
        }
    }
}