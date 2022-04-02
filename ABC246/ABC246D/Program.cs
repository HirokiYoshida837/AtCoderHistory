using System;
using System.Collections.Generic;

namespace ABC246D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var ansList = new List<(int A, int B, int X)>();

            for (int a = 0; a <= 1000000; a++)
            {
                for (int b = a; b <= 1000000; a++)
                {
                    var value = (a * a * a) + (a * a * b) + (a * b * b) + (b * b * b);

                    if (value <= 1000000000000000000)
                    {
                        ansList.Add((a, b, value));
                    }
                }
            }
            
            Console.WriteLine(ansList);
        }
    }
}