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
            var hashSet = Console.ReadLine().Split().ToList().ToHashSet();
            
            foreach (var s1 in s)
            {
                Console.WriteLine(hashSet.Contains(s1) ? "Yes" : "No");
            }
        }
    }
}