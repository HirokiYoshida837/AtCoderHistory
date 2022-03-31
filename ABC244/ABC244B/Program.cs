using System;

namespace ABC244B
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var t = Console.ReadLine().ToCharArray();


            var dir = 0;
            var posX = 0;
            var posY = 0;

            foreach (var c in t)
            {
                if (c == 'R')
                {
                    dir += 1;
                    dir %= 4;
                }
                else
                {
                    if (dir == 0)
                    {
                        // 右
                        posX += 1;
                        posY += 0;
                    }
                    else if (dir == 1)
                    {
                        // 下
                        posX += 0;
                        posY += -1;
                    }
                    else if (dir == 2)
                    {
                        // 左
                        posX += -1;
                        posY += 0;
                    }
                    else if (dir == 3)
                    {
                        // 上
                        posX += 0;
                        posY += 1;
                    }
                }
            }


            Console.WriteLine($"{posX} {posY}");
        }
    }
}