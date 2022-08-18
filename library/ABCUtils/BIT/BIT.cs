namespace ABCUtils.BIT
{
            
    /// <summary>
    /// BIT(Binary Indexed Tree) 
    /// refs : https://www.slideshare.net/hcpc_hokudai/binary-indexed-tree
    /// https://algo-logic.info/binary-indexed-tree/
    /// </summary>
    public class BIT
    {
        // 配列の要素数 (数列の要素 + 1)
        private int n { get; }

        // データの格納先 (1-indexed)。初期値は0。
        private long[] bit { get; }

        public BIT(int n)
        {
            this.n = n;
            this.bit = new long[n + 1];
        }

        // index i に tを加算する (a_i += x)
        public void Add(int i, long x)
        {
            // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
            // indexにLSBを加算しながら更新していく。
            for (int index = i; index < n; index += (index & -index))
            {
                bit[index] += x;
            }
        }

        // 最初からi番目までの和
        public long Sum(int i)
        {
            // Console.WriteLine(Convert.ToString(i, 2).PadLeft(n, '0'));
            var sum = bit[0];
            // 0になるまで、LSBを減算しながら足していく。
            for (int index = i; index > 0; index -= (index & -index))
            {
                sum += bit[index];
            }

            return sum;
        }

        // TODO 区間加算も実装しておく？
    }
}