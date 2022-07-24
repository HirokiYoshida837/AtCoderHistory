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

namespace ABC232D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var hw = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (h, w) = (hw[0], hw[1]);

            var c = Enumerable.Range(0, h)
                .Select(_ => Console.ReadLine().ToCharArray().Select(char.ToString).ToArray())
                .ToArray();

            var visited = new string[h][];

            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((0, 0));

            var step = 0;

            while (true)
            {
                var next = new HashSet<(int, int)>();
                if (queue.Count == 0)
                {
                    break;
                }

                step++;

                while (queue.Count > 0)
                {
                    var valueTuple = queue.Dequeue();

                    if (valueTuple.x < w - 1)
                    {
                        var s = c[valueTuple.y][valueTuple.x + 1];
                        if (s != "#")
                        {
                            next.Add((valueTuple.x+1, valueTuple.y));
                        }
                    }
                    
                    if (valueTuple.y < h - 1)
                    {
                        var s = c[valueTuple.y+1][valueTuple.x];
                        if (s != "#")
                        {
                            next.Add((valueTuple.x, valueTuple.y+1));
                        }
                    }
                }
                queue = new Queue<(int,int)>(next.ToList());
            }

            Console.WriteLine(step);
        }
    }
}