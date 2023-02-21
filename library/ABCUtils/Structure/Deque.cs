using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ABCUtils.Structure
{
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