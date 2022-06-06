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

namespace ABC180D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var xyab = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var (x, y, a, b) = (xyab[0], xyab[1], xyab[2], xyab[3]);

            // a倍するのが、いつ +b を超えるのか計算する
            var currentStr = x;
            var currentExp = 0L;
            while (true)
            {
                var kakoDiff = long.MaxValue;
                try
                {
                    checked
                    {
                        kakoDiff = (a - 1) * currentStr;
                    }
                }
                catch (Exception e)
                {
                    break;
                }

                if (b >= kakoDiff)
                {
                    if (y <= currentStr + kakoDiff )
                    {
                        break;
                    }
                    else
                    {
                        currentStr += kakoDiff;
                        currentExp++;
                    }

                }
                else
                {
                    break;
                }
            }

            var remainDiff = (y - 1) - currentStr;
            if (remainDiff>=0)
            {
                currentExp += (remainDiff / b);
                Console.WriteLine(currentExp);
            }
            else
            {
                Console.WriteLine(currentExp);
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