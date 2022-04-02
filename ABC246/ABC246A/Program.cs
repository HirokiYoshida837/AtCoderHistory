using System;
using System.Linq;

namespace ABC246A
{
    class Program
    {
        static void Main(string[] args)
        {
            var xy1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var xy2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var xy3 = Console.ReadLine().Split().Select(int.Parse).ToList();


            var x = new int[3] {xy1[0], xy2[0], xy3[0]};
            var y = new int[3] {xy1[1], xy2[1], xy3[1]};

            var x4 = 0;
            var y4 = 0;

            var xMax = x.Max();
            var xMin = x.Min();
            var yMax = y.Max();
            var yMin = y.Min();

            var countX = x.ToList().Count(x=>x == xMax);
            if (countX == 2)
            {
                x4 = xMin;
            }
            else
            {
                x4 = xMax;
            }
            
            var countY = y.ToList().Count(y=>y == yMax);
            if (countY == 2)
            {
                y4 = yMin;
            }
            else
            {
                y4 = yMax;
            }

            Console.WriteLine($"{x4} {y4}");
        }
    }
}