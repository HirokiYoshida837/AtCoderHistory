using System.Collections.Generic;
using System.Linq;

namespace ABCUtils.UnionFindTree
{
    public class UnionFind
    {
        public int Size { get; private set; }
        public int GroupCount { get; private set; }

        private int[] Parent;
        private int[] Sizes;

        public UnionFind(int count)
        {
            this.Size = count;
            this.GroupCount = count;

            Parent = new int[count];
            Sizes = new int[count];

            for (int i = 0; i < count; i++)
            {
                Parent[i] = i;
                Sizes[i] = 1;
            }
        }

        public bool TryUnite(int x, int y)
        {
            var xp = FindRoot(x);
            var yp = FindRoot(y);
            if (xp == yp)
            {
                return false;
            }

            if (Sizes[xp] < Sizes[yp])
            {
                var tmp = xp;
                xp = yp;
                yp = tmp;
            }

            GroupCount--;

            Parent[yp] = xp;
            Sizes[xp] += Sizes[yp];
            return true;
        }

        public int FindRoot(int x)
        {
            while (x != Parent[x])
            {
                x = (Parent[x] = Parent[Parent[x]]);
            }

            return x;
        }

        public IEnumerable<int> AllRepresents()
        {
            return Parent.Where((x, y) => x == y);
        }
    }
}