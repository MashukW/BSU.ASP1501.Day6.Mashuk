using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactotingJaggedArraySort
{
    public class InterfaceToDelegateJaggedSort
    {
        public static void Sort(int[][] array, IComparer<int[]> compareArg)
        {
            IComparer<int[]> arg = compareArg as IComparer<int[]>;
            if (arg == null)
                throw new ArgumentNullException("Parametr 'compareArg' is null");

            CompareDelegate compare = arg.Compare;
            Sort(array, compare);
        }

        public static void Sort(int[][] array, CompareDelegate delegateCompareArg)
        {
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < array.GetLength(0); j++)
                {
                    if (delegateCompareArg(array[i], array[j]) > 0)
                        Swap(ref array[i], ref array[j]);
                }
            }
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
