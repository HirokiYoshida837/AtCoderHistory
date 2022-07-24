using System;

namespace ABC183A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(x, 0));
        }
    }
}