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

namespace ABC225D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, q) = ReadValue<int, int>();
            (int type, int x, int y)[] queries = Enumerable.Range(0, q)
                .Select(_ =>
                {
                    var read = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    if (read.Length == 3)
                    {
                        return (read[0], read[1], read[2]);
                    }
                    else
                    {
                        return (read[0], read[1], -1);
                    }
                })
                .ToArray();


            var tree = new Tree(n + 1);


            foreach (var (type, x, y) in queries)
            {
                if (type == 1)
                {
                    tree.Union(x, y);
                }
                else if (type == 2)
                {
                    tree.Disconnect(x, y);
                }
                else
                {
                    var g = tree.getGroup(x);
                    var joined = string.Join(' ', g);
                    Console.WriteLine($"{g.Length} {joined}");
                }
            }
        }

        public class Tree
        {
            private int[] before;
            private int[] after;

            public Tree(int n)
            {
                this.before = new int[n];
                this.after = new int[n];
                before = before.Select(_ => -1).ToArray();
                after = after.Select(_ => -1).ToArray();
            }

            public void Union(int a, int b)
            {
                after[a] = b;
                before[b] = a;
            }

            public void Disconnect(int a, int b)
            {
                after[a] = -1;
                before[b] = -1;
            }

            public int[] getGroup(int a)
            {
                // rootを探したあと、rootから後ろ向きに辿っていく。
                var root = getRoot(a);
                var arr = new List<int>() {root};
                var next = root;
                while (true)
                {
                    next = after[arr.Last()];
                    if (next == -1)
                    {
                        break;
                    }

                    arr.Add(next);
                }

                return arr.ToArray();
            }

            public int getRoot(int a)
            {
                // 再帰でもいいが、whileループでも書ける
                // if (before[a] != -1 && before[a] != a)
                // {
                //     return getRoot(before[a]);
                // }
                // else
                // {
                //     return a;
                // }
                while (true)
                {
                    if (before[a] != -1 && before[a] != a)
                    {
                        a = before[a];
                    }
                    else
                    {
                        return a;
                    }
                }
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