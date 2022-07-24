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

namespace ABC224C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            (int x, int y)[] xy = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            var count = 0L;

            for (int a = 0; a < n; a++)
            {
                for (int b = a + 1; b < n; b++)
                {
                    for (int c = b + 1; c < n; c++)
                    {
                        var va = xy[a];
                        var vb = xy[b];
                        var vc = xy[c];

                        var ab = (va.x - vb.x, va.y - vb.y);
                        var cb = (vc.x - vb.x, vc.y - vb.y);

                        // 外積が0でない => 面積がある => 三角形を形成できている
                        var ABxCB = ab.Item1 * cb.Item2 - ab.Item2 * cb.Item1;

                        if (ABxCB != 0)
                        {
                            count++;
                        }

                    }
                }
            }

            Console.WriteLine(count);
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