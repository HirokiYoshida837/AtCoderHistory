using System.Collections.Generic;
using System.Linq;

namespace ABCUtils.MathUtils
{
    // エラトステネスの篩（適当実装）
    public class EratosthenesSieve
    {
        // 適当実装なのでバグってるかも
        public static IEnumerable<int> calc(int n)
        {
            var primes = Enumerable.Range(0,2*n).Select(_=>true).ToArray();

            primes[0] = false;
            primes[1] = false;
            primes[2] = true;
            primes[^1] = false;

            for (long p = 2; p < primes.Length; p++)
            {
                if (primes[p])
                {
                    for (long i = p * p; i < primes.Length; i += p)
                    {
                        primes[i] = false;
                    }
                }
            }

            for (var i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    yield return i;
                }
            }
        }
    }
}
