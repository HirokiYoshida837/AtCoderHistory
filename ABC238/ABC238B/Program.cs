using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC238B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();

            var aSum = new List<int>();
            aSum.Add(0);
            foreach (var item in a)
            {
                aSum.Add((aSum[^1] + item) % 360);
            }

            aSum.Add(360);
            aSum = aSum.OrderBy(x => x).ToList();

            var max = 0;
            for (var i = 1; i < aSum.Count; i++)
            {
                max = Math.Max(max, aSum[i] - aSum[i - 1]);
            }

            Console.WriteLine(max);
        }
    }
}