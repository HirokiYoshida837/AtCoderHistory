using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC240D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();

            var list = new List<(int A, int B)>();
            
            foreach (var item in a)
            {
                if (list.Count == 0)
                {
                    list.Add((item, 1));
                }
                else
                {
                    if (item == list[^1].A && list[^1].B+1 == list[^1].A)
                    {
                        var valueTuple = list[^1];
                        list.RemoveRange(list.Count - valueTuple.B, valueTuple.B);
                    }
                    else
                    {
                        if (item == list[^1].A)
                        {
                            list.Add((item, list[^1].B + 1));
                        }
                        else
                        {
                            list.Add((item, 1));
                        }
                    }
                }
                
                Console.WriteLine(list.Count);
            }
            
            
            

        }
    }
}