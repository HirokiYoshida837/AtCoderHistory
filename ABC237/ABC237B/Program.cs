using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC237B
{
    class Program
    {
        static void Main(string[] args)
        {
            var hw = Console.ReadLine().Split().Select(int.Parse).ToList();
            var h = hw[0];
            var w = hw[1];

            var aMatrix = new List<List<int>>();

            for (int i = 0; i < h; i++)
            {
                var list = Console.ReadLine().Split().Select(int.Parse).ToList();
                aMatrix.Add(list);
            }

            for (int x = 0; x < w ; x++)
            {
                for (int y = 0; y < h ; y++)
                {
                    Console.Write(aMatrix[y][x] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}