using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatbotService1.Support_Classes;

namespace ChatbotService1.Controllers
{
    public class CategoryController : ApiController
    {        
        readonly string ID2 = "Category";
        CreateEntity obj = new CreateEntity();

        bool CreateCategoryList(List<PatientMonitor> list, int iteration, string attribute)
        {
            if (list[iteration].Portability.Equals(attribute) || list[iteration].Screen_Size.Equals(attribute) || list[iteration].Touch_Screen.Equals(attribute))
            {
                return true;
            }
            return false;
        }

        [Route("api/Category")]
        public QuestionClass GetCategory()
        {                        
            var record = obj.CreateEntities();
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(ID2));
            if (selected == null) throw new Exception("Model not found");
            var models = new QuestionClass();
            models.Convert(selected);
            return models;
        }

        [Route("api/Category/{Q1}")]
        public QuestionClass GetCategoryQuestion1(string Q1)
        {
            var record = obj.CreateEntities();
            string choice = ID2 + "/" + Q1;
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));
            if (selected == null) throw new Exception("Model not found");
            var models = new QuestionClass();
            models.Convert(selected);
            return models;
        }
        
        [Route("api/Category/{Q1}/{Q2}")]
        public IEnumerable<PatientMonitor> GetCategorySolution(string Q2)
        {
            var record = obj.CreateEntities();
            var item = record.PatientMonitors.ToList();
            List<PatientMonitor> list = new List<PatientMonitor>();
            for (int i = 0; i < record.PatientMonitors.Count(); i++)
            {
                if (CreateCategoryList(item, i, Q2))
                    list.Add(item[i]);
            }
            //if (!list.Any()) throw new Exception("Model not found");
            //list.FindAll()
            return list;
        }
        //[Route("api/Category/{Q1}/{Q2}")]
        //public IEnumerable<PatientMonitor> GetCategorySolution(string Q2)
        //{
        //    var record = obj.CreateEntities();
        //    var item = record.PatientMonitors.ToList();
        //    List<PatientMonitor> list = new List<PatientMonitor>();
        //    for (int i = 0; i < record.PatientMonitors.Count(); i++)
        //    {
        //        if (item[i].Portability.Equals(Q2) || item[i].Screen_Size.Equals(Q2) || item[i].Touch_Screen.Equals(Q2))
        //        {
        //            list.Add(item[i]);
        //        }
        //    }
        //    //if (!list.Any()) throw new Exception("Model not found");
        //    //list.FindAll()
        //    return list;
        //}

    }
}
