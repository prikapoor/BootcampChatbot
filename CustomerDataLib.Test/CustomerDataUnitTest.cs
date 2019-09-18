using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerDataLib;
using System.Collections.Generic;
using Moq;
using ChatbotDataModelLib.Models;
using CustomerDataContractLib;

namespace CustomerDataLib.Test
{
    [TestClass]
    public class CustomerDataUnitTest
    {
        readonly List<PatientSale> patientList = new List<PatientSale>();

        readonly List<ChatbotDataModelLib.Models.CustomerData> customerDatas = new List<ChatbotDataModelLib.Models.CustomerData>();
        private readonly ChatbotDataModelLib.Models.CustomerData _customerData;
        private readonly PatientSale patient1;
        public CustomerDataUnitTest()
        {
            patient1 = new PatientSale { CustomerId = 1, CustomerName = "Bishesh", ExecutiveName = "Prithu", City = "Delhi", Model = "MX500" };
            _customerData = new ChatbotDataModelLib.Models.CustomerData { CustomerId = 1, CustomerName = "Bishesh", CustomerAddress = "Delhi", CustomerPhone = 9608292894, Product = "Intellivue", Model = "MX800" };
            string ExeName = patient1.ExecutiveName;

            patientList.Add(patient1);
            customerDatas.Add(_customerData);

            Moq.Mock<ICustomerData> mockCustomerData = new Moq.Mock<ICustomerData>();
            mockCustomerData.Setup(mcd => mcd.CreatePatientRecord(It.IsAny<ChatbotDataModelLib.Models.CustomerData>())).Returns(patient1);
            mockCustomerData.Setup(mcd => mcd.CheckSales(It.IsAny<ChatbotDataModelLib.Models.CustomerData>())).Returns(ExeName);
            mockCustomerData.Setup(mcd => mcd.PostNewMonitor(It.IsAny<ChatbotDataModelLib.Models.CustomerData>())).Returns((ChatbotDataModelLib.Models.CustomerData data) =>
            {
                customerDatas.Add(data);
                return true;
            });

            this.MockCustomerDataRepository = mockCustomerData.Object;


        }
        public readonly ICustomerData MockCustomerDataRepository;

        [TestMethod]
        public void Valid_Patient_Record_Is_Created()
        {

            var obj = MockCustomerDataRepository.CreatePatientRecord(_customerData);
            Assert.AreEqual(obj, patient1);
        }

        [TestMethod]
        public void Valid_Executive_Name_Is_Returned()
        {

            var obj = MockCustomerDataRepository.CheckSales(_customerData);
            Assert.AreEqual("Prithu", obj);

        }

        [TestMethod]
        public void Given_Valid_Input_Valid_CustomerData_Is_Added_Into_Table()
        {
            var obj = MockCustomerDataRepository.PostNewMonitor(_customerData);
            Assert.IsTrue(obj);
        }

    }
}
