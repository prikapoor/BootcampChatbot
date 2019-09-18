using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotDataModelLib.Models;
using ChatbotService1.Support_Classes;

namespace ChatbotService1.Controllers
{
    public class ChatbotController : ApiController
    {        
        readonly string ID = "Initial";
        CreateEntity obj = new CreateEntity();

        bool CreateAvalonList(List<PatientMonitor> list, int iteration, string attribute)
        {
            bool result=false;
            if (list[iteration].Use.Equals("LabourCare") && (list[iteration].Care_Stage.Equals(attribute) || list[iteration].Weight.Equals(attribute)))
            {
                result = true;
            }
            return result;
        }

        [Route("api/chatbot/Monitors")]
        public IEnumerable<PatientMonitor> GetMonitors()
        {            
               var record = obj.CreateEntities();
               return record.PatientMonitors.ToList();   
        }

        [Route("api/chatbot/Questions")]
        public IEnumerable<Question> GetAllQuestions()
        {
            var record = obj.CreateEntities();
            return record.Questions.ToList();            
        }

        [Route("api/chatbot/Questions/Initial")]
        public QuestionClass GetFirstQuestion()
        {
            var record = obj.CreateEntities();
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(ID));
                if (selected == null) throw new Exception("Model not found");
                var models = new QuestionClass();
                models.Convert(selected);
                return models;                         
        }

        [Route("api/chatbot/Questions/Initial/{Q1}")]
        public QuestionClass GetQuestion2(string Q1)
        {
            var record = obj.CreateEntities();
            string choice = ID + "/" + Q1;         
                var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));
                if (selected == null) throw new Exception("Model not found");
                var models = new QuestionClass();
                models.Convert(selected);
                return models;                            
        }

        [Route("api/chatbot/Questions/Initial/{Q1}/{Q2}")]
        public QuestionClass GetQuestion3(string Q1,string Q2)
        {
            var record = obj.CreateEntities();
            string choice = ID + "/" + Q1 + "/" + Q2;             
                    var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));
                    if (selected == null) throw new Exception("Model not found");
                    var models = new QuestionClass();
                    models.Convert(selected);
                    return models;                            
        }

        [Route("api/chatbot/Questions/Initial/{Q1}/{Q2}/{Q3}")]
        public QuestionClass GetQuestion4(string Q1, string Q2,string Q3)
        {
            var record = obj.CreateEntities();
            string choice = ID + "/" + Q1 + "/" + Q2 + "/" + Q3;                    
                    var select = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));
                    var models = new QuestionClass();
                    models.Convert(select);
                    return models;
        }


        [Route("api/chatbot/Questions/Initial/LabourCare/{Q2}/{Q3}")]
        public IEnumerable<PatientMonitor> GetSolutionAvalon(string Q2, string Q3)
        {
            var record = obj.CreateEntities();
            var item = record.PatientMonitors.ToList();                
                List<PatientMonitor> list = new List<PatientMonitor>();
                for (int i = 0; i < record.PatientMonitors.Count(); i++)
                {
                    if (CreateAvalonList(item, i, Q3))
                        list.Add(item[i]);
                }
            if (!list.Any()) throw new Exception("Model not found");
                return list;
        }
        

        [Route("api/chatbot/Questions/Initial/ICU/{Q2}/{Q3}/{Q4}")]
        public IEnumerable<PatientMonitor> GetSolutionICU(string Q2, string Q3, string Q4)
        {
            var record = obj.CreateEntities();
            var item = record.PatientMonitors.ToList();                
                List<PatientMonitor> list = new List<PatientMonitor>();
                for (int i=0;i<record.PatientMonitors.Count();i++)
                {
                    //if (item[i].Use.Equals("ICU") && item[i].Location.Equals(Q2) && (item[i].Portability.Equals(Q4) || item[i].Screen_Size.Equals(Q4) || item[i].Touch_Screen.Equals(Q4)))
                    if (item[i].Location.Equals(Q2) && (item[i].Portability.Equals(Q4) || item[i].Screen_Size.Equals(Q4) || item[i].Touch_Screen.Equals(Q4)))
                    {
                        list.Add(item[i]);
                    }
                }
                if (!list.Any()) throw new Exception("Model not found");
                return list;
        }
    }
}
