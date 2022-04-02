using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC245C
{
    class Program
    {
        static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, k) = (nk[0], nk[1]);

            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var flg = false;


            for (int bit = 0; bit < 1<<n; bit++)
            {
                var s = Convert.ToString(bit, 2).PadLeft(n, '0');

                var list = s.Select((x, i) => x == '1' ? a[i] : b[i]).ToList();

                var l = new List<int>();
                for (var i = 1; i < list.Count; i++)
                {
                    l.Add(Math.Abs(list[i] - list[i-1]));
                }

                var findIndex = l.FindIndex(x=>x > k);

                if (findIndex < 0)
                {
                    flg = true;
                    break;
                }
            }

            Console.WriteLine(flg ? "Yes" : "No");


        }
    }
}