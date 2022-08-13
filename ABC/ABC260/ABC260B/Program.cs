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

namespace ABC260A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nxyz = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = nxyz[0];
            var x = nxyz[1];
            var y = nxyz[2];
            var z = nxyz[3];

            var aList = ReadList<int>().ToArray();
            var bList = ReadList<int>().ToArray();
            
            var gokaku = new HashSet<int>();

            var dic = new Dictionary<int, Score>();
            for (int i = 0; i < n; i++)
            {
                var score = new Score()
                {
                    userId = i + 1,
                    aScore = aList[i],
                    bScore = bList[i],
                    sumScore = aList[i] + bList[i]
                };

                dic.Add(i + 1, score);
            }

            var keyValuePairsA = dic.OrderByDescending(x=>x.Value.aScore).Take(x).ToList();
            foreach (var keyValuePair in keyValuePairsA)
            {
                gokaku.Add(keyValuePair.Key);
                dic.Remove(keyValuePair.Key);
            }
            
            var keyValuePairsB = dic.OrderByDescending(x=>x.Value.bScore).Take(y).ToList();
            foreach (var keyValuePair in keyValuePairsB)
            {
                gokaku.Add(keyValuePair.Key);
                dic.Remove(keyValuePair.Key);
            }
            
            var keyValuePairsSum = dic.OrderByDescending(x=>x.Value.sumScore).Take(z).ToList();
            foreach (var keyValuePair in keyValuePairsSum)
            {
                gokaku.Add(keyValuePair.Key);
                dic.Remove(keyValuePair.Key);
            }
            
            
            foreach (var i in gokaku.OrderBy(x=>x))
            {
                Console.WriteLine(i);
            }



            //
            // var sortedA = aList.Select((item, i) => (item, i)).OrderByDescending(x => x.item).ToArray();
            // var takeA = sortedA.Take(x).Select(x => x.i).ToArray();
            //
            // foreach (var i in takeA)
            // {
            //     gokaku.Add(i);
            // }
            //
            // var sortedB = bList.Select((item, i) => (item, i)).OrderByDescending(x => x.item).ToArray();
            //
            // var countB = 0L;
            // foreach (var valueTuple in sortedB)
            // {
            //     if (countB >= y)
            //     {
            //         break;
            //     }
            //
            //     if (!gokaku.Contains(valueTuple.i))
            //     {
            //         gokaku.Add(valueTuple.i);
            //         countB++;
            //     }
            // }
            //
            // var sumList = new List<(int score, int index)>();
            //
            // for (int i = 0; i < n; i++)
            // {
            //     var i1 = aList[i];
            //     var i2 = bList[i];
            //     sumList.Add((i1 + i2, i));
            // }
            //
            // sumList = sumList.OrderByDescending(x => x.score).ToList();
            //
            // var sumCount = 0L;
            // for (int i = 0; i < n; i++)
            // {
            //     if (sumCount >= z)
            //     {
            //         break;
            //     }
            //     
            //     var valueTuple = sumList[i];
            //
            //     if (!gokaku.Contains(valueTuple.index))
            //     {
            //         gokaku.Add(valueTuple.index);
            //         sumCount++;
            //     }
            // }
            //
            // Console.WriteLine(gokaku);
            //
            // foreach (var i in gokaku.Select(x=>x+1).OrderBy(x=>x))
            // {
            //     Console.WriteLine(i);
            // }
        }

        public struct Score
        {
            public int userId;
            public int aScore;
            public int bScore;
            public int sumScore;
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1)Convert.ChangeType(input[0], typeof(T1)),
                (T2)Convert.ChangeType(input[1], typeof(T2)),
                (T3)Convert.ChangeType(input[2], typeof(T3))
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
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }
}