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

namespace ABC218C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = ReadValue<int>();

            char[,] S = new char[n, n];
            char[,] T = new char[n, n];


            for (int i = 0; i < n; i++)
            {
                var readValue = ReadValue<string>();
                for (var i1 = 0; i1 < readValue.Length; i1++)
                {
                    S[i, i1] = readValue[i1];
                }
            }

            for (int i = 0; i < n; i++)
            {
                var readValue = ReadValue<string>();
                for (var i1 = 0; i1 < readValue.Length; i1++)
                {
                    T[i, i1] = readValue[i1];
                }
            }

            var cuttedS = GetS(S);
            var cuttedT = GetS(T);


            var ans = false;

            for (int i = 0; i < 4; i++)
            {
                var rotateClockwise = cuttedT.RotateClockwise(i);

                var arrT = new List<char>();
                foreach (var c in rotateClockwise)
                {
                    arrT.Add(c);
                }

                var t = new string(arrT.ToArray());

                var arrS = new List<char>();
                foreach (var c in cuttedS)
                {
                    arrS.Add(c);
                }

                var s = new string(arrS.ToArray());

                if (s == t)
                {
                    ans = true;
                }
            }

            Console.WriteLine(ans ? "Yes" : "No");
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


        public static char[,] GetS(char[,] read)
        {
            var xMin = read.GetLength(0);
            var xMax = 0;

            var yMin = read.GetLength(1);
            var yMax = 0;

            for (int i = 0; i < read.GetLength(0); i++)
            {
                for (int j = 0; j < read.GetLength(1); j++)
                {
                    if (read[i, j] == '#')
                    {
                        xMin = Math.Min(xMin, i);
                        xMax = Math.Max(xMax, i);
                        yMin = Math.Min(yMin, j);
                        yMax = Math.Max(yMax, j);
                    }
                }
            }

            char[,] newRead = new char[xMax - xMin + 1, yMax - yMin + 1];

            for (int i = xMin; i <= xMax; i++)
            {
                for (int j = yMin; j <= yMax; j++)
                {
                    newRead[i - xMin, j - yMin] = read[i, j];
                }
            }

            return newRead;
        }
    }


    /**
     * 
     * https://baba-s.hatenablog.com/entry/2019/11/05/150000
     */
    public static class ArrayExt
    {
        // 時計回りに 90 度回転
        public static T[,] RotateClockwise<T>(this T[,] self)
        {
            int rows = self.GetLength(0);
            int columns = self.GetLength(1);
            var result = new T[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[j, rows - i - 1] = self[i, j];
                }
            }

            return result;
        }

        // 時計回りに 90 * count 度回転
        public static T[,] RotateClockwise<T>(this T[,] self, int count)
        {
            for (int i = 0; i < count; i++)
            {
                self = self.RotateClockwise();
            }

            return self;
        }

        // 反時計回りに 90 度回転
        public static T[,] RotateAnticlockwise<T>(this T[,] self)
        {
            int rows = self.GetLength(0);
            int columns = self.GetLength(1);
            var result = new T[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[columns - j - 1, i] = self[i, j];
                }
            }

            return result;
        }

        // 反時計回りに 90 * count 度回転
        public static T[,] RotateAnticlockwise<T>(this T[,] self, int count)
        {
            for (int i = 0; i < count; i++)
            {
                self = self.RotateAnticlockwise();
            }

            return self;
        }
    }
}