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

            if (b ==0)
            {
                Console.WriteLine("1 0");
                return;
            }


            var x2 = 1d/(1d  + (a / b)* (a / b));
            var y2 = 1d - x2;

            Console.WriteLine($"{Math.Sqrt(y2)} {Math.Sqrt(x2)}");
        }
    }
}