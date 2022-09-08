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

namespace Hard_018
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var read = Console.ReadLine().Split().Select(int.Parse).ToArray();

            (int x, int y) s = (read[0], read[1]);
            (int x, int y) t = (read[2], read[3]);


            var ans = new Dictionary<int, List<string>>();
            // u to l
            {
                var UtoL = new List<string>();

                var start1 = (s.x, s.y + 1);
                var target1 = (t.x - 1, t.y);
                var diff1 = (target1.Item1 - start1.Item1, target1.Item2 - start1.Item2);

                // u移動を diff.y回
                UtoL.AddRange(Enumerable.Repeat("U", diff1.Item2).ToList());
                // r移動を diff.x回
                UtoL.AddRange(Enumerable.Repeat("R", diff1.Item1).ToList());

                UtoL.Insert(0, "U");
                UtoL.Add("R");
                ans.Add(1, UtoL);
            }
            
            // t.d -> s.r
            {
                var RtoD = new List<string>();
                var start1 = (s.x + 1, s.y);
                var target1 = (t.x, t.y - 1);
                var diff1 = (target1.Item1 - start1.Item1, target1.Item2 - start1.Item2);

                RtoD.AddRange(Enumerable.Repeat("D", diff1.Item2).ToList());
                RtoD.AddRange(Enumerable.Repeat("L", diff1.Item1).ToList());
                
                RtoD.Insert(0, "D");
                RtoD.Add("L");
                ans.Add(2, RtoD);
            }
            
            
            // s.l -> t.u
            {
                var LtoU = new List<string>();

                var start1 = (s.x - 1, s.y);
                var target1 = (t.x, t.y + 1);
                var diff1 = (target1.Item1 - start1.Item1, target1.Item2 - start1.Item2);

                // u移動を diff.y回
                LtoU.AddRange(Enumerable.Repeat("U", diff1.Item2).ToList());
                // r移動を diff.x回
                LtoU.AddRange(Enumerable.Repeat("R", diff1.Item1).ToList());

                LtoU.Insert(0, "L");
                LtoU.Add("D");
                ans.Add(3, LtoU);
            }


            // t.r to s.u
            {
                var DtoR = new List<string>();
                
                var start1 = (s.x, s.y - 1);
                var target1 = (t.x + 1, t.y);
                var diff1 = (target1.Item1 - start1.Item1, target1.Item2 - start1.Item2);

                // u移動を diff.y回
                DtoR.AddRange(Enumerable.Repeat("D", diff1.Item2).ToList());
                // r移動を diff.x回
                DtoR.AddRange(Enumerable.Repeat("L", diff1.Item1).ToList());
                
                DtoR.Insert(0, "R");
                DtoR.Add("U");
                ans.Add(4, DtoR);
            }

            // out
            var sb = new StringBuilder();
            foreach (var keyValuePair in ans.OrderBy(x => x.Key))
            {
                var aggregate = keyValuePair.Value.Aggregate((a, b) => a + b);
                sb.Append(aggregate);
            }

            var s1 = sb.ToString();
            Console.WriteLine(s1);
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