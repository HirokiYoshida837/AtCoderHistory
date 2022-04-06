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

namespace ABC235D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var an = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (a, n) = (an[0], an[1]);

            var visited = new HashSet<int> {n};
            var next = new List<int> {n};

            var count = 0;

            while (true)
            {
                count++;

                var parents = next
                    .SelectMany(x => getParent(x, a))
                    .ToList();

                next = new List<int>();

                foreach (var item in parents)
                {
                    if (item == 1)
                    {
                        Console.WriteLine(count);
                        return;
                    }

                    if (!visited.Contains(item))
                    {
                        visited.Add(item);
                        next.Add(item);
                    }
                }

                if (next.Count == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }

        public static List<int> getParent(int number, int a)
        {
            var res = new List<int>();
            if (number == 1)
            {
                return res;
            }

            if (reverseRotatable(number))
            {
                res.Add(getHeadToSuffix(number));
            }

            if (number >= a && number % a == 0)
            {
                res.Add(number / a);
            }

            return res;
        }

        public static bool reverseRotatable(int number)
        {
            return number.ToString().Length >= 2 && number.ToString()[1] != '0';
        }

        public static int getHeadToSuffix(int number)
        {
            var s = number.ToString().ToCharArray().ToList();
            s.Add(s[0]);
            s.RemoveAt(0);

            return int.Parse(s.ToArray());
        }
    }
}