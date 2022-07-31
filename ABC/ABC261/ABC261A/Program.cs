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

namespace ABC261A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (l1, r1, l2, r2) = ReadValue<int, int, int, int>();

            var red = new bool[101];
            var blue = new bool[101];

            for (int i = l1; i <=r1; i++)
            {
                red[i] = true;
            }
            
            for (int i = l2; i <=r2; i++)
            {
                blue[i] = true;
            }


            var l = new List<int>();
            for (int i = 0; i <101; i++)
            {
                if (red[i] && blue[i])
                {
                    l.Add(i);
                }
            }

            if (l.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(l.Last() - l.First());
            

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
        
        public static (T1, T2, T3, T4) ReadValue<T1, T2, T3, T4>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2)),
                (T3) Convert.ChangeType(input[2], typeof(T3)),
                (T4) Convert.ChangeType(input[3], typeof(T4))
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