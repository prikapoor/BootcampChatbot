using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChatbotLib;
using System.Collections.Generic;
using Moq;
using ChatbotDataModelLib.Models;
using System.Runtime.CompilerServices;

namespace ChatbotLib.Test
{
    [TestClass]
    public class ChatbotUnitTest
    {
        public TestContext TestContext { get; set; }

        private readonly List<PatientMonitor> patientMonitors;
        private readonly List<Question> questions;
        private readonly Question question;
        private readonly Question q1;
        private readonly Question q3;
        private readonly Question q2;
        private readonly Question q4;

        private readonly List<ChatbotDataModelLib.Models.PatientMonitor> avalonMonitors;
        private readonly List<ChatbotDataModelLib.Models.PatientMonitor> intellivueMonitors;
        public ChatbotUnitTest()
        {
            patientMonitors = new List<PatientMonitor>()
                {
                new PatientMonitor
                {
                    Name = "Avalon",
                    Model = "FM60",
                    Screen_Size = "LargeScreen",
                    Portability = "-",
                    Touch_Screen = "TouchScreenDisabled",
                    Use = "LabourCare",
                    Location = "-",
                    Weight = "HeavyWeight",
                    Care_Stage = "Antepartum"
                }
                };
            questions = new List<Question>()
            {
                new Question
                {
                    Identifier="Category",
                    Question1="Based on which of these categories do you want to filter the monitors?",
                    Option_1="Screen Size",
                    Option_2="Portability",
                    Option_3="Touch Screen"
                }
            };

            avalonMonitors = new List<PatientMonitor>()
            {
                new PatientMonitor
                {
                    Name="Avalon",
                    Model="FM20",
                    Screen_Size="SmallScreen",
                    Portability="Portable",
                    Touch_Screen="TouchScreenDisabled",
                    Use="LabourCare",
                    Location="-",
                    Weight="HeavyWeight",
                    Care_Stage="Antepartum"

                },

                new PatientMonitor
                {
                    Name = "Avalon",
                    Model = "FM30",
                    Screen_Size = "SmallScreen",
                    Portability = "Portable",
                    Touch_Screen = "TouchScreenEnabled",
                    Use = "LabourCare",
                    Location = "-",
                    Weight = "LightWeight",
                    Care_Stage = "Intrapartum"

                }
            };

            intellivueMonitors = new List<PatientMonitor>()
            {
                new PatientMonitor
                {
                    Name="Intellivue",
                    Model="MX700",
                    Screen_Size="LargeScreen",
                    Portability="Portable",
                    Touch_Screen="TouchScreenDisabled",
                    Use="ICU",
                    Location="Urban",
                    Weight="-",
                    Care_Stage="-"
                },

                new PatientMonitor
                {
                    Name="Intellivue",
                    Model="MX800",
                    Screen_Size="LargeScreen",
                    Portability="NonPortable",
                    Touch_Screen="TouchScreenEnabled",
                    Use="ICU",
                    Location="Urban",
                    Weight="-",
                    Care_Stage="-"
                }
        };
            question = new Question { Identifier = "Category", Question1 = "Based on which of these categories do you want to filter the monitors?", Option_1 = "ScreenSize", Option_2 = "Portability", Option_3 = "TouchScreen" };
            q2 = new Question { Identifier = "Initial/ICU", Question1 = "In what kind of an area is the hospital located?", Option_1 = "Urban", Option_2 = "SemiUrban", Option_3 = "-" };
            q3 = new Question { Identifier = "Initial/ICU/Urban", Question1 = "Based on what property do you want to Filter the monitors?", Option_1 = "Portability", Option_2 = "Screen Size", Option_3 = "-" };
            q1 = new Question { Identifier = "Initial", Question1 = "Where will the monitor be used?", Option_1 = "ICU", Option_2 = "Labour care", Option_3 = "-" };
            q4 = new Question { Identifier = "Initial/ICU/Urban/Portability", Question1 = "Based on monitor portability, how do you want to filter the monitors?", Option_1 = "Portable", Option_2 = "NonPortable", Option_3 = "-" };

            Moq.Mock<ChatbotContractLib.IChatbot> mock = new Moq.Mock<ChatbotContractLib.IChatbot>();
            mock.Setup(mr => mr.GetAllMonitors()).Returns(patientMonitors);
            mock.Setup(mr => mr.GetAllQuestions()).Returns(questions);
            mock.Setup(mr => mr.GetInitialQuestion()).Returns(q1);
            mock.Setup(mr => mr.GetQ2(It.IsAny<string>())).Returns(q2);
            mock.Setup(mr => mr.GetQ3(It.IsAny<string>(), It.IsAny<string>())).Returns(q3);
            mock.Setup(mr => mr.GetQ4(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(q4);
            mock.Setup(mr => mr.GetICUSolution(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(intellivueMonitors);
            mock.Setup(mr => mr.GetAvalonSolution(It.IsAny<string>(), It.IsAny<string>())).Returns(avalonMonitors);
            mock.Setup(mr => mr.PostNewMonitors(It.IsAny<PatientMonitor>())).Returns((PatientMonitor pm) =>
            {
                PatientMonitor patientMonitor = patientMonitors.Find(d => d.Model == pm.Model);
                if (patientMonitor == null)
                {
                    patientMonitors.Add(pm);
                    return true;
                }
                return false;
            }
            
            );//
            mock.Setup(mr => mr.DeleteMonitor(It.IsAny<string>())).Returns((string mon) =>
            {

                PatientMonitor patientMonitor = patientMonitors.Find(d => d.Model == (mon).ToString());

                if (patientMonitor != null)
                {
                    patientMonitors.Remove(patientMonitor);
                    return true;
                }
                return false;
            });
            this.MockChatbotRepository = mock.Object;

        }

        public ChatbotContractLib.IChatbot MockChatbotRepository;

        [TestMethod]
        public void Given_Valid_Product_Add_Into_The_Database()
        {


            PatientMonitor patientMonitor = new PatientMonitor
            {
                Name = "Avalon",
                Model = "FM80",
                Screen_Size = "SmallScreen",
                Portability = "-",
                Touch_Screen = "TouchScreenDisabled",
                Use = "LabourCare",
                Location = "-",
                Weight = "LightWeight",
                Care_Stage = "Antepartum"
            };

            PatientMonitor patientMonitor1 = new PatientMonitor
            {
                Name = "Avalon",
                Model = "FM70",
                Screen_Size = "SmallScreen",
                Portability = "-",
                Touch_Screen = "TouchScreenEnabled",
                Use = "LabourCare",
                Location = "-",
                Weight = "LightWeight",
                Care_Stage = "Intrapartum"
            };




            MockChatbotRepository.PostNewMonitors(patientMonitor1);
            MockChatbotRepository.PostNewMonitors(patientMonitor);
            int monitorCount = MockChatbotRepository.GetAllMonitors().Count;
            Assert.AreEqual(3, monitorCount);
        }

        [TestMethod]
        public void Given_InValid_Product_False_Value_Is_Returned()
        {


            PatientMonitor patientMonitor = new PatientMonitor
            {
                Name = "Avalon",
                Model = "FM60",
                Screen_Size = "LargeScreen",
                Portability = "-",
                Touch_Screen = "TouchScreenDisabled",
                Use = "LabourCare",
                Location = "-",
                Weight = "HeavyWeight",
                Care_Stage = "Antepartum"
            };
                    
            bool expectedValue = MockChatbotRepository.PostNewMonitors(patientMonitor);
            bool actualValue = false;
            Assert.AreEqual(actualValue, expectedValue);
        }

        [TestMethod]
        public void Return_All_The_Monitors()
        {
            int expectedValue = MockChatbotRepository.GetAllMonitors().Count;
            int actualValue = 1;
            Assert.AreEqual(actualValue, expectedValue);
        }

        [TestMethod]
        public void Return_All_The_Questions()
        {
            int expectedValue = MockChatbotRepository.GetAllQuestions().Count;
            int actualValue = 1;
            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void Given_Valid_Monitor_Name_Delete_Inthe_Database_Is_Asserted()
        {
            string ProductName = "FM60";
            bool check = MockChatbotRepository.DeleteMonitor(ProductName);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void Given_InValid_Monitor_Name_False_Is_Returned()
        {
            string ProductName = "FM80";
            bool check = MockChatbotRepository.DeleteMonitor(ProductName);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void If_Initial_Question_Returned_Assert_True()
        {
            Question ret = MockChatbotRepository.GetInitialQuestion();
            Assert.AreEqual(ret.Identifier, q1.Identifier);
        }

        [TestMethod]
        public void Given_Valid_Argument_Question2_Returned_Assert_True()
        {
            string arg1 = "ICU";
            Question ret = MockChatbotRepository.GetQ2(arg1);
            Assert.AreEqual(ret.Identifier, q2.Identifier);
        }

        [TestMethod]
        public void Given_Valid_Argument_Question3_Returned_Assert_True()
        {
            string arg1 = "ICU";
            string arg2 = "Urban";
            Question q = new Question { Identifier = "Initial/ICU/Urban", Question1 = "Based on what property do you want to Filter the monitors?", Option_1 = "Portability", Option_2 = "Screen Size", Option_3 = "-" };
            Question ret = MockChatbotRepository.GetQ3(arg1, arg2);
            Assert.AreEqual(ret.Identifier, q.Identifier);
        }

        [TestMethod]
        public void Given_Valid_Argument_Question4_Returned_Assert_True()
        {
            string arg1 = "ICU";
            string arg2 = "Urban";
            string arg3 = "Portability";
            Question ret = MockChatbotRepository.GetQ4(arg1, arg2, arg3);
            Assert.AreEqual(q4.Identifier, ret.Identifier);
        }

        [TestMethod]
        public void Given_Valid_Arguments_Avalon_Monitor_List_Is_Asserted()
        {
            string arg1 = "Weight";
            string arg2 = "LightWeight";
            int expectedValue = MockChatbotRepository.GetAvalonSolution(arg1, arg2).Count;
            int actualValue = 2;
            Assert.AreEqual(actualValue, expectedValue);
        }

        [TestMethod]
        public void Given_Valid_Arguments_Patient_Monitor_List_Is_Asserted()
        {
            string arg1 = "Urban";
            string arg2 = "Portability";
            string arg3 = "NonPortable";
            int expectedValue = MockChatbotRepository.GetICUSolution(arg1, arg2, arg3).Count;
            int actualValue = 2;
            Assert.AreEqual(actualValue, expectedValue);
        }


    }
}
