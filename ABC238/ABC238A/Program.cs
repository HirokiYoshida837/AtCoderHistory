using System;

namespace ABC238A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("Yes");
            }
            else if (n == 2)
            {
                Console.WriteLine("No");
            }
            else if (n == 3)
            {
                Console.WriteLine("No");
            }
            else if (n==4)
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