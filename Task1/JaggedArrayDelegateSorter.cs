using System;
using System.Linq;


namespace Task1
{
    //TODO: Cng xml
    /// <summary>
    /// Class to sort a jagged array fields by the laws passed by the comparator.
    /// </summary>
    public static class JaggedArrayDelegateSorter
    {
        /// <summary>
        ///     Method that choosing type of logic for sorting.
        ///  Method that provides sorting, by the law that transmitted by the class implementing the IComparable interface.
        /// </summary>
        /// <param name="jArray"> Input Jagged Array. </param>
        /// <param name="comparer"> Class implementing the IComparer<int[]> interface and supplied CompareTo method that chooses the way for field sorting.</param>
        public static void SortJaggedArray(int[][] jArray, Comparison<int[]> comparer)
        {
            if (jArray == null || jArray.Any(inner => inner == null) || comparer == null) //tnx ReSharper
                throw new ArgumentException();
            for (var i = 0; i < jArray.Length - 1; i++)
            {
                for (var j = 0; j < jArray.Length - 1; j++)
                {
                    var cmp = comparer(jArray[j], jArray[j + 1]);

                    if (cmp < 0) SwapFields(ref jArray[j], ref jArray[j + 1]);
                }
            }
        }

        public static void SortJaggedArray(int[][] jArray, IComparer<int[]> comparer)
        {
            if (jArray == null || jArray.Any(inner => inner == null) || comparer == null) //tnx ReSharper
                throw new ArgumentException();
            SortJaggedArray(jArray, comparer.CompareTo);
        } 

        /// <summary>
        ///     A method that swaps two fields of the jagged array.
        /// </summary>
        private static void SwapFields(ref int[] firstArray, ref int[] secondArray)
        {
            var tmp = firstArray;
            firstArray = secondArray;
            secondArray = tmp;
        }
    }
}