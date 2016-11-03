using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /*void Main()
    {
        IJagged cmp = new Min();
        JaggedClass jA = new JaggedClass();
        int[][] jArr = new int[3][];
        jArr[0] = new int[3] { 1, -2, 3 };
        jArr[1] = new int[2] { 2, 22 };
        jArr[2] = new int[2] { 1, 15 };
        jA.jASort(jArr, cmp);
        jArr.Dump();
    }*/
    interface IJagged
    {
        int CompareTo(int[] a, int[] b);
    }
    class JaggedClass
    {
        public void jASort(int[][] jArray, IJagged comparer)
        {
            for (int i = 0; i < jArray.Length - 1; i++)
            {
                for (int j = 0; j < jArray.Length - 1; j++)
                {
                    int cmp = comparer.CompareTo(jArray[j], jArray[j + 1]);

                    if (cmp < 0) Swap(ref jArray[j], ref jArray[j + 1]);
                }

            }

            //return new int[3][];
        }

        public void Swap(ref int[] arr1, ref int[] arr2)
        {
            var tmp = arr1;
            arr1 = arr2;
            arr2 = tmp;
        }

    }
    class bigestSum : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            int aSum, bSum;
            aSum = a.Sum();
            bSum = b.Sum();

            if (a == b) return 0;

            return aSum > bSum ? 1 : -1;
        }

    }
    class Max : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            int aSum, bSum;
            aSum = a.Max();
            bSum = b.Max();

            if (a == b) return 0;

            return aSum > bSum ? 1 : -1;
        }

    }
    class Min : IJagged
    {
        public int CompareTo(int[] a, int[] b)
        {
            int aSum, bSum;
            aSum = a.Min();
            bSum = b.Min();

            if (a == b) return 0;

            return aSum < bSum ? 1 : -1;
        }

    }
    // Define other methods and classes here

}
