using System;
using System.Linq;


namespace Task1
{
    public interface IComparer<T>
    {
        int CompareTo(T a, T b);
    }
    /// <summary>
    /// Class to sort a jagged array fields by the laws passed by the comparator.
    /// </summary>
    public static class JaggedArraySorter
    {
        /// <summary>
        ///     Method that choosing type of logic for sorting.
        ///  Method that provides sorting, by the law that transmitted by the class implementing the IComparable interface.
        /// </summary>
        /// <param name="jArray"> Input Jagged Array. </param>
        /// <param name="comparer"> Class implementing the IComparable interface and supplied CompareTo method that chooses the way for field sorting.</param>
        public static void SortJaggedArray(int[][] jArray, IComparer<int[]> comparer)
        {
            if (jArray == null || jArray.Any(inner => inner == null) || comparer == null)//tnx ReSharper
                throw new ArgumentException();
            for (var i = 0; i < jArray.Length - 1; i++)
            {
                for (var j = 0; j < jArray.Length - 1; j++)
                {
                    var cmp = comparer.CompareTo(jArray[j], jArray[j + 1]);

                    if (cmp < 0) SwapFields(ref jArray[j], ref jArray[j + 1]);
                }

            }
            //TODO:Delete
            /*foreach (var item in jArray)
            {
                BubbleSort(item);
            }*/

        }
        /*//TODO:Delete
        /// <summary>
        ///     Sorts the array.
        /// </summary>
        private static void BubbleSort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var swapped = false;
                for (var j = 0; j < array.Length - i - 1; j++)
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        swapped = true;
                    }

                if (!swapped)
                    break;
            }
        }
        */
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
