using System;
using System.Linq;

namespace ABC241A
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();


            var tmp = 0;

            tmp = a[tmp];
            tmp = a[tmp];
            tmp = a[tmp];

            Console.WriteLine(tmp);

        }
    }
}