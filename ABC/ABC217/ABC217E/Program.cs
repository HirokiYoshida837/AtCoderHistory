﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

namespace ABC217E
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var q = ReadValue<int>();
            (int queryType, int x)[] queries = Enumerable.Range(0, q)
                .Select(_ =>
                {
                    var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    if (s[0] == 1)
                    {
                        return (1, s[1]);
                    }
                    else if (s[0] == 2)
                    {
                        return (2, -1);
                    }
                    else
                    {
                        return (3, -1);
                    }
                })
                .ToArray();

            // 1 x : A の最後尾に x を追加する。
            // 2 : A の最初の要素を出力する。その後、その要素を削除する。このクエリが与えられるとき、A は空でないことが保証される。
            // 3 : A を昇順にソートする。

            var queue = new Queue<long>();
            var pQueue = new PriorityQueue<long>();

            // var currentMode = "queue";

            foreach (var (t, x) in queries)
            {
                if (t == 1)
                {
                    queue.Enqueue(x);
                }
                else if (t == 2)
                {
                    if (pQueue.Count != 0)
                    {
                        var (v,_) = pQueue.Dequeue();
                        Console.WriteLine(v);
                    }
                    else
                    {
                        var v = queue.Dequeue();
                        Console.WriteLine(v);
                    }
                    
                    continue;
                }
                else // t==3
                {
                    while (queue.Count > 0)
                    {
                        var dequeue = queue.Dequeue();
                        pQueue.Enqueue(dequeue, dequeue);
                    }
                }
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

    /// <summary>
    /// PriorityQueueは .Net6で使えるが、AtCoder環境ではつかえないので、、、
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T>
    {
        /// <summary>
        /// 空の優先度付きキューを生成します。
        /// </summary>
        public PriorityQueue()
        {
            _keys = new List<long>();
            _elements = new List<T>();
        }

        List<long> _keys;
        List<T> _elements;

        /// <summary>
        /// 優先度付きキューに要素を追加します。
        /// 計算量は O(log(要素数)) です。
        /// </summary>
        public void Enqueue(long key, T elem)
        {
            var n = _elements.Count;
            _keys.Add(key);
            _elements.Add(elem);
            while (n != 0)
            {
                var i = (n - 1) / 2;
                if (_keys[n] < _keys[i])
                {
                    (_keys[n], _keys[i]) = (_keys[i], _keys[n]);
                    (_elements[n], _elements[i]) = (_elements[i], _elements[n]);
                }

                n = i;
            }
        }

        /// <summary>
        /// 頂点要素を返し、削除します。
        /// 計算量は O(log(要素数)) です。
        /// </summary>
        public (long, T) Dequeue()
        {
            var t = Peek;
            Pop();
            return t;
        }

        void Pop()
        {
            var n = _elements.Count - 1;
            _elements[0] = _elements[n];
            _elements.RemoveAt(n);
            _keys[0] = _keys[n];
            _keys.RemoveAt(n);
            for (int i = 0, j; (j = 2 * i + 1) < n;)
            {
                //左の子と右の子で右の子の方が優先度が高いなら右の子を処理したい
                if ((j != n - 1) && _keys[j] > _keys[j + 1]) j++;
                //親より子が優先度が高いなら親子を入れ替える
                if (_keys[i] > _keys[j])
                {
                    (_keys[i], _keys[j]) = (_keys[j], _keys[i]);
                    (_elements[i], _elements[j]) = (_elements[j], _elements[i]);
                }

                i = j;
            }
        }


        /// <summary>
        /// 頂点要素を返します。
        /// 計算量は O(1) です。
        /// </summary>
        public (long key, T value) Peek => (_keys[0], _elements[0]);

        /// <summary>
        /// 優先度付きキューに格納されている要素の数を返します。
        /// 計算量は O(1) です。
        /// </summary>
        public int Count => _elements.Count;
    }
}