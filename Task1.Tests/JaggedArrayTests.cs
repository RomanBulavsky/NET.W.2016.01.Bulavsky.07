using System;
using System.Linq;
using NUnit.Framework;

namespace Task1.Tests
{
    internal class SumUp : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aSum = a.Sum();
            var bSum = b.Sum();

            if (a == b) return 0;

            return aSum > bSum ? 1 : -1;
        }
    }

    internal class SumDown : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aSum = a.Sum();
            var bSum = b.Sum();

            if (a == b) return 0;

            return aSum < bSum ? 1 : -1;
        }
    }

    internal class MaxUp : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aMax = a.Max();
            var bMax = b.Max();

            if (a == b) return 0;

            return aMax > bMax ? 1 : -1;
        }
    }

    internal class MaxDown : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aMax = a.Max();
            var bMax = b.Max();

            if (a == b) return 0;

            return aMax < bMax ? 1 : -1;
        }
    }

    internal class MinUp : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aMin = a.Min();
            var bMin = b.Min();

            if (a == b) return 0;

            return aMin < bMin ? 1 : -1;
        }
    }

    internal class MinDown : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            var aMin = a.Min();
            var bMin = b.Min();

            if (a == b) return 0;

            return aMin > bMin ? 1 : -1;
        }
    }


    public class JaggedArrayTests
    {
        //[TestCase(new int[] { 4, 5 },  new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {1, 2}, new[] {4, 5})]
        [TestCase(new[] {2, 8}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_SumUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new SumUp();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {2, 8}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_SumDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new SumDown();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {2, 8}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MaxUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MaxUp();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {2, 8}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MaxDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MaxDown();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {1, 4}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MinUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MinUp();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {1, 4}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MinDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MinDown();
            sorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }


        [TestCase(null, new[] {1, 2, 3}, new[] {1, 2}, new[] {4, 5})]
        [TestCase(new[] {1, 4, 3}, new[] {2, 8}, null)]
        public static void ChangeAndSortTest_BadParams_Exception(params int[][] jArray)
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MinDown();

            Assert.That(() => sorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }


        [TestCase(null)]
        public static void ChangeAndSortTest_NullArray_Exception(int[][] jArray)
        {
            var sorter = new JaggedArraySorter();
            var cmp = new MinDown();

            Assert.That(() => sorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(null)]
        public static void ChangeAndSortTest_CmpNull_Exception(int[][] jArray)
        {
            var sorter = new JaggedArraySorter();
            SumUp cmp = null;

            Assert.That(() => sorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }
    }
}