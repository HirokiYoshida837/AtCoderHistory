using System;

class P
{
    static void Main()
    {
        var I = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
        var a = I[1] + I[2];
        Console.Write(I[0] / a * I[1] + Math.Min(I[0] % a, I[1]));
    }
}