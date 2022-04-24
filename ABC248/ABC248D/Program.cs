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

namespace ABC248C
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            var q = int.Parse(Console.ReadLine());
            List<(int l, int r, int x)> queries = Enumerable.Range(0, q)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray())
                .Select(x => (x[0], x[1], x[2]))
                .ToList();
            
            // a中の各数字が、どのindexで出てくるかを全部メモする。0から順に実施するのでソート済。
            List<int>[] arr = Enumerable.Repeat(0, 200001).Select(_ => new List<int>()).ToArray();
            for (int i = 0; i < a.Count; i++)
            {
                arr[a[i]].Add(i);
            }
            
            foreach (var (l,r,x) in queries)
            {
                var ints = arr[x];

                // ソート済なのでBinarySearchが使える
                var lind = ints.BinarySearch(l-1);
                if (lind < 0)
                {
                    lind = ~lind;
                }

                var rind = ints.BinarySearch(r);
                if (rind < 0)
                {
                    rind = ~rind;
                }
                
                Console.WriteLine(rind - lind);
            }


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