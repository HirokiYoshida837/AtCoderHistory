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

namespace ABC266C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (Ax, Ay) = ReadValue<int, int>();
            var (Bx, By) = ReadValue<int, int>();
            var (Cx, Cy) = ReadValue<int, int>();
            var (Dx, Dy) = ReadValue<int, int>();


            (int x, int y) A = (Ax, Ay);
            (int x, int y) B = (Bx, By);
            (int x, int y) C = (Cx, Cy);

            (int x, int y) D = (Dx, Dy);

            // 全部の場合について、三角形の外側に点があるかどうかを判定。
            var DinABC = IsInsideOfTriangle(A, B, C, D);
            var AinBCD = IsInsideOfTriangle(B, C, D, A);
            var BinCDA = IsInsideOfTriangle(C, D, A, B);
            var CinDAB = IsInsideOfTriangle(D, A, B, C);

            if (!DinABC && !AinBCD && !BinCDA && !CinDAB)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }


        public static bool IsInsideOfTriangle((int x, int y) A, (int x, int y) B, (int x, int y) C, (int x, int y) P)
        {
            //AB x BP, BC x CP, CA x AP
            var ABxBP = Cross(A, B, B, P);
            var BCxCP = Cross(B, C, C, P);
            var CAxAP = Cross(C, A, A, P);

            // 全部の外積の向きが同じなら三角形の内側にあると判定。
            return (ABxBP >= 0 && BCxCP >= 0 && CAxAP >= 0) || (ABxBP <= 0 && BCxCP <= 0 && CAxAP <= 0);
        }


        public static int Cross((int x, int y) A, (int x, int y) B, (int x, int y) C, (int x, int y) D)
        {
            (int x, int y) AB = (A.x - B.x, A.y - B.y);
            (int x, int y) CD = (C.x - D.x, C.y - D.y);

            return (AB.x * CD.y - AB.y * CD.x);
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