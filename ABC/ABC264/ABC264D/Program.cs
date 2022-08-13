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

namespace ABC264D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<string>().ToCharArray();

            var atcoder = "atcoder";
            var dictionary = atcoder.ToList().Select((x,i)=>(x,i))
                .ToDictionary(x=>x.x, x=>x.i);

            var count = 0L;
            // バブルソートを実装する。
            for (var i = 0; i < atcoder.Length; i++)
            {
                // target文字を探す
                var target = atcoder[i];
                
                // target文字の場所を探す
                var valueTuple = s.ToList().Select((x,i)=>(x,i)).First(x=>x.x==target);
                
                // 見つかった場所から配置すべき場所までswapし続ける
                for (int j = valueTuple.i; j >i; j--)
                {
                    (s[j - 1], s[j]) = (s[j], s[j - 1]);
                    count++;
                }

                // Console.WriteLine(s);
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