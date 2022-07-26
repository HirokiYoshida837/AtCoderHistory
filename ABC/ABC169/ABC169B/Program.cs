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

namespace ABC169B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var aList = ReadList<long>().ToArray();

            if (aList.Count(x => x==0) > 0)
            {
                Console.WriteLine(0);
                return;
            }

            try
            {
                checked
                {
                    var ans = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        ans *= aList[i];

                        if (ans >1000000000000000000)
                        {
                            Console.WriteLine(-1);
                            return;
                        }
                    }

                    Console.WriteLine(ans);
                    return;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(-1);
                return;
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