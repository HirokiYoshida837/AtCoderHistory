using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC242D
{
    class Program
    {
        static void Main(string[] args)
        {
            var nx = Console.ReadLine().Split().Select(long.Parse).ToList();
            var n = nx[0];
            var x = nx[1];

            var s = Console.ReadLine().ToCharArray();

            var posBin = Convert.ToString(x, 2);

            foreach (var c in s)
            {
                if (c == 'U')
                {
                    posBin = posBin.Remove(posBin.Length - 1);
                }
                else if (c == 'L')
                {
                    posBin = posBin + "0";
                }
                else if (c == 'R')
                {
                    posBin = posBin + "1";
                }
            }

            var int64 = Convert.ToInt64(posBin, 2);

            Console.WriteLine(int64);
        }
    }
}