using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC241C
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToList();

            var ans = false;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + 5 < n)
                    {
                        var count = 0;
                        for (int k = 0; k < 6; k++)
                        {
                            if (s[i + k][j] == '#')
                            {
                                count++;
                            }
                        }

                        if (count >= 4)
                        {
                            ans = true;
                        }
                    }

                    if (j + 5 < n)
                    {
                        var count = 0;
                        for (int k = 0; k < 6; k++)
                        {
                            if (s[i][j + k] == '#')
                            {
                                count++;
                            }
                        }

                        if (count >= 4)
                        {
                            ans = true;
                        }
                    }


                    if (i + 5 < n && j + 5 < n)
                    {
                        var count = 0;
                        for (int k = 0; k < 6; k++)
                        {
                            if (s[i + k][j + k] == '#')
                            {
                                count++;
                            }
                        }

                        if (count >= 4)
                        {
                            ans = true;
                        }
                    }

                    if (i - 5 >= 0 && j + 5 < n)
                    {
                        var count = 0;
                        for (int k = 0; k < 6; k++)
                        {
                            if (s[i - k][j + k] == '#')
                            {
                                count++;
                            }
                        }

                        if (count >= 4)
                        {
                            ans = true;
                        }
                    }
                }
            }

            Console.WriteLine(ans ? "Yes" : "No");
        }
    }
}