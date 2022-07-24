using System;

namespace ABC215B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var ans = 2L;
            var count = 0L;
            while (ans <= n)
            {
                ans <<= 1;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}