using System;

namespace ABC239A
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = double.Parse(Console.ReadLine());

            var sqrt = Math.Sqrt( h * (12800000.0 + h));

            Console.WriteLine(sqrt);
        }
    }
}