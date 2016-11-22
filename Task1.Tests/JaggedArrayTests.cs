using System;
using System.Linq;
using NUnit.Framework;
using Task1;

namespace Task1.Tests
{
    internal class SumUp : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aSum = a.Sum();
            var bSum = b.Sum();

            if (a == b) return 0;

            return aSum > bSum ? 1 : -1;
        }
    }

    internal class SumDown : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aSum = a.Sum();
            var bSum = b.Sum();

            if (a == b) return 0;

            return aSum < bSum ? 1 : -1;
        }
    }

    internal class MaxUp : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aMax = a.Max();
            var bMax = b.Max();

            if (a == b) return 0;

            return aMax > bMax ? 1 : -1;
        }
    }

    internal class MaxDown : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aMax = a.Max();
            var bMax = b.Max();

            if (a == b) return 0;

            return aMax < bMax ? 1 : -1;
        }
    }

    internal class MinUp : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aMin = a.Min();
            var bMin = b.Min();

            if (a == b) return 0;

            return aMin < bMin ? 1 : -1;
        }
    }

    internal class MinDown : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            var aMin = a.Min();
            var bMin = b.Min();

            if (a == b) return 0;

            return aMin > bMin ? 1 : -1;
        }
    }


    public class JaggedArrayDelegateTests
    {
        //[TestCase(new int[] { 4, 5 },  new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {1, 2}, new[] {4, 5})]
        [TestCase(new[] {8, 2}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_SumUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            
            var cmp = new SumUp();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {8, 2}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_SumDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new SumDown();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {8, 2}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MaxUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
           
            var cmp = new MaxUp();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {4, 5}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {8, 2}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MaxDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MaxDown();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {4, 1}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MinUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MinUp();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] {2, 1}, new[] {1, 2, 3}, new[] {2, 1}, new[] {4, 5})]
        [TestCase(new[] {4, 1}, new[] {1, 4, 3}, new[] {8, 2}, new[] {4, 1})]
        public static void SortJaggedArray_MinDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MinDown();
            JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }


        [TestCase(null, new[] {1, 2, 3}, new[] {1, 2}, new[] {4, 5})]
        [TestCase(new[] {1, 4, 3}, new[] {2, 8}, null)]
        public static void ChangeAndSortTest_BadParams_Exception(params int[][] jArray)
        {
            var cmp = new MinDown();
            Assert.That(() => JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }


        [TestCase(null)]
        public static void ChangeAndSortTest_NullArray_Exception(int[][] jArray)
        {
            var cmp = new MinDown();
            Assert.That(() => JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(null)]
        public static void ChangeAndSortTest_CmpNull_Exception(int[][] jArray)
        {
            SumUp cmp = null;

            Assert.That(() => JaggedArrayDelegateSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }
    }

    public class JaggedArrayInterfaceTests
    {
        //[TestCase(new int[] { 4, 5 },  new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 1, 2 }, new[] { 4, 5 })]
        [TestCase(new[] { 8, 2 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_SumUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {

            var cmp = new SumUp();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 2, 1 }, new[] { 4, 5 })]
        [TestCase(new[] { 8, 2 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_SumDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new SumDown();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 2, 1 }, new[] { 4, 5 })]
        [TestCase(new[] { 8, 2 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_MaxUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {

            var cmp = new MaxUp();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] { 4, 5 }, new[] { 1, 2, 3 }, new[] { 2, 1 }, new[] { 4, 5 })]
        [TestCase(new[] { 8, 2 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_MaxDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MaxDown();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 2, 1 }, new[] { 4, 5 })]
        [TestCase(new[] { 4, 1 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_MinUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MinUp();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[0], result);
        }

        [TestCase(new[] { 2, 1 }, new[] { 1, 2, 3 }, new[] { 2, 1 }, new[] { 4, 5 })]
        [TestCase(new[] { 4, 1 }, new[] { 1, 4, 3 }, new[] { 8, 2 }, new[] { 4, 1 })]
        public static void SortJaggedArray_MinDown_RightArrayInTheLastIndexOfJaggedArray(int[] result,
            params int[][] jArray) //Extended method
        {
            var cmp = new MinDown();
            JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp);

            Assert.AreEqual(jArray[2], result);
        }


        [TestCase(null, new[] { 1, 2, 3 }, new[] { 1, 2 }, new[] { 4, 5 })]
        [TestCase(new[] { 1, 4, 3 }, new[] { 2, 8 }, null)]
        public static void ChangeAndSortTest_BadParams_Exception(params int[][] jArray)
        {
            var cmp = new MinDown();
            Assert.That(() => JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }


        [TestCase(null)]
        public static void ChangeAndSortTest_NullArray_Exception(int[][] jArray)
        {
            var cmp = new MinDown();
            Assert.That(() => JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(null)]
        public static void ChangeAndSortTest_CmpNull_Exception(int[][] jArray)
        {
            SumUp cmp = null;

            Assert.That(() => JaggedArrayInterfaceSorter.SortJaggedArray(jArray, cmp), Throws.TypeOf<ArgumentException>());
        }
    }
}