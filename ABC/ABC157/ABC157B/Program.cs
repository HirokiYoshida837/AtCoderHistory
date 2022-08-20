using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC157B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var aMatrix = Enumerable.Range(0, 3)
                .Select(_ => ReadList<int>().ToArray())
                .ToArray();

            var flatten = aMatrix.SelectMany(x=>x).Select((x,i)=>(x,i)).ToList();

            var n = ReadValue<int>();
            var bList = Enumerable.Range(0, n)
                .Select(_ => ReadValue<int>())
                .ToArray();

            // var punched = new bool[3, 3];

            var punched = new List<int>();
            
            foreach (var b in bList)
            {
                var findAll = flatten.FindAll(x => x.x == b).Select(x => x.i).ToList();
                punched.AddRange(findAll);
            }

            var dic  = punched.OrderBy(x => x).ToHashSet();

            for (int i = 0; i <=2; i++)
            {
                var contains = dic.Contains(i) && dic.Contains(3+i) && dic.Contains(6+i);
                if (contains)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            
            for (int i = 0; i <=2; i++)
            {
                var contains = dic.Contains(3*i+0) && dic.Contains(3*i+1) && dic.Contains(3*i+2);
                if (contains)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            
            if (dic.Contains(0)&&dic.Contains(4)&& dic.Contains(8))
            {
                Console.WriteLine("Yes");
                return;
            }
            
            if (dic.Contains(2)&&dic.Contains(4)&& dic.Contains(6))
            {
                Console.WriteLine("Yes");
                return;
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