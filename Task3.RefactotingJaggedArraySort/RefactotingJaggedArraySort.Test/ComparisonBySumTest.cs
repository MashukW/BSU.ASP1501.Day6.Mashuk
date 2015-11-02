using System;
using NUnit.Framework;
using RefactotingJaggedArraySort;
using System.Collections.Generic;

namespace RefactotingJaggedArraySort.Test
{
    [TestFixture]
    public class ComparisonBySumTest
    {
        public IEnumerable<TestCaseData> testDataForCompareBySumElement
        {
            get
            {
                yield return new TestCaseData(null, null).Returns(0);
                yield return new TestCaseData(null, new int[] { 1, 2, 3 }).Returns(1);
                yield return new TestCaseData(new int[] { 1, 2, 3 }, null).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, }).Returns(1);

                ComparisonBySum compare = new ComparisonBySum();
            }
        }

        [Test, TestCaseSource("testDataForCompareByMaxModulElement")]
        public int CompareTest_BySumElementElement(int[] array1, int[] array2, ComparisonBySum compare)
        {
            return compare.Compare(array1, array2);
        }
    }
}
