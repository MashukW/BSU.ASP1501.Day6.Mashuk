using System;
using NUnit.Framework;
using RefactotingJaggedArraySort;
using System.Collections.Generic;

namespace RefactotingJaggedArraySort.Test
{
    [TestFixture]
    public class InterfaceToDelegateJaggedSortTest
    {
        public IEnumerable<TestCaseData> TestDataInterfaceToDelegateSortBySum
        {
            get
            {
                yield return new TestCaseData(new[]{    new[] {21, 10, 26},null,new[] {1, 3, 2, 5, 8},
                                                        new[] {1, 3, 0, 7, 2, 4, 9},null,null,
                                                        new[] {10, 9, 8, 7, 6},new[] {2, 4, 6, 8}   },
                        
                        new ComparisonBySum());
            }
        }

        public IEnumerable<TestCaseData> TestDataInterfaceToDelegateSortByMaxModulElement
        {
            get
            {
                yield return new TestCaseData(new[]{    new[] {21, 10, 26},null,new[] {1, 3, 2, 5, 8},
                                                        new[] {1, 3, 0, 7, 2, 4, 9},null,null,
                                                        new[] {10, 9, 8, 7, 6},new[] {2, 4, 6, 8}},


                        new ComparisonByMaxModulElement());
            }
        }

        [Test, TestCaseSource("TestDataInterfaceToDelegateSortBySum")]
        public void Sort_InterfaceToDelegate_CompareBySum(int[][] array, IComparer<int[]> comparer)
        {
            int[][] resultArraySort = new[] {    new[] { 1, 3, 2, 5, 8 }, new[] { 2, 4, 6, 8 }, new[] { 1, 3, 0, 7, 2, 4, 9 }, 
                                            new[] {10, 9, 8, 7, 6}, new[] {21, 10, 26}, null,
                                            null, null  };



            InterfaceToDelegateJaggedSort.Sort(array, comparer);

            CollectionAssert.AreEqual(array, resultArraySort);
        }

        [Test, TestCaseSource("TestDataInterfaceToDelegateSortByMaxModulElement")]
        public void Sort_InterfaceToDelegate_CompareByMaxModulElement(int[][] array, IComparer<int[]> comparer)
        {
            int[][] resultArraySort = new[] {   new[] {1, 3, 2, 5, 8}, new[] {2, 4, 6, 8}, new[] {1, 3, 0, 7, 2, 4, 9}, 
                                                new[] {10, 9, 8, 7, 6}, new[] {21, 10, 26}, null,
                                                null, null  };

            InterfaceToDelegateJaggedSort.Sort(array, comparer);

            CollectionAssert.AreEqual(array, resultArraySort);
        }
    }
}
