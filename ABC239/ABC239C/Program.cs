using System;
using System.Linq;

namespace ABC239C
{
    class Program
    {
        static void Main(string[] args)
        {
            var xyxy = Console.ReadLine().Split().Select(int.Parse).ToList();

            (int X, int Y) p1 = (xyxy[0], xyxy[1]);
            (int X, int Y) p2 = (xyxy[2], xyxy[3]);

            var ans = false;
            for (int i = (int) p1.X - 3; i <= p1.X + 3; i++)
            {
                for (int j = (int) p1.Y - 3; j <= p1.Y + 3; j++)
                {
                    // Console.WriteLine($"{i} {j}");

                    var dist1 = calcDist(p1, (i, j));
                    var dist2 = calcDist(p2, (i, j));

                    if ((dist1  == Math.Sqrt(5)) && (dist2 == Math.Sqrt(5)))
                    {
                        // Console.WriteLine($"{i} {j}");
                        ans = true;
                    }
                }
            }


            Console.WriteLine(ans ? "Yes" : "No");
        }

        static double calcDist((int X, int Y) p1, (int X, int Y) p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}