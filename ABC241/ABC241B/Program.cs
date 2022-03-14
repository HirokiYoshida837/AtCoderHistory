using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC241B
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
            var n = nm[0];
            var m = nm[1];

            var a = Console.ReadLine().Split().Select(long.Parse).ToList();
            var b = Console.ReadLine().Split().Select(long.Parse).ToList();


            var pastaMap = new Dictionary<long, long>();
            foreach (var l in a)
            {
                if (pastaMap.ContainsKey(l))
                {
                    pastaMap[l]++;
                }
                else
                {
                    pastaMap.Add(l, 1);
                }
            }
            
            var ans = true;


            foreach (var l in b)
            {
                if (pastaMap.ContainsKey(l))
                {
                    if (pastaMap[l] <= 0)
                    {
                        ans = false;
                        break;
                    }
                    
                    pastaMap[l]--;
                }
                else
                {
                    ans = false;
                    break;
                }
            }


            Console.WriteLine(ans ? "Yes" : "No");
        }
    }
}