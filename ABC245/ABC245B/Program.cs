using System;
using System.Linq;

namespace ABC245B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x=>x).ToHashSet();

            for (int i = 0; i < 2001; i++)
            {
                if (!a.Contains(i))
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}