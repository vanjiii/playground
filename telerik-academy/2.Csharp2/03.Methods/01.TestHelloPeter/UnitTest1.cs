using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramHello;

namespace _01.TestHelloPeter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testName = "Peter";
            string result = HelloPeter.PrintName(testName);
            Assert.AreEqual("Hello, Peter", result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string testName = "";
            string result = HelloPeter.PrintName(testName);
            Assert.AreEqual("Hello, ", result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string testName = null;
            string result = HelloPeter.PrintName(testName);
            Assert.AreEqual("Hello, ", result);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string testName = "@dfghGHJ^&*B&gvg*&Tgv77968";
            string result = HelloPeter.PrintName(testName);
            Assert.AreEqual("Hello, @dfghGHJ^&*B&gvg*&Tgv77968", result);
        }
    }
}
