using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC257A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, x) = ReadValue<int, int>();

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++) sb.Append('A');
            for (int i = 0; i < n; i++) sb.Append('B');
            for (int i = 0; i < n; i++) sb.Append('C');
            for (int i = 0; i < n; i++) sb.Append('D');
            for (int i = 0; i < n; i++) sb.Append('E');
            for (int i = 0; i < n; i++) sb.Append('F');
            for (int i = 0; i < n; i++) sb.Append('G');
            for (int i = 0; i < n; i++) sb.Append('H');
            for (int i = 0; i < n; i++) sb.Append('I');
            for (int i = 0; i < n; i++) sb.Append('J');
            for (int i = 0; i < n; i++) sb.Append('K');
            for (int i = 0; i < n; i++) sb.Append('L');
            for (int i = 0; i < n; i++) sb.Append('M');
            for (int i = 0; i < n; i++) sb.Append('N');
            for (int i = 0; i < n; i++) sb.Append('O');
            for (int i = 0; i < n; i++) sb.Append('P');
            for (int i = 0; i < n; i++) sb.Append('Q');
            for (int i = 0; i < n; i++) sb.Append('R');
            for (int i = 0; i < n; i++) sb.Append('S');
            for (int i = 0; i < n; i++) sb.Append('T');
            for (int i = 0; i < n; i++) sb.Append('U');
            for (int i = 0; i < n; i++) sb.Append('V');
            for (int i = 0; i < n; i++) sb.Append('W');
            for (int i = 0; i < n; i++) sb.Append('X');
            for (int i = 0; i < n; i++) sb.Append('Y');
            for (int i = 0; i < n; i++) sb.Append('Z');

            var str = sb.ToString();
            Console.WriteLine(str[x - 1]);
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