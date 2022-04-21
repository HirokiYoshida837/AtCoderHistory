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

namespace ABC231D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();

            List<(int a, int b)> abs = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToList();

            var unionFind = new UnionFind(n+1);

            var count = new int[n + 1];

            foreach (var (a, b) in abs)
            {
                count[a]++;
                count[b]++;
                
                if (count[a] >= 3)
                {
                    Console.WriteLine("No");
                    return;
                }
                if (count[b] >= 3)
                {
                    Console.WriteLine("No");
                    return;
                }

                var tryUnite = unionFind.TryUnite(a, b);
                if (!tryUnite)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
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

    public class UnionFind
    {
        public int Size { get; private set; }
        public int GroupCount { get; private set; }

        private int[] Parent;
        private int[] Sizes;

        public UnionFind(int count)
        {
            this.Size = count;
            this.GroupCount = count;

            Parent = new int[count];
            Sizes = new int[count];

            for (int i = 0; i < count; i++)
            {
                Parent[i] = i;
                Sizes[i] = 1;
            }
        }

        public bool TryUnite(int x, int y)
        {
            var xp = Find(x);
            var yp = Find(y);
            if (xp == yp)
            {
                return false;
            }

            if (Sizes[xp] < Sizes[yp])
            {
                var tmp = xp;
                xp = yp;
                yp = tmp;
            }

            GroupCount--;

            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
            return true;
        }

        public int Find(int x)
        {
            while (x != Parent[x])
            {
                x = (Parent[x] = Parent[Parent[x]]);
            }

            return x;
        }

        public IEnumerable<int> AllRepresents()
        {
            return Parent.Where((x, y) => x == y);
        }

        public int GetSize(int x)
        {
            return Sizes[Find(x)];
        }
    }
}