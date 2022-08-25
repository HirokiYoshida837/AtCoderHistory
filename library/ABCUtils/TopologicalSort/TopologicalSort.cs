using System.Collections.Generic;
using System.Linq;
using ABCUtils.PriorityQueue;

namespace ABCUtils.TopologicalSort
{
    public class TopologicalSort
    {
        /// <summary>
        /// PriorityQueueを使用してトポロジカルソートを実行します。
        /// </summary>
        /// <param name="input">x : from, y: to</param>
        /// <returns></returns>
        public static (List<int> sortres, bool isAcyclic) Sort(int count, List<(int from, int to)> xyList)
        {
            // 向き先グラフ
            var dic = xyList.GroupBy(x => x.from)
                .ToDictionary(x => x.Key, x => x.Select(item => item.to).ToArray());

            for (int i = 1; i <= count; i++)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, new int[0]);
                }
            }

            return Sort(dic);
        }

        public static (List<int> sortres, bool isAcyclic) Sort(Dictionary<int, int[]> dic)
        {
            var count = dic.Count;
            // INの個数
            var counts = new int[count + 1];

            foreach (var (k, values) in dic)
            {
                foreach (var value in values)
                {
                    counts[value] += 1;
                }
            }

            // foreach (var (_, y) in xyList)
            // {
            //     counts[y] += 1;
            // }

            var pq = new PriorityQueue<int>();
            // inが無いものから順番に処理。
            for (var i = 1; i < counts.Length; i++)
            {
                if (counts[i] == 0)
                {
                    pq.Enqueue(i, i);
                }
            }

            var topologicalSortRes = new List<int>();
            while (pq.Count > 0)
            {
                var (k, v) = pq.Dequeue();
                topologicalSortRes.Add(v);

                if (dic.ContainsKey(v))
                {
                    foreach (var dest in dic[v])
                    {
                        counts[dest] -= 1;
                        if (counts[dest] <= 0)
                        {
                            pq.Enqueue(dest, dest);
                        }
                    }
                }
            }

            // topologicalソートした結果の配列の長さがおかしければDAGではない。
            return (topologicalSortRes, topologicalSortRes.Count == count);
        }
    }
}