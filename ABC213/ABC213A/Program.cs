using System;

namespace ABC213A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (a, b) = ReadValue<int, int>();

            Console.WriteLine(b^a);
            
            // 全探索するとこうなる
            // for (int c = 0; c <=255; c++)
            // {
            //     if ((a^c) == b)
            //     {
            //         Console.WriteLine(c);
            //         return;
            //     }
            // }
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