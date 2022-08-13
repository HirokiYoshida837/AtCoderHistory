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

namespace ABC264C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (h1, w1) = ReadValue<int, int>();
            var aMatrix = Enumerable.Range(0, h1)
                .Select(_ => ReadList<long>().ToList())
                .ToList();

            var (h2, w2) = ReadValue<int, int>();
            var bMatrix = Enumerable.Range(0, h2)
                .Select(_ => ReadList<long>().ToList())
                .ToList();


            var bJoined = String.Join(' ', bMatrix.Select(x => String.Join(' ', x)));


            for (int bitH = 0; bitH < 1 << h1; bitH++)
            {
                var bitHS = Convert.ToString(bitH, 2).PadLeft(h1, '0');

                // 0 を消す
                if (h1 - bitHS.Count(x => x == '0') != h2)
                {
                    continue;
                }


                for (int bitW = 0; bitW < 1 << w1; bitW++)
                {
                    var bitWS = Convert.ToString(bitW, 2).PadLeft(w1, '0');
                    
                    // 0 を消す
                    if (w1 - bitWS.Count(x => x == '0') != w2)
                    {
                        continue;
                    }

                    var list = aMatrix.Select(x => String.Join(',', x)).ToList();
                    var copyA = new List<List<long>>();
                    foreach (var s in list)
                    {
                        var longs = s.Split(',').Select(long.Parse).ToList();
                        copyA.Add(longs);
                    }

                    var removeHList = new List<int>();
                    for (var i = 0; i < bitHS.Length; i++)
                    {
                        var ch = bitHS[i];
                        if (ch == '0')
                        {
                            removeHList.Add(i);
                        }
                    }

                    var removeWList = new List<int>();
                    for (var i = 0; i < bitWS.Length; i++)
                    {
                        var ch = bitWS[i];
                        if (ch == '0')
                        {
                            removeWList.Add(i);
                        }
                    }

                    var hashSet = removeHList.ToHashSet();
                    copyA = copyA.Where((x, i) => !hashSet.Contains(i)).ToList();



                    var hashSet2 = removeWList.ToHashSet();
                    copyA = copyA.Select((x, i) => x.Where((y, j) => !hashSet2.Contains(j)).ToList()).ToList();

                    var aJoined = String.Join(' ', copyA.Select(x => String.Join(' ', x)));

                    // Console.WriteLine(aJoined);

                    if (aJoined == bJoined)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
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