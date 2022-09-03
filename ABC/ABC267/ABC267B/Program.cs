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

namespace ABC267B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<String>();


            if (s[0] == '0')
            {
                // ある二つの異なる列であって、次の条件を満たすものが存在する。
                // それぞれの列には、立っているピンが 1 本以上存在する。
                // それらの列の間に、ピンが全て倒れている列が存在する。

                var arr = new List<List<char>>();
                arr.Add(new List<char>() {s[6]});
                arr.Add(new List<char>() {s[3]});
                arr.Add(new List<char>() {s[7], s[1]});
                arr.Add(new List<char>() {s[4], s[0]});
                arr.Add(new List<char>() {s[8], s[2]});
                arr.Add(new List<char>() {s[5]});
                arr.Add(new List<char>() {s[9]});

                // それぞれの列には、立っているピンが 1 本以上存在する。

                var flag = false;

                for (var i = 0; i < arr.Count; i++)
                {
                    for (var j = i + 1; j < arr.Count; j++)
                    {
                        var charsI = arr[i];
                        var charsJ = arr[j];


                        // それぞれの列には、立っているピンが 1 本以上存在する。
                        if (charsI.Contains('1') && charsJ.Contains('1'))
                        {
                            // それらの列の間に、ピンが全て倒れている列が存在する。
                            for (var k = i+1; k < j; k++)
                            {
                                var charsK = arr[k];

                                if (charsK.All(x=>x=='0'))
                                {
                                    Console.WriteLine("Yes");
                                    return;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("No");
                return;
                
            }
            else
            {
                Console.WriteLine("No");
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