using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Typical90_061
{
    public static class Program
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static void Main(string[] args)
        {
            var q = ReadValue<int>();

            var queries = Enumerable.Range(0, q).Select(_ => ReadValue<int, int>()).ToArray();
            var cb = new CircularBuffer<int>(q);

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false});
            foreach (var (t, x) in queries)
            {
                if (t == 1)
                {
                    cb.InsertFirst(x);
                }
                else if (t == 2)
                {
                    cb.InsertLast(x);
                }
                else
                {
                    var l = cb[x - 1];
                    Console.WriteLine(l);
                }
            }
            Console.Out.Flush();
        }

        /// <summary>
        /// refs : https://ufcpp.net/study/algorithm/col_circular.html
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

            static int Pow2(uint n)
            {
                --n;
                int p = 0;
                for (; n != 0; n >>= 1) p = (p << 1) + 1;
                return p + 1;
            }

            public T this[int i]
            {
                get => this.data[(i + this.top) & this.mask];
                set => this.data[(i + this.top) & this.mask] = value;
            }


            /// <summary>
            /// 先頭に新しい要素を追加。
            /// </summary>
            /// <param name="elem">追加する要素</param>
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
            public void EraseFirst()
            {
                this.top = (this.top + 1) & this.mask;
            }

            /// <summary>
            /// 末尾の要素を削除。
            /// </summary>
            public void EraseLast()
            {
                this.bottom = (this.bottom - 1) & this.mask;
            }

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


        public static T ReadValue<T>()
        {
            var input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T));
        }

        public static (T1, T2) ReadValue<T1, T2>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2))
            );
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>()
        {
            var input = Console.ReadLine().Split();
            return (
                (T1) Convert.ChangeType(input[0], typeof(T1)),
                (T2) Convert.ChangeType(input[1], typeof(T2)),
                (T3) Convert.ChangeType(input[2], typeof(T3))
            );
        }

        /// <summary>
        /// 指定した型として、一行読み込む。
        /// </summary>
        /// <param name="separator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
#nullable enable
        public static IEnumerable<T> ReadList<T>(params char[]? separator)
        {
            return Console.ReadLine()
                .Split(separator)
                .Select(x => (T) Convert.ChangeType(x, typeof(T)));
        }
#nullable disable
    }

    public class Deque<T> : IReadOnlyCollection<T>
    {
        public int Count { get; private set; }
        private T[] _data;
        private int _first;
        private int _mask;

        public Deque() : this(4)
        {
        }

        public Deque(int minCapacity)
        {
            if (minCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minCapacity), $"{nameof(minCapacity)}は0より大きい値でなければなりません。");
            }

            var capacity = GetPow2Over(minCapacity);
            _data = new T[capacity];
            _first = 0;
            _mask = capacity - 1;
        }

        public Deque(IEnumerable<T> collection)
        {
            var dataArray = collection.ToArray();
            var capacity = GetPow2Over(dataArray.Length);
            _data = new T[capacity];
            _first = 0;
            _mask = capacity - 1;

            for (int i = 0; i < dataArray.Length; i++)
            {
                _data[i] = dataArray[i];
                Count++;
            }
        }

        public T this[Index index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var offset = index.GetOffset(Count);
                if (unchecked((uint) offset) >= Count)
                {
                    ThrowArgumentOutOfRangeException(nameof(index), $"{nameof(index)}がコレクションの範囲外です。");
                }

                return _data[(_first + offset) & _mask];
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                var offset = index.GetOffset(Count);
                if (unchecked((uint) offset) >= Count)
                {
                    ThrowArgumentOutOfRangeException(nameof(index), $"{nameof(index)}がコレクションの範囲外です。");
                }

                _data[(_first + offset) & _mask] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnqueueFirst(T item)
        {
            if (_data.Length == Count)
            {
                Resize();
            }

            _first = (_first - 1) & _mask;
            _data[_first] = item;
            Count++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnqueueLast(T item)
        {
            if (_data.Length == Count)
            {
                Resize();
            }

            _data[(_first + Count++) & _mask] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DequeueFirst()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            var value = _data[_first];
            _data[_first++] = default;
            _first &= _mask;
            Count--;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DequeueLast()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            var index = (_first + --Count) & _mask;
            var value = _data[index];
            _data[index] = default;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T PeekFirst()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            return _data[_first];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T PeekLast()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            return _data[(_first + Count - 1) & _mask];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Resize()
        {
            var newArray = new T[_data.Length << 1];
            var span = _data.AsSpan();
            var firstHalf = span[_first..];
            var lastHalf = span[.._first];
            firstHalf.CopyTo(newArray);
            lastHalf.CopyTo(newArray.AsSpan(firstHalf.Length));
            _data = newArray;
            _first = 0;
            _mask = _data.Length - 1;
        }

        private void ThrowArgumentOutOfRangeException(string paramName, string message) =>
            throw new ArgumentOutOfRangeException(paramName, message);

        private void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);

        private int GetPow2Over(int n)
        {
            n--;
            var result = 1;
            while (n != 0)
            {
                n >>= 1;
                result <<= 1;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var offset = (_first + i) & _mask;
                yield return _data[offset];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}