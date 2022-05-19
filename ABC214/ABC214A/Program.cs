using System;

namespace ABC214A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            if (n <= 125)
            {
                Console.WriteLine(4);
            }
            else if (n <= 211)
            {
                Console.WriteLine(6);
            }
            else
            {
                Console.WriteLine(8);
            }
        }
        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }
    }
}