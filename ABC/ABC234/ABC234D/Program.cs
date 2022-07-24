using System;
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

namespace ABC234D
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToList();
            var p = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (n, k) = (nk[0], nk[1]);

            var pq = new PriorityQueue<int>();

            for (var i = 0; i < k; i++)
            {
                pq.Enqueue(p[i], 0);
            }
            
            Console.WriteLine(pq.Peek.key);

            for (var i = k; i < n; i++)
            {
                if (pq.Peek.key < p[i])
                {
                    pq.Dequeue();
                    pq.Enqueue(p[i],0);
                }

                Console.WriteLine(pq.Peek.key);
            }
        }
    }
    
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