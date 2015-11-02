using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactotingJaggedArraySort
{
    public class ComparisonByMaxModulElement : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            if (MaxModulElement(x) > MaxModulElement(y))
                return 1;
            return -1;
        }

        private int MaxModulElement(int[] array)
        {
            int maxElement = Math.Abs(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                if (maxElement < Math.Abs(array[i]))
                    maxElement = Math.Abs(array[i]);
            }

            return maxElement;
        }
    }
}
