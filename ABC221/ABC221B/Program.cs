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

namespace ABC221B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = ReadValue<String>();
            var t = ReadValue<String>();

            var ans = false;

            if (s == t)
            {
                Console.WriteLine("Yes");
                return;
            }


            for (int i = 1; i < s.Length; i++)
            {
                var tmp = s.ToArray();
                var tc = tmp[i];
                tmp[i] = tmp[i - 1];
                tmp[i - 1] = tc;

                if (new string(tmp) == t)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }
    }
}