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

namespace ABC168C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var abhm = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var (a, b, h, m) = (abhm[0], abhm[1], abhm[2], abhm[3]);

            // 時針は、分で進む分も考慮しないと行けない。
            var degreeH = (360d / 12d) * (h + m / 60d);
            var degreeM = (360d / 60d) * m;

            // そのまま掛けると反時計回りになってデバッグ時に混乱するので、逆回転にする
            var thetaH = -1 * (degreeH / 360d) * Math.PI * 2;
            var thetaM = -1 * (degreeM / 360d) * Math.PI * 2;

            // 複素数ベクトルの回転で考える。
            var vecH = new Complex(0d, 1d);
            var rotH = new Complex(Math.Cos(thetaH), Math.Sin(thetaH));
            vecH *= rotH;
            vecH *= a;
            
            var vecM = new Complex(0d, 1d);
            var rotM = new Complex(Math.Cos(thetaM), Math.Sin(thetaM));
            
            vecM *= rotM;
            vecM *= b;

            var magnitude = (vecH - vecM).Magnitude;
            Console.WriteLine(magnitude);
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