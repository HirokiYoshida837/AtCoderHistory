using System;

namespace ABC219A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var x = ReadValue<int>();

            if (x < 40)
            {
                Console.WriteLine($"{40 - x}");
            }
            else if (x < 70)
            {
                Console.WriteLine($"{70 - x}");
            }
            else if (x < 90)
            {
                Console.WriteLine($"{90 - x}");
            }
            else
            {
                Console.WriteLine("expert");
            }
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }
    }
}