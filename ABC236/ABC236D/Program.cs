using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC236D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = new int[2 * n - 1][];

            for (int i = 0; i < 2 * n - 1; i++)
            {
                a[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            int ans = 0;

            _dfs(0, Enumerable.Range(0, 2 * n).ToList());
            Console.WriteLine(ans);

            void _dfs(int currentXor, List<int> list)
            {
                if (list.Count == 0)
                {
                    ans = Math.Max(ans, currentXor);
                    return;
                }

                var i = list[0];
                list.RemoveAt(0);


                for (int j = 0; j < list.Count; j++)
                {
                    var k = list[j];
                    list.RemoveAt(j);
                    _dfs(currentXor ^ a[i][k - i - 1], list);
                    list.Insert(j, k);
                }

                list.Insert(0, i);
            }
        }
    }
}