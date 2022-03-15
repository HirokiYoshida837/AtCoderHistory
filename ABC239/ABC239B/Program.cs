using System;
using System.Linq;

namespace ABC239B
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = long.Parse(Console.ReadLine());

            if (x < 0 && x %10 != 0)
            {
                Console.WriteLine(x/10 -1);
            }
            else
            {
                Console.WriteLine(x/10);
            }
        }
    }
}