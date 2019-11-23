using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBA_1.TasksClases;
using System.Collections.Generic;
using System.Text;

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

    [TestClass]
    public class TextLetters_UnitTest
    { 

        [TestMethod]
        public void getCountVowelsText_Test()
        {
            float expected = (4 *100)/11;

            StringBuilder sb = new StringBuilder();
            sb.Append("uiggddbifsa");

            float actual = TextLetters.getCountVowels(sb);

            Assert.AreEqual(expected, actual);

        }
    }

}