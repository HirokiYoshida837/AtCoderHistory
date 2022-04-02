using System;
using System.Linq;

namespace ABC245A
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcd = Console.ReadLine().Split().Select(int.Parse).ToList();

            if (abcd[0] < abcd[2])
            {
                Console.WriteLine("Takahashi");
                return;
            }

            if (abcd[0] == abcd[2])
            {
                if (abcd[1] == abcd[3])
                {
                    Console.WriteLine("Takahashi");
                    return;
                }
                else if (abcd[1] < abcd[3])
                {
                    Console.WriteLine("Takahashi");
                    return;
                }
                else
                {
                    Console.WriteLine("Aoki");
                    return;
                }
            }


            Console.WriteLine("Aoki");
        }
    }
}