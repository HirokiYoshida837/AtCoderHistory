using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleCode
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var l = new[] {1, 2, 5, 3, 4};

            Console.WriteLine(string.Join(" ", l));

            var sd = new SortedDictionary<int, int>();
            var sdCompare = new SortedDictionary<int, int>(Comparer<int>.Default);
            var sdCustom = new SortedDictionary<int, int>(new CustomComparer());
            var sdInv = new SortedDictionary<int, int>();

            foreach (var i in l)
            {
                sd.Add(i, i);
                sdCompare.Add(i, i);
                sdCustom.Add(i, i);
                sdInv.Add(-i, i);
            }

            Console.WriteLine(string.Join(" ", sd.Keys.ToList()));

            // Last -> `O(N)`なので逆順で入れる。
            Console.WriteLine($"sd \t\t first: {sd.First()} \t max: {sd.Last()}");
            Console.WriteLine($"sdRev \t\t first: {sdCompare.First()} \t max: {sdCompare.Last()}");
            Console.WriteLine($"sdCustom \t first: {sdCustom.First()} \t max: {sdCustom.Last()}");
            Console.WriteLine($"sdInv \t\t first: {sdInv.First()} \t max: {sdInv.Last()}");

            Console.WriteLine(sd);
        }

        public class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return -1 * Comparer<int>.Default.Compare(x, y);
            }
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2)),
                (T3) Convert.ChangeType(input[2], typeof(T3))
            );
        }

        /// <summary>
        /// 指定した型として、一行読み込む。
        /// </summary>
        /// <param name="separator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
#nullable enable
        public static IEnumerable<T> ReadList<T>(params char[]? separator)
        {
            return Console.ReadLine()
                .Split(separator)
                .Select(x => (T) Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}