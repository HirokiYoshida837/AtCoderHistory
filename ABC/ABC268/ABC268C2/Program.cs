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

namespace ABC268C2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();
            var pList = ReadList<int>().ToList();

            // 最大でn-1回動かす
            var dic = new int[n];

            for (int i = 0; i < pList.Count; i++)
            {
                var p = pList[i];

                // 人 i は料理 i が人 (i−1)modN、人 i、人 (i+1)modN のいずれかの目の前に置かれていると喜びます
                // 料理pがスコアになるのは、

                // 料理pが以下の位置にいるときはスコアに関係する。 5 -> 4,5,0
                var pos1 = (p - 1) % n;
                var pos2 = (p - 0) % n;
                var pos3 = (p + 1) % n;


                {
                    // pos1までにかかる回転量
                    var m1 = -1;
                    if (i <= pos1)
                    {
                        m1 = pos1 - i;
                    }
                    else
                    {
                        m1 = pos1 + n - i;
                    }

                    // m1回回したときにスコアになるので、スコアに加算しておく。
                    dic[m1] += 1;
                }

                {
                    // pos1までにかかる回転量
                    var m2 = -1;
                    if (i <= pos2)
                    {
                        m2 = pos2 - i;
                    }
                    else
                    {
                        m2 = pos2 + n - i;
                    }

                    // m1回回したときにスコアになるので、スコアに加算しておく。
                    dic[m2] += 1;
                }

                {
                    // pos1までにかかる回転量
                    var m3 = -1;
                    if (i <= pos3)
                    {
                        m3 = pos3 - i;
                    }
                    else
                    {
                        m3 = pos3 + n - i;
                    }

                    // m1回回したときにスコアになるので、スコアに加算しておく。
                    dic[m3] += 1;
                }
            }

            Console.WriteLine(dic.Max());
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