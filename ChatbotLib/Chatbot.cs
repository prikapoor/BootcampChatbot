using ChatbotContractLib;
using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace ChatbotLib
{
     public sealed class Chatbot:IChatbot
    {        
        List<Question> IChatbot.GetAllQuestions()
        {
            PhilipsDBEntities record = new PhilipsDBEntities();            
            return record.Questions.ToList();
        }

        bool IChatbot.PostNewMonitors(PatientMonitor newmod)
        {            
                PhilipsDBEntities record = new PhilipsDBEntities();
                var selected = record.PatientMonitors.FirstOrDefault((e) => e.Model.Equals(newmod.Model));
                if (selected == null)
                {       
                    record.PatientMonitors.Add(newmod);
                    record.SaveChanges();
                    return true;
                }
                return false;
           
        }

        bool IChatbot.DeleteMonitor(string mod)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            var selected = record.PatientMonitors.FirstOrDefault((e) => e.Model.Equals(mod));
            if (selected == null)
                return false;
            record.PatientMonitors.Remove(record.PatientMonitors.FirstOrDefault(e => e.Model == mod));
            record.SaveChanges();
            return true;
        }

        Question IChatbot.GetInitialQuestion()
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals("Initial"));            
            return selected;
        }

        Question IChatbot.GetQ2(string Q1)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            string choice = "Initial" + "/" + Q1;
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));            
            return selected;
        }

        Question IChatbot.GetQ3(string Q1, string Q2)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            string choice = "Initial" + "/" + Q1 + "/" + Q2;
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));            
            return selected;
        }

        Question IChatbot.GetQ4(string Q1, string Q2, string Q3)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            string choice = "Initial" + "/" + Q1 + "/" + Q2 + "/" + Q3;
            var select = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));
            return select;
        }

        List<PatientMonitor> IChatbot.GetAvalonSolution(string Q2, string Q3)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            return record.PatientMonitors.Where((e) => (e.Care_Stage.Equals(Q3) || e.Weight.Equals(Q3))).ToList();
        }


        List<PatientMonitor> IChatbot.GetICUSolution(string Q2, string Q3, string Q4)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            return record.PatientMonitors.Where((e) => e.Location.Equals(Q2) && (e.Portability.Equals(Q4) || e.Screen_Size.Equals(Q4) || e.Touch_Screen.Equals(Q4))).ToList();
        }

        List<PatientMonitor> IChatbot.GetAllMonitors()
        {
            PhilipsDBEntities record = new PhilipsDBEntities();
            return record.PatientMonitors.ToList();
        }
    }
}
