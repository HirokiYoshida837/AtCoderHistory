using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC240B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();

            var hashSet = new HashSet<int>();
            
            foreach (var i in a)
            {
                hashSet.Add(i);
            }

            Console.WriteLine(hashSet.Count);
        }
    }
}