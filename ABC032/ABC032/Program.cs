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

namespace ABC229D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine().ToCharArray();
            var k = int.Parse(Console.ReadLine());
            
            var ans = 0L;
            var que = new Queue<int>();
            var score = 0;
            foreach (var c in s)
            {
                que.Enqueue(c);
                if (c == '.') score++;

                while (score > k)
                {
                    var dequeue = que.Dequeue();
                    if (dequeue == '.') score--;
                }

                ans = Math.Max(ans, que.Count);
            }

            Console.WriteLine(ans);
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }
    }
}