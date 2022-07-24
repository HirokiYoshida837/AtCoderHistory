using System;
using System.Linq;

namespace ABC242B
{
    class Program
    {
        static void Main(string[] args)
        {

            var s = Console.ReadLine()
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(s);
        }
    }
}