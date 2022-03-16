using System;

namespace ABC237A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            if (Int32.MinValue <= n && n <= Int32.MaxValue)
            {
                Console.WriteLine("Yes");
                return;
            }

            Console.WriteLine("No");
        }
    }
}