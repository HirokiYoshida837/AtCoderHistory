using System;
using System.Linq;

namespace ABC236C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, m) = (nm[0], nm[1]);

            var s = Console.ReadLine().Split().ToList();
            var t = Console.ReadLine().Split().ToList();

            var hashSet = t.ToHashSet();
            
            foreach (var s1 in s)
            {
                var contains = hashSet.Contains(s1);
                Console.WriteLine(contains ? "Yes" : "No");
            }
        }
    }
}