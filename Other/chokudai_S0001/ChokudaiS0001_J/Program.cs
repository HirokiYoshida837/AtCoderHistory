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

namespace ChokudaiS0001_J
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var n = ReadValue<int>();
            var aList = ReadList<int>().ToArray();
 
            var max = aList.Max();
 
            var bitTree = new BIT(max + 1);
 
            var ans = 0L;
 
            for (int j = 0; j < max; j++)
            {
                var sum = j - bitTree.Sum(aList[j]);
                ans += sum;
                bitTree.Add(aList[j], 1);
            }
 
            Console.WriteLine(ans);
        }

        public class BIT
        {
            // 配列の要素数 (数列の要素 + 1)
            private int n { get; }
 
            // データの格納先 (1-indexed)。初期値は0。
            private int[] bit { get; }
 
            public BIT(int n)
            {
                this.n = n;
                this.bit = new int[n+1];
            }
 
            // index i に tを加算する (a_i += x)
            public void Add(int i, int x)
            {
                // LSBが1のところにだけ足す
                // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
                for (int index = i; index < n; index += (index & -index))
                {
                    bit[index] += x;
                }
            }
 
            // 最初からi番目までの和
            public long Sum(int i)
            {
                var sum = (long)bit[0];
                // LSBが1のところだけ足していく。
                for (int index = i; index >0; index-=(index & -index))
                {
                    sum += bit[index];
                }
 
                return sum;
            }
            
            // TODO 区間加算も実装しておく？
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