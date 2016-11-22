using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class ComparerAdapter : IComparer<int[]>
    {
        public Comparison<int[]> InnerComparison { private set; get; }

        public ComparerAdapter(Comparison<int[]> comparison)
        {
            InnerComparison = comparison;
        }

        public int CompareTo(int[] a, int[] b)
        {
            return InnerComparison(a, b);
        }
    }
}
