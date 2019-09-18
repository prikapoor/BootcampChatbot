using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CategoryLib;
using System.Collections.Generic;
using Moq;
using ChatbotDataModelLib.Models;
using CategoryContractLib;

namespace CategoryLib.Test
{
    [TestClass]
    public class CategoryUnitTest
    {        
        private readonly Question question1;
        private readonly Question question2;
        private readonly PatientMonitor PatientMonitor1;
        private readonly PatientMonitor PatientMonitor2;
        private readonly PatientMonitor PatientMonitor3;
        private readonly PatientMonitor PatientMonitor4;
        private readonly PatientMonitor PatientMonitor5;
        readonly List<PatientMonitor> MonitorsList = new List<PatientMonitor>();
        public CategoryUnitTest()
        {
            question1 = new Question { Identifier = "Category", Question1 = "Based on which of these categories do you want to filter the monitors?", Option_1 = "ScreenSize", Option_2 = "Portability", Option_3 = "TouchScreen" };
            question2 = new Question { Identifier = "Category/ScreenSize", Question1 = "Based on which of these categories do you want to filter the monitors??", Option_1 = "Small Screen", Option_2 = "Large Screen", Option_3 = "-" };
            PatientMonitor1 = new PatientMonitor { Name = "Efficia", Model = "CM10", Screen_Size = "SmallScreen", Portability = "Portable", Touch_Screen = "TouchScreenDisabled", Use = "ICU", Location = "SemiUrban", Weight = "", Care_Stage = "-" };
            PatientMonitor2 = new PatientMonitor { Name = "Efficia", Model = "CM12", Screen_Size = "LargeScreen", Portability = "Portable", Touch_Screen = "TouchScreenDisabled", Use = "ICU", Location = "SemiUrban", Weight = "", Care_Stage = "-" };
            PatientMonitor3 = new PatientMonitor { Name = "Avalon", Model = "FM20", Screen_Size = "SmallScreen", Portability = "Portable", Touch_Screen = "TouchScreenDisabled", Use = "LabourCare", Location = "-", Weight = "LightWeight", Care_Stage = "Antepartum" };
            PatientMonitor4 = new PatientMonitor { Name = "Avalon", Model = "FM40", Screen_Size = "SmallScreen", Portability = "NonPortable", Touch_Screen = "TouchScreenDisabled", Use = "LabourCare", Location = "-", Weight = "HeavyWeight", Care_Stage = "Antepartum" };
            PatientMonitor5 = new PatientMonitor { Name = "Avalon", Model = "FM50", Screen_Size = "SmallScreen", Portability = "NonPortable", Touch_Screen = "TouchScreenDisabled", Use = "LabourCare", Location = "-", Weight = "HeavyWeight", Care_Stage = "Intrapartum" };


            MonitorsList.Add(PatientMonitor1);
            MonitorsList.Add(PatientMonitor2);
            MonitorsList.Add(PatientMonitor3);
            MonitorsList.Add(PatientMonitor4);
            MonitorsList.Add(PatientMonitor5);





            Moq.Mock<CategoryContractLib.ICategory> _mockCategory = new Moq.Mock<CategoryContractLib.ICategory>();
            _mockCategory.Setup(mq => mq.GetCategories()).Returns(question1);
            _mockCategory.Setup(mq => mq.GetQuestion1(It.IsAny<string>())).Returns(question2);
            _mockCategory.Setup(mq => mq.GetSolution(It.IsAny<string>(), It.IsAny<string>())).Returns(MonitorsList);


            this.MockQuestionRepository = _mockCategory.Object;
        }
        public readonly ICategory MockQuestionRepository;

        [TestMethod]
        public void Check_If_Valid_Category_Question_Is_Returned()
        {
            var obj = MockQuestionRepository.GetCategories();            
            Assert.IsTrue(obj.GetType() == question1.GetType());

        }

        [TestMethod]
        public void Given_Valid_User_Input_Category_Question1_Is_Returned()
        {
            string arg1 = "ScreenSize";
            var obj = MockQuestionRepository.GetQuestion1(arg1);
            Assert.AreEqual(obj.Identifier, question2.Identifier);
        }

        [TestMethod]
        public void Given_Valid_User_Input_Valid_Patient_Monitor_List_Is_Returned()
        {
            string arg1 = "TouchScreen";
            string arg2 = "TouchScreenDisabled";
            var obj = MockQuestionRepository.GetSolution(arg1, arg2);
            Assert.AreEqual(obj.Count, MonitorsList.Count);
        }
    }
}
