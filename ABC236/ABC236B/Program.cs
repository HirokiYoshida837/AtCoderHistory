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

            var count = new int[n + 1];
            
            foreach (var item in a)
            {
                count[item]++;
            }
            
            for (var i = 0; i < count.Length; i++)
            {
                if (count[i] == 3)
                {
                    Console.WriteLine(i++);
                }
            }
        }
    }
}