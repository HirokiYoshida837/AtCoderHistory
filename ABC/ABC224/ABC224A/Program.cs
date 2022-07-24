using System;

namespace ABC224A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();

            if (s.EndsWith("er"))
            {
                Console.WriteLine("er");
            }
            else
            {
                Console.WriteLine("ist");
            }
        }
    }
}