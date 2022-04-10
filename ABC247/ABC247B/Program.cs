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

namespace ABC247B
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var st = Enumerable.Range(0, n)
                .Select(x => Console.ReadLine().Split().ToList())
                // .Select(x => (x[0], x[1]))
                .ToList();

            for (int i = 0; i < n; i++)
            {
                var canGivenANickName = false;
                
                foreach (var s in st[i])
                {
                    var s_ok = true;

                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            if (s == st[j][0] || s == st[j][1])
                            {
                                s_ok = false;
                            }
                        }
                    }

                    if (s_ok)
                    {
                        canGivenANickName = true;
                    }
                }

                if (!canGivenANickName)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
            
        }
    }
}