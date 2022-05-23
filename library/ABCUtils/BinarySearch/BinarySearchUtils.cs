using System;
using System.Collections;
using System.Collections.Generic;

namespace ABCUtils.BinarySearchUtils
{
    /// <summary>
    /// C# Array.BinarySearch()に渡す
    /// </summary>
    public class BinarySearchUtils
    {
        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 <= x.CompareTo(y) ? 1 : -1;
            }
        }

        public class UpperBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 < x.CompareTo(y) ? 1 : -1;
            }
        }
    }
}