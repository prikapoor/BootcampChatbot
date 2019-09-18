using CategoryContractLib;
using ChatbotDataModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryLib
{
    public class Category:ICategory
    {
        public Question GetCategories()
        {
            PhilipsDBEntities record = new PhilipsDBEntities();            
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals("Category"));            
            return selected;
        }
        
        public Question GetQuestion1(string Q1)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();            
            string choice = "Category" + "/" + Q1;
            var selected = record.Questions.FirstOrDefault((e) => e.Identifier.Equals(choice));            
            return selected;
        }
        
        public List<PatientMonitor> GetSolution(string Q1, string Q2)
        {
            PhilipsDBEntities record = new PhilipsDBEntities();                      
            return record.PatientMonitors.Where((e) => e.Portability.Equals(Q2) || e.Screen_Size.Equals(Q2) || e.Touch_Screen.Equals(Q2)).ToList();                        
        }
    }
}
