using System;

namespace ABC109A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b) = ReadValue<int, int>();

            Console.WriteLine(a * b % 2 == 0 ? "No" : "Yes");
        }


        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }
    }
}