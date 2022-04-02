using System;
using System.Linq;

namespace ABC246B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var a = ab[0];
            var b  = ab[1];

            var d = Math.Sqrt(a * a + b * b);

            var cos = a / d;
            var sin = b / d;

            Console.WriteLine($"{cos} {sin}");
        }
    }
}