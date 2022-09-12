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

namespace ABC250C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, q) = ReadValue<int, int>();
            var x = Enumerable.Range(0, q)
                .Select(_ => ReadValue<int>())
                .ToArray();

            var dicFromNum = Enumerable.Range(1, n)
                .ToDictionary(x => x, x => x);

            var array = Enumerable.Range(0, n + 1).ToArray();


            foreach (var i in x)
            {
                var currentIndex = dicFromNum[i];

                if (currentIndex == n)
                {
                    // 左側のぼーるを探す
                    var leftBallNum = array[currentIndex - 1];

                    // 入れ替える
                    (array[currentIndex - 1], array[currentIndex]) = (array[currentIndex], array[currentIndex-1]);
                    
                    // 辞書を更新
                    dicFromNum[i] = currentIndex -1;
                    dicFromNum[leftBallNum] = currentIndex;
                    
                    
                }
                else
                {
                    // 右側のぼーるを探す
                    var rightBallNum = array[currentIndex + 1];

                    // 入れ替える
                    (array[currentIndex], array[currentIndex + 1]) = (array[currentIndex + 1], array[currentIndex]);
                    
                    // 辞書を更新
                    dicFromNum[i] = currentIndex + 1;
                    dicFromNum[rightBallNum] = currentIndex;
                }
            }


            var @join = String.Join(' ', array.Skip(1));
            Console.WriteLine(join);
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