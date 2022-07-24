using System;

namespace ABC244A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();

            Console.WriteLine(s[^1]);
        }
    }
}