using System;
using System.Collections;
using System.Collections.Generic;

namespace ABCUtils.BinarySearchUtils
{
    /// <summary>
    /// C# Array.BinarySearch()に渡す
    ///
    ///    foreach (var b in bList)
    ///    {
    ///         var binarySearchA = aList.BinarySearch(b, new LowerBound<long>());
    ///         if (binarySearchA < 0) binarySearchA = ~binarySearchA;
    ///         var binarySearchC = cList.BinarySearch(b, new UpperBound<long>());
    ///         if (binarySearchC < 0) binarySearchC = ~binarySearchC;
    ///
    ///         ans += binarySearchA * (n - binarySearchC);
    ///    }
    /// 
    /// 
    /// </summary>
    public class BinarySearchUtils
    {
        /// <summary>
        /// ソート済Arrayを二部探索して、LowerBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getLowerBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class LowerBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 <= x.CompareTo(y) ? 1 : -1;
            }
        }

        /// <summary>
        /// ソート済Arrayを二部探索して、UpperBoundを探す。※注意! 同じ数字が入っている場合は、正常に動かない。
        /// BinerySearch.cs の getUpperBoundを使うのを推奨
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class UpperBound<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return 0 < x.CompareTo(y) ? 1 : -1;
            }
        }
    }
}