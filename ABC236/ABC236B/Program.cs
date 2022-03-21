using System;
using System.Linq;

namespace ABC236B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();

            var ans = a.GroupBy(x => x)
                .First(x => x.Count() == 3).Key;

            Console.WriteLine(ans);
        }
    }
}