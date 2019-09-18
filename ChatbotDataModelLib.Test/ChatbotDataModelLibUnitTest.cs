using System;
using ChatbotDataModelLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatbotDataModelLib.Test
{
    [TestClass]
    public class ChatbotDataModelLibUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            new PhilipsDBEntities();
            Assert.IsTrue(true);
        }
    }
}
