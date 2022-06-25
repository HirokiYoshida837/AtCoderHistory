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

namespace ABC173C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h, w, k) = ReadValue<int, int, int>();

            var cMatrix = Enumerable.Range(0, h)
                .Select(_ => ReadValue<string>().ToCharArray())
                .ToArray();

            var ans = 0L;

            // bit全探索
            for (int bitH = 0; bitH < 1 << h; bitH++)
            {
                var bitHS = Convert.ToString(bitH, 2).PadLeft(h, '0');
                
                for (int bitW = 0; bitW < 1 << w; bitW++)
                {
                    var bitWS = Convert.ToString(bitW, 2).PadLeft(w, '0');
                    
                    // 1 は塗りつぶし、 0 は塗りつぶさない
                    var copyCArray = string.Join(' ', cMatrix.Select(x=>new string(x)));
                    var copyC = copyCArray.Split(' ')
                        .Select(x=>x.ToCharArray())
                        .ToArray();

                    for (int i = 0; i < h; i++)
                    {
                        for (int j = 0; j < w; j++)
                        {
                            var bi = bitHS[i] == '1';
                            var bj = bitWS[j] == '1';

                            if (bi || bj)
                            {
                                copyC[i][j] = 'R';
                            }
                        }
                    }

                    var count = copyC.SelectMany(x=>x)
                        .Count(x=>x=='#');

                    if (count == k)
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