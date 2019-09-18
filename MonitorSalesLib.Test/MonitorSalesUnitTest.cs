using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonitorSalesLib;
using System.Collections.Generic;
using Moq;
using ChatbotDataModelLib.Models;
using MonitorSalesContractLib;

namespace MonitorSalesLib.Test
{
    [TestClass]
    public class MonitorSalesUnitTest
    {
        private readonly ChatbotDataModelLib.Models.PatientSale patientSale;
        private readonly List<PatientSale> patientSales = new List<PatientSale>();
        public MonitorSalesUnitTest()
        {
            patientSale = new ChatbotDataModelLib.Models.PatientSale
            {
                CustomerId = 1,
                CustomerName = "Bishesh",
                ExecutiveName = "Prithu",
                City = "Delhi",
                Model = "MX500"
            };

            ChatbotDataModelLib.Models.PatientSale patientSale1 = new ChatbotDataModelLib.Models.PatientSale
            {
                CustomerId = 2,
                CustomerName = "Raghavendra",
                ExecutiveName = "Prithu",
                City = "Delhi",
                Model = "MX400"
            };


            patientSales.Add(patientSale);
            patientSales.Add(patientSale1);


            Mock<MonitorSalesContractLib.IMonitorSales> mock = new Moq.Mock<MonitorSalesContractLib.IMonitorSales>();
            mock.Setup(mr => mr.GetExecutiveName(It.IsAny<string>())).Returns(patientSales);
            this.MockMonitorSalesRepository = mock.Object;
        }

        public readonly IMonitorSales MockMonitorSalesRepository;
        [TestMethod]
        public void When_Valid_Argument_Given_Valid_MonitorSales_List_Is_Returned()
        {
            int expectedValue = MockMonitorSalesRepository.GetExecutiveName("Prithu").Count;
            int actualValue = 2;
            Assert.AreEqual(actualValue, expectedValue);
        }
    }
}
