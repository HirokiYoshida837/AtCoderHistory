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
            var (Zx, Zy) = ReadValue<int, int>();


            // var ABxBP = Cross((Ax, Ay), (Bx, By), (Bx, By), (Zx, Zy));
            // var BCxCP = Cross((Bx, By), (Cx, Cy), (Cx, Cy), (Zx, Zy));
            // var CAxAP = Cross((Cx, Cy), (Ax, Ay), (Ax, Ay), (Zx, Zy));
            //
            //
            // var b = (ABxBP >= 0 && BCxCP >= 0 && CAxAP >= 0) || (ABxBP <= 0 && BCxCP <= 0 && CAxAP <= 0);

            var px = new List<double>() {Ax, Bx, Cx, Zx};
            var py = new List<double>() {Ay, By, Cy, Zy};

            var concave = isConcave(px.ToArray(), py.ToArray());

            if (concave == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static int isInside(double ax, double ay, double bx, double by, double cx, double cy, double tx, double ty)
        {
            double abXat, bcXbt, caXct;

            abXat = (bx - ax) * (ty - ay) - (by - ay) * (tx - ax);
            bcXbt = (cx - bx) * (ty - by) - (cy - by) * (tx - bx);
            caXct = (ax - cx) * (ty - cy) - (ay - cy) * (tx - cx);

            if ((abXat > 0.0 && bcXbt > 0.0 && caXct > 0.0) || (abXat < 0.0 && bcXbt < 0.0 && caXct < 0.0))
            {
                return 1;
            }
            else if (abXat * bcXbt * caXct == 0.0)
            {
                return 0;
            }

            return 0;
        }

        static int isConcave(double[] px, double[] py)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                if (isInside(px[i % 4], py[i % 4], px[(i + 1) % 4], py[(i + 1) % 4], px[(i + 2) % 4], py[(i + 2) % 4],
                    px[(i + 3) % 4], py[(i + 3) % 4]) > 0)
                {
                    return 1;
                }
            }

            return 0;
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