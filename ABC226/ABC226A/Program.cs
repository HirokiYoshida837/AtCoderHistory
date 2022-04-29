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

namespace ABC226A
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine().Split('.').ToArray();

            var l = int.Parse(s[0]);
            var r = int.Parse(char.ToString(s[1][0]));

            if (r>=5)
            {
                l += 1;
            }

            Console.WriteLine(l);

        }


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }
        
    }
}