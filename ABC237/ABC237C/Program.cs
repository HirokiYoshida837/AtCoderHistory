using System;
using System.Linq;
using System.Text;

namespace ABC237C
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();

            var l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    l++;
                }
                else
                {
                    break;
                }
            }

            var revS = new string(s.Reverse().ToArray());

            var r = 0;
            for (var i = 0; i < revS.Length; i++)
            {
                if (revS[i] == 'a')
                {
                    r++;
                }
                else
                {
                    break;
                }
            }

            if (l > r)
            {
                Console.WriteLine("No");
                return;
            }

            var sb = new StringBuilder().Append(revS);

            for (int i = 0; i < r-l; i++)
            {
                sb.Append("a");
            }
            
            var s1 = sb.ToString();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s1[s1.Length - 1 - i])
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
            
        }
    }
}