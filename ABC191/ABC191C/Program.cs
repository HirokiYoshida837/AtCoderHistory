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

namespace ABC191C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w) = ReadValue<int, int>();
            var s = Enumerable.Range(0, h)
                .Select(_ => ReadValue<string>().ToCharArray())
                .ToArray();
            
            // 角の個数を数えていく。
            var ans = 0;

            for (int i = 0; i < h-1; i++)
            {
                for (int j = 0; j < w-1; j++)
                {
                    int count = 0;
                    // 2x2の四角形をずらしていく形で探索。
                    for (int di = 0; di < 2; di++)
                    {
                        for (int dj = 0; dj < 2; dj++)
                        {
                            if (s[i+di][j+dj] =='#')
                            {
                                count++;
                            }
                        }
                    }
                    
                    if (count==1 || count== 3)
                    {
                        ans++;
                    }
                }
            }

            Console.WriteLine(ans);
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