using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC181C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var xyList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<float, float>())
                .ToArray();

            foreach (var from in xyList)
            {
                var vf = new Vector2(from.Item1, from.Item2);
                var dic = new Dictionary<Vector2, int>();

                foreach (var dest in xyList)
                {
                    var vd = new Vector2(dest.Item1, dest.Item2);
                    if (vd==vf)
                    {
                        continue;
                    }

                    var v = vd - vf;
                    // var vn = v / v.Length();
                    var vn = Vector2.Normalize(v);
                    if (!dic.TryAdd(vn, 1))
                    {
                        dic[vn] += 1;
                    }
                    
                    if (!dic.TryAdd(-vn, 1))
                    {
                        dic[-vn] += 1;
                    }
                    
                }

                var count = dic.Values.Count(x=>x>=2);
                if (count >= 1)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
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