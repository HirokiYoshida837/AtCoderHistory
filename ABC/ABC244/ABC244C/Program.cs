using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;

namespace ABC244C
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var hashSet = Enumerable.Range(0, 2 * n + 1).Select(x => x).ToHashSet();
            hashSet.Remove(2*n + 1);
            hashSet.Remove(0);
            
            Console.WriteLine(2 * n + 1);

            while (true)
            {
                var read = int.Parse(Console.ReadLine());

                if (read == 0)
                {
                    return;
                }

                hashSet.Remove(read);
                var last = hashSet.Last();
                Console.WriteLine(last);
                hashSet.Remove(last);
            }
        }
    }
}