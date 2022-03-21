using System;
using System.Linq;

namespace ABC236A
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().ToCharArray();
            var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (a, b) = (ab[0], ab[1]);

            var c = s[a-1];

            s[a-1] = s[b-1];
            s[b-1] = c;

            var s1 = new string(s);
            Console.WriteLine(s1);
        }
    }
}