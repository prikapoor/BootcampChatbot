using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesRepLib;
using System.Collections.Generic;
using Moq;
using ChatbotDataModelLib.Models;
using SalesRepContractLib;

namespace SalesRepLib.Test
{
    [TestClass]
    public class SalesRepUnitTest
    {
                
        private readonly ChatbotDataModelLib.Models.SalesRep salesrep;

        public SalesRepUnitTest()
        {
            salesrep = new ChatbotDataModelLib.Models.SalesRep { ExecutiveName = "Prithu", City = "Delhi" };

            Moq.Mock<ISalesRep> mocksalesrep = new Mock<ISalesRep>();
            mocksalesrep.Setup(ms => ms.PostNewSalesRep(It.IsAny<ChatbotDataModelLib.Models.SalesRep>())).Returns((ChatbotDataModelLib.Models.SalesRep salesRep) =>
            {

                return true;
            });


            this.MockSalesRepDataRepository = mocksalesrep.Object;


        }
        public readonly ISalesRep MockSalesRepDataRepository;

        [TestMethod]
        public void Given_Valid_User_Argument_Valid_Data_Is_Added_Into_The_Database()
        {
            var obj = MockSalesRepDataRepository.PostNewSalesRep(salesrep);
            Assert.IsTrue(obj);
        }
    }
}
