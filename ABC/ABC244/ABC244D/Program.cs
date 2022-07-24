using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC244D
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().Split().ToArray();
            var t = Console.ReadLine().Split().ToArray();

            var count = 0;
            for (int i = 0; i < 3; i++)
            {
                if (s[i] != t[i])
                {
                    count++;
                }
            }

            if (count == 2)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }
    }
}