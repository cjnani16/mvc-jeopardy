using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTestMVC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void HomeIndexViewTest()
        {
            //navigate to homepage, assert view
        }
       
        [TestMethod]
        public void HomeModeViewTest()
        {
            //navigate to mode page, assert view
        }

        [TestMethod]
        public void BoardViewsTest()
        {
            //navigate to board index page, run through the game
        }
    }
}
