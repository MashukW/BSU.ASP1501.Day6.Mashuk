using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactotingJaggedArraySort
{
    public delegate int CompareDelegate(int[] arry1, int[] array2);

    public class DelegateToInterfaceJaggedSort
    {
        public static void Sort(int[][] array, IComparer<int[]> compareArg)
        {
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < array.GetLength(0); j++)
                {
                    if (compareArg.Compare(array[i], array[j]) > 0)
                        Swap(ref array[i], ref array[j]);
                }
            }
        }

        public static void Sort(int[][] array, CompareDelegate delegateCompareArg)
        {
            IComparer<int[]> compareArg = delegateCompareArg.Target as IComparer<int[]>;
            if (compareArg == null)
                throw new ArgumentNullException("delegateCompareArg is not IComparer<int[]>");

            Sort(array, compareArg);
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
