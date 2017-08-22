using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04.TestNumberInArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = { 0, 1, 2, 3, 4 };
            int num = 1;
            int res = Count.NumberInArray.Equal(arr, num);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = { 0, 1, 2, 3, 4 };
            int num = 15;
            int res = Count.NumberInArray.Equal(arr, num);
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int[] arr = { 1, 1, 1, 1, 1 };
            int num = 1;
            int res = Count.NumberInArray.Equal(arr, num);
            Assert.AreEqual(5, res);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int[] arr = new int[4];
            int num = 0;
            int res = Count.NumberInArray.Equal(arr, num);
            Assert.AreEqual(4, res);
        }
    }
}
