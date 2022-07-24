using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC237D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine().ToCharArray();

            var list = new LinkedList<int>();
            list.AddLast(0);

            var lastLinkedListNode = list.Last;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == 'L')
                {
                    lastLinkedListNode= list.AddBefore(lastLinkedListNode, i+1);
                }
                else
                {
                    lastLinkedListNode= list.AddAfter(lastLinkedListNode, i+1);
                }
            }
            
            
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }


            Console.WriteLine();
        }
    }
}