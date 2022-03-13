using System;
using System.Linq;

namespace ABC242A
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcx = Console.ReadLine().Split().Select(double.Parse).ToList();

            if (abcx[3] <= abcx[0])
            {
                Console.WriteLine(1);
                return;
            }

            if (abcx[3] > abcx[1])
            {
                Console.WriteLine(0);
                return;
            }

            var d = abcx[1] - abcx[0];

            Console.WriteLine(abcx[2]/d);

        }
    }
}