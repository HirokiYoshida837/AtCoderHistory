using System;
using System.Linq;

namespace ABC211A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var ab = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Console.WriteLine(((ab[0] - ab[1]) / 3d) + ab[1]);
        }
    }
}