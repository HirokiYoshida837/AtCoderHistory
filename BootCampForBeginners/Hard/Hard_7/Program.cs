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

namespace Hard_7
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var (n, m) = ReadValue<int, int>();
            var aList = ReadList<long>().ToArray();
            (int b, int c)[] bcList = Enumerable.Range(0, m)
                .Select(_ => ReadValue<int, int>())
                .ToArray();

            // pqの内容も圧縮。(key値と個数で持っておく)
            var pq = new PriorityQueue<int>();
            foreach (var grouping in aList.GroupBy(x => x))
            {
                pq.Enqueue(grouping.Key, grouping.Count());
            }


            // BCの処理を圧縮。
            var pressedBC = new List<(int b, int c)>();
            pressedBC.Add(bcList[0]);
            for (var i = 1; i < bcList.Length; i++)
            {
                if (pressedBC.Last().c == bcList[i].c)
                {
                    var l = pressedBC.Last();
                    pressedBC.RemoveAt(pressedBC.Count - 1);
                    var addItem = l;
                    addItem.b += bcList[i].b;
                    pressedBC.Add(addItem);
                }
                else
                {
                    pressedBC.Add(bcList[i]);
                }
            }


            foreach (var item in pressedBC)
            {
                var b = item.b;
                var c = item.c;

                // 一度cに書き換えたら対象にならないはず。全部cで書き換えられるので、追加予定のリストを持っておいて、後で一気にenqueすれば早い。
                var enqueList = 0;

                while (b > 0 && pq.Count > 0)
                {
                    var (p, count) = pq.Peek;

                    if (p >= c)
                    {
                        break;
                    }

                    // 全部引き出せる場合
                    if (count <= b)
                    {
                        pq.Dequeue();
                        b -= count;

                        // あとでまとめてenqueする。
                        // pq.Enqueue(c, count);
                        enqueList += count;
                    }
                    else
                    {
                        // 途中までしか引き出せない場合
                        // pq.Dequeue();

                        // 変換しきれなかった分は先頭に残る。dequeして入れ直すと時間がかかるので、直接個数を書き換え。
                        // pq.Enqueue(p, count - b);
                        pq._elements[0] = count - b;

                        // 変換後の値はあとでまとめて一気にenque。
                        // 変換後
                        // pq.Enqueue(c, b);
                        enqueList += b;

                        b = 0;
                    }
                }

                pq.Enqueue(c, enqueList);
            }

            // pqから一つずつ引き出すと時間がかかるので、直接配列にアクセス。
            var sum = 0L;
            for (var i = 0; i < pq._elements.Count; i++)
            {
                var v = pq._elements[i] * pq._keys[i];
                sum += v;
            }

            Console.WriteLine(sum);
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

        public List<long> _keys;
        public List<T> _elements;

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