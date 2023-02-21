using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ABCUtils.Structure
{
    /// <summary>
    /// refs : https://ufcpp.net/study/algorithm/col_circular.html
    ///
    /// 実装してみたが遅い？
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularBuffer<T> : IEnumerable<T>
    {
        private T[] data;
        private int bottom;
        private int top;
        private int mask;

        public CircularBuffer() : this(256)
        {
        }

        public CircularBuffer(int capacity)
        {
            // 高速にmodとりたいので 2のべき乗で。
            capacity = Pow2((uint) capacity);
            this.data = new T[capacity];
            this.top = this.bottom = 0;
            this.mask = capacity - 1;
        }

        /// <summary>
        /// 格納されている要素数。
        /// </summary>
        public int Count
        {
            get
            {
                int count = this.bottom - this.top;
                if (count < 0) count += this.data.Length;
                return count;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int Pow2(uint n)
        {
            --n;
            int p = 0;
            for (; n != 0; n >>= 1) p = (p << 1) + 1;
            return p + 1;
        }


        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => this.data[(i + this.top) & this.mask];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => this.data[(i + this.top) & this.mask] = value;
        }


        /// <summary>
        /// 先頭に新しい要素を追加。
        /// </summary>
        /// <param name="elem">追加する要素</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InsertFirst(T elem)
        {
            if (this.Count >= this.data.Length - 1)
                this.Extend();

            this.top = (this.top - 1) & this.mask;
            this.data[this.top] = elem;
        }

        /// <summary>
        /// 末尾に新しい要素を追加。
        /// </summary>
        /// <param name="elem">追加する要素</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InsertLast(T elem)
        {
            if (this.Count >= this.data.Length - 1)
                this.Extend();

            this.data[this.bottom] = elem;
            this.bottom = (this.bottom + 1) & this.mask;
        }

        /// <summary>
        /// 先頭の要素を削除。
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EraseFirst()
        {
            this.top = (this.top + 1) & this.mask;
        }

        /// <summary>
        /// 末尾の要素を削除。
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EraseLast()
        {
            this.bottom = (this.bottom - 1) & this.mask;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerator<T> GetEnumerator()
        {
            if (this.top <= this.bottom)
            {
                for (int i = this.top; i < this.bottom; ++i)
                    yield return this.data[i];
            }
            else
            {
                for (int i = this.top; i < this.data.Length; ++i)
                    yield return this.data[i];
                for (int i = 0; i < this.bottom; ++i)
                    yield return this.data[i];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// 配列を確保しなおす。
        /// </summary>
        /// <remarks>
        /// 配列長は2倍ずつ拡張していきます。
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Extend()
        {
            T[] data = new T[this.data.Length * 2];
            int i = 0;
            foreach (T elem in this)
            {
                data[i] = elem;
                ++i;
            }

            this.top = 0;
            this.bottom = this.Count;
            this.data = data;
            this.mask = data.Length - 1;
        }
    }
}