using System;
using System.Linq;

namespace ABC242A
{
    class Program
    {
        static void Main(string[] args)
        {
            var vabc = Console.ReadLine().Split().Select(int.Parse).ToList();

            var v = vabc[0];

            while (true)
            {
                v -= vabc[1];

                if (v < 0)
                {
                    Console.WriteLine("F");
                    return;
                }

                v -= vabc[2];

                if (v < 0)
                {
                    Console.WriteLine("M");
                    return;
                }

                v -= vabc[3];

                if (v < 0)
                {
                    Console.WriteLine("T");
                    return;
                }
            }
        }
    }
}