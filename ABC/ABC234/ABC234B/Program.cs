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

namespace ABC234B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<(int x, int y)> xy = Enumerable.Range(0, n)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList())
                .Select(x => (x[0], x[1]))
                .ToList();

            var diff = -1;
            
            for (var i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {

                    var from = xy[i];
                    var to = xy[j];

                    var dist = (to.x - from.x) * (to.x - from.x) + (to.y - from.y) * (to.y - from.y);

                    diff = Math.Max(diff, dist);
                }
            }

            Console.WriteLine(Math.Sqrt(diff));
            
        }
    }
}