using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBA_1.TasksClases;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class VampireNumber_UnitTest
    {
        [TestMethod]
        public void GetNumberParts_Test()
        {
            int[] actual = VampireNumber.GetNumberParts(654321);
            int[] expected = new[] { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetNumberTwoVariants_Test()
        {
            int[] i = VampireNumber.GetNumberParts(4321);

            List<int> actual = VampireNumber.GetNumberTwoVariants(i);
            List<int> expected = new List<int>() { 12, 13, 14, 21, 23, 24, 31, 32, 34, 41, 42, 43 };

            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsRealMakeVimpireNumber_Test()
        {
            int num = 1827;
            Boolean expected = true;

            int[] i = VampireNumber.GetNumberParts(num);
            List<int> ii = VampireNumber.GetNumberTwoVariants(i);

            Boolean actual = VampireNumber.IsRealMakeVimpireNumber(ii, num);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetExistVampireNumber_Test()
        {
            List<int> actual = VampireNumber.GetExistVampireNumber(4);

            List<int> expected = new List<int>() { };

            CollectionAssert.AreEqual(expected, actual);

        }

    }
}
