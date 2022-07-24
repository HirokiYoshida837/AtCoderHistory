using System;
using System.Linq;

namespace ABC237C
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();

            var head = s.Length - s.TrimStart('a').Length;
            var tail = s.Length - s.TrimEnd('a').Length;

            var trim = s.Trim('a');

            var res = trim.Reverse().SequenceEqual(trim) && (head <= tail);

            Console.WriteLine(res ? "Yes" : "No");
        }
    }
}