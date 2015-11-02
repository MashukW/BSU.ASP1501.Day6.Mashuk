using System;
using NUnit.Framework;
using RefactotingJaggedArraySort;
using System.Collections.Generic;

namespace RefactotingJaggedArraySort.Test
{
    [TestFixture]
    public class ComparisonByMaxModulElementTest
    {
        public IEnumerable<TestCaseData> testDataForCompareByMaxModulElement
        {
            get
            {
                yield return new TestCaseData(null, null).Returns(0);
                yield return new TestCaseData(null, new int[] {1, 2, 3}).Returns(1);
                yield return new TestCaseData(new int[] { 1, 2, 3 }, null).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3, }, new int[] { 1, 2, 3, 4 }).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, }).Returns(1);
                yield return new TestCaseData(new int[] { -1, -2, -3, -4 }, new int[] { 1, 2, 3, }).Returns(1);

                ComparisonByMaxModulElement compare = new ComparisonByMaxModulElement();
            }
        }

        [Test, TestCaseSource("testDataForCompareByMaxModulElement")]
        public int CompareTest_ByMaxModulElement(int[] array1, int[] array2, ComparisonByMaxModulElement compare)
        {
            return compare.Compare(array1, array2);
        }
    }
}
