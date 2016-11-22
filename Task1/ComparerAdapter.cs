using System;

namespace Task1
{
    internal sealed class ComparerAdapter : IComparer<int[]>
    {
        private Comparison<int[]> InnerComparison { get; }

        public ComparerAdapter(Comparison<int[]> comparison)
        {
            InnerComparison = comparison;
        }

        public int Compare(int[] a, int[] b)
            => InnerComparison(a, b);
    }
}